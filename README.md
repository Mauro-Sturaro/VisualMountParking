# Visual Mount Parking

Accurately park a remote astronomical mount using nothing more than a security camera and a couple of printed markers.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE.txt)

## Why

Remote observatories with a sliding or clamshell roof need the telescope to be in a known, safe position before the roof closes for the night. High-end mounts have absolute position encoders that make this trivial. Many popular mounts don't: they rely on relative step counting and can lose their reference position whenever something goes wrong — a stall, a power cycle, an emergency stop in the middle of the night.

Visual Mount Parking solves this with a camera instead of better (and more expensive) hardware. It looks at the mount through a security camera already pointed at it, compares what it sees against a saved reference image, and nudges the mount axis by axis until the telescope is back in the exact same spot — then it's safe to park and close the roof.

## How it works

1. Two [ArUco](https://docs.opencv.org/4.x/d5/dae/tutorial_aruco_detection.html) markers are attached to the mount (or to a fixed point that moves rigidly with it) — one used for the Right Ascension/Azimuth axis, one for Declination/Altitude.
2. With the mount in the desired "parked" position, you capture a **reference image** from the camera and record the marker positions found in it.
3. At any later time, the app grabs a new image, detects the same markers, and measures how far each one has drifted from its reference position.
4. It then commands the mount, one axis at a time, to move toward the reference position. Since a single move rarely lands exactly on target, it re-measures after each move and computes a corrective fraction of the remaining distance, converging onto the reference position over a few iterations.
5. Once both markers are within the configured tolerance, the mount is considered "in position" and can be parked.

The whole process only needs a camera that already has a usable view of the mount — no extra sensors, no hardware modifications to the mount itself.

## Features

- ArUco marker detection and tracking via [Emgu.CV](https://www.emgu.com/) (OpenCV for .NET)
- Iterative, self-correcting positioning algorithm — no camera/mount calibration required
- Mount control through the [ASCOM](https://ascom-standards.org/) platform, compatible with virtually any ASCOM-capable mount driver
- Multiple image sources: HTTP(S) camera snapshot URL, local/network file (e.g. an FTP-synced snapshot), or a local webcam
- Optional IR-light on/off control for cameras that expose it through a WebAPI/HTTP command (tested with Reolink cameras)
- Manual jog controls (slow/fast, both axes) alongside the automatic "Slave to Reference" positioning
- Adjustable position tolerance, move rates and timings, all persisted in a per-user configuration file
- In-app log window for monitoring what the automation is doing

## Requirements

- Windows with [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- [ASCOM Platform 6](https://ascom-standards.org/Downloads/Index.htm) and an ASCOM driver for your mount
- A camera that can provide a snapshot as a static image, either:
  - over HTTP/HTTPS (e.g. a network/security camera's snapshot URL), or
  - as an image file kept up to date on disk/network share, or
  - a locally attached webcam
- Two printed ArUco markers, mounted so they stay rigidly attached to the moving parts of the mount that need to be tracked

The build targets `x64` (required by the native OpenCV binaries pulled in by Emgu.CV).

## Getting started

1. Clone the repository and open `VisualMountParking.sln` in Visual Studio.
2. Restore NuGet packages and build the `x64` configuration.
3. Install the ASCOM driver for your mount and make sure it connects correctly with a tool like the ASCOM Device Hub before using it here.
4. Print two distinct ArUco markers and attach them to the mount so that both stay visible to the camera and move rigidly with the axis they represent.
5. Launch the app and open **Settings**:
   - point it at your ASCOM telescope driver;
   - configure the camera source (URL, file path, or webcam);
   - set the marker ID used for each axis, and the direction/rate/timing values for jogging;
   - adjust the position tolerance to match how precisely you need the mount parked.
6. With the mount manually positioned exactly where you want it to park, capture and save the reference image from the **Settings** dialog.
7. Back on the main window, connect to the mount and use **Slave to Reference** to let the app find and correct the position automatically. The manual jog buttons are always available if you'd rather move the mount by hand.
8. Once the mount reports it's in position, park it and close the roof.

## Project structure

| Folder / file | Purpose |
| --- | --- |
| `Camera/` | Image source abstraction (`ICamera`) and its implementations: URL, file, webcam, and a no-op dummy camera |
| `Markers/` | ArUco marker detection (`ArucoDetector`) and the matching engine that compares a live frame against the reference image (`MarkerMatchEngine`) |
| `AutoPark.cs` | Orchestrates the positioning logic: reads the camera, checks marker drift, drives the mount toward the reference position |
| `MyTelescope.cs` | Thin wrapper around the ASCOM `Telescope` driver |
| `MainForm.cs` / `SettingsForm.cs` | The application UI |
| `Config.cs` | User configuration, persisted as JSON under `%AppData%\VisualMountParking` |

## Contributing

Issues and pull requests are welcome — this started as a personal tool for a single remote observatory setup, so feedback from other setups (different mounts, cameras, roof controllers) is particularly useful.

## Disclaimer

This tool commands your mount to move automatically. Always test the automatic positioning with the mount in a safe range of motion and keep an eye (and a hand near an emergency stop) on it until you're confident it behaves correctly with your specific hardware and configuration. The authors take no responsibility for any damage to your equipment.

## License

Released under the [MIT License](LICENSE.txt).
