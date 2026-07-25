# Code Review — VisualMountParking

Data: luglio 2026
Ambito: revisione del codice C# esistente (.NET Framework 4.8, WinForms, ASCOM, Emgu.CV/ArUco)

## Panoramica

Il progetto è ben strutturato per essere nato come tool personale: separazione chiara tra
sorgente immagine (`Camera/`, con interfaccia `ICamera` e factory), riconoscimento marker
(`Markers/`, ArUco via Emgu.CV) e logica di parcheggio automatico (`AutoPark.cs`), con la UI
in `MainForm`/`SettingsForm`. Non ci sono problemi architetturali gravi. I punti sotto sono
elencati per severità.

---

## 1. Bug e correttezza

### 1.1 Formula del punto di minima distanza — DA VERIFICARE (`AutoPark.MinimizeDistance`)
```csharp
var m = (Ay - By) / (Ax - Bx);
var q = Ay - m * Ax;
var Cx = -q / (2 * m);
```
Il commento dice: trovare il punto della retta per A e B più vicino all'origine, come
intersezione con la perpendicolare passante per l'origine. Per una retta `y = m·x + q`,
il punto più vicino all'origine è dato da `x = -m·q / (1 + m²)`, non da `-q / (2·m)`.
La formula attuale sembra un'approssimazione non corretta (funziona "per caso" solo in
casi particolari, es. m grande). Probabilmente il sistema funziona comunque perché il ciclo
`while` in `SlewOneAxis` corregge iterativamente l'errore ad ogni passo (retroazione), ma la
convergenza rischia di essere più lenta/instabile del necessario, specialmente su reti/mount lenti.
**Non l'ho toccata nella patch**: è il cuore dell'algoritmo di puntamento e va validata con la
tua strumentazione reale prima di cambiarla. Se vuoi, nel prossimo step possiamo derivare la
formula corretta e testarla in simulazione (c'è già `DummyCamera` per i test senza hardware).

Bug minore collegato: se `Ax == Bx` (nessuno spostamento sull'asse x) il codice logga un
messaggio ma poi continua e calcola comunque `m = (Ay-By)/0`, generando `Infinity`/`NaN`. C'è
un controllo di sicurezza (`IsValidNonZero`) più a monte in `SlewOneAxis`, ma dentro
`MinimizeDistance` stesso il valore `NaN` può propagarsi in `nextMove` prima di essere scartato.

### 1.2 `PositionTolerance` è `decimal` ma confrontato con `double`
In `Config.cs` è `decimal`, in `AutoPark.CheckPosition` viene castato a `double`. Funziona,
ma è un'inconsistenza di tipo senza motivo (probabilmente `decimal` è rimasto solo perché
comodo per il `NumericUpDown` in `SettingsForm`). Consiglio: tenerlo `double` e gestire la
conversione solo nella UI.

### 1.3 `MainForm.chkImageSize_CheckedChanged` referenzia `PictureBoxSizeMode.Normal` via reflection altrove
In `GetStretch` si legge `ImageRectangle` via reflection su una proprietà `internal` di
`PictureBox` — è un modo fragile per calcolare l'area di disegno reale in modalità `Zoom`, e
può rompersi con future versioni del framework. Non è un bug oggi, ma è un rischio silenzioso.
Esiste un modo standard per calcolare il rettangolo (calcolo manuale con aspect ratio) che
elimina la dipendenza da API interne.

---

## 2. Gestione risorse (memory leak)

### 2.1 `Mat` non rilasciati in `ArucoDetector` — **incluso nella patch**
`FindMarkers` e `AnalyzeFrame`/`DrawMarkers` creano un `Mat frame = image24.ToMat()` che non
viene mai disposto (`Mat` avvolge memoria unmanaged OpenCV). Dato che `FindMarkers` viene
chiamato ad ogni tick del timer immagine (ogni pochi secondi, potenzialmente per ore durante
una sessione), è una perdita di memoria lenta ma continua — il tipo di bug che si manifesta
solo dopo ore di utilizzo, cioè esattamente lo scenario di un osservatorio remoto lasciato
acceso tutta la notte. Corretto con `using`.

### 2.2 `HttpClient` istanziato ad ogni chiamata — **incluso nella patch**
In `WebUtils.RunCommandURIAsync` e `Camera/UrlCamera.LoadImageAsync` viene creato un nuovo
`HttpClient` ad ogni chiamata. È un anti-pattern noto: ogni istanza tiene aperto un socket
finché non interviene la garbage collection, e sotto uso ripetuto (polling dell'immagine ogni
pochi secondi) si rischia l'esaurimento delle porte disponibili (`SocketException`) dopo ore
di funzionamento continuo. Ho centralizzato un `HttpClient` statico condiviso.

---

## 3. Robustezza / gestione errori

### 3.1 Eccezioni inghiottite silenziosamente
`FileCamera.LoadImageAsync`, `UrlCamera.LoadImageAsync` e `AutoPark.ConnectCamera` catturano
`Exception` e restituiscono un'immagine di errore o passano a `DummyCamera`, senza loggare
nulla. In un sistema che gira incustodito su un osservatorio remoto, questo significa che se
la webcam smette di rispondere alle 3 di notte, l'unico segnale è un'iconcina di errore
nell'interfaccia — nessuna traccia in un log per capire cosa sia successo dopo. Ho aggiunto
`Debug.WriteLine` nei punti che erano completamente silenziosi (minimo invasivo); una vera
soluzione strutturata (file di log persistente, non solo la finestra `LogForm` in-memory)
è un buon candidato per la fase "nuove funzionalità".

### 3.2 `AsyncUtil.RunSync` blocca il thread UI
Usato in `SettingsForm.btPreview_Click` e `EditCommand.btTest_Click` per chiamare codice
async da un click handler sincrono. Evita il classico deadlock (usa `TaskScheduler.Default`
esplicitamente), quindi funzionalmente è corretto, ma blocca comunque il thread UI per tutta
la durata della richiesta di rete — l'app "si blocca" (non risponde, niente ridisegno) se la
telecamera è lenta a rispondere. Sarebbe meglio rendere questi handler `async void` e usare
`await` direttamente, con un cursore di attesa. Non l'ho cambiato nella patch perché tocca il
comportamento della UI — meglio discuterne nella fase di rinnovamento interfaccia.

---

## 4. Qualità del codice / manutenibilità

- **`ImageDecorator.cs`**: classe vuota, mai usata — rimossa nella patch.
- **`DummyCamera.cs`**: contiene uno `using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;` completamente inutilizzato (probabile autocomplete IDE sbagliato) — rimosso.
- **`MarkerPoint.cs` e `ZoneMatch.cs`** vivono nella cartella `Markers/` ma dichiarano
  `namespace VisualMountParking` invece di `VisualMountParking.Markers` — inconsistenza minore,
  non bloccante (non l'ho toccata nella patch per non rischiare conflitti di refactor senza
  la tua supervisione, ma è un fix meccanico a basso rischio se vuoi che lo includa dopo).
- **`MainForm.cs`** ha ~580 righe con logica di disegno overlay, gestione bottoni di
  movimento, e coordinamento del driver tutta insieme. Non è un problema di correttezza, ma
  quando arriveremo al rinnovamento UI vale la pena scomporlo (es. un `OverlayRenderer`
  separato per `DrawOverlay`/`DrawMarker`/`DrawStringWithBackground`, che sono pure funzioni
  di disegno senza stato).
- Alcuni commenti/log restano in italiano misto a inglese (`//ToDo evitare la copia`,
  `// per sicurezza`) — non è un problema per un progetto personale, lo segnalo solo se in
  futuro pensi di renderlo open source o condividerlo con altri astrofili anglofoni.

---

## 5. Sicurezza

- `Program.cs` disabilita globalmente la validazione del certificato TLS
  (`ServicePointManager.ServerCertificateValidationCallback += (...) => true;`) per tutta
  l'applicazione, con la motivazione (in commento) che la telecamera Reolink in rete locale
  usa un certificato self-signed. È una scelta ragionevole per un dispositivo su LAN privata,
  ma **disabilita la validazione per qualsiasi connessione HTTPS fatta dall'app**, comprese
  eventuali chiamate future a servizi esterni. Se in futuro aggiungi funzionalità che parlano
  con internet (notifiche, aggiornamenti, cloud storage...), meglio limitare l'eccezione al
  solo host della camera invece che a livello globale.

---

## Cosa è incluso nella patch allegata

Ho applicato solo le modifiche a **rischio pressoché nullo** e comportamento equivalente
(nessun cambio di logica di puntamento o di UI):

1. Fix memory leak: `using` sui `Mat` in `ArucoDetector`
2. `HttpClient` condiviso invece di uno nuovo per chiamata (`WebUtils`, `UrlCamera`)
3. Log minimi (`Debug.WriteLine`) nei catch che erano completamente silenziosi
4. Rimozione codice morto: `ImageDecorator.cs`, using inutilizzato in `DummyCamera.cs`

**Non incluso** (richiede una tua decisione o test con l'hardware reale):
- La formula geometrica in `MinimizeDistance` (punto 1.1)
- `AsyncUtil.RunSync` che blocca la UI (punto 3.1) — meglio risolverlo insieme al rinnovamento interfaccia
- Rinomina namespace `MarkerPoint`/`ZoneMatch`
- Logging persistente su file
