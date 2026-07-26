using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace VisualMountParking
{
    public enum AppThemeMode
    {
        Light,
        Dark
    }

    public sealed class ThemePalette
    {
        public Color Background;
        public Color Surface;
        public Color ToolbarBackground;
        public Color Border;
        public Color Text;
        public Color TextSecondary;
        public Color Accent;
        public Color AccentBackground;
        public Color Danger;
        public Color DangerBackground;
        public Color OnDanger;
        public Color Success;
    }

    internal static class Theme
    {
        public static readonly ThemePalette Light = new ThemePalette
        {
            Background = Color.FromArgb(0xF3, 0xF3, 0xF3),
            Surface = Color.White,
            ToolbarBackground = Color.FromArgb(0xFA, 0xFA, 0xFA),
            Border = Color.FromArgb(0xE1, 0xE1, 0xE1),
            Text = Color.FromArgb(0x1B, 0x1B, 0x1B),
            TextSecondary = Color.FromArgb(0x5F, 0x5F, 0x5F),
            Accent = Color.FromArgb(0x00, 0x67, 0xC0),
            AccentBackground = Color.FromArgb(0xE5, 0xF1, 0xFB),
            Danger = Color.FromArgb(0xC4, 0x2B, 0x1C),
            DangerBackground = Color.FromArgb(0xFB, 0xE6, 0xE4),
            OnDanger = Color.White,
            Success = Color.FromArgb(0x10, 0x7C, 0x10),
        };

        public static readonly ThemePalette Dark = new ThemePalette
        {
            Background = Color.FromArgb(0x20, 0x20, 0x20),
            Surface = Color.FromArgb(0x2C, 0x2C, 0x2C),
            ToolbarBackground = Color.FromArgb(0x26, 0x26, 0x26),
            Border = Color.FromArgb(0x3D, 0x3D, 0x3D),
            Text = Color.FromArgb(0xF5, 0xF5, 0xF5),
            TextSecondary = Color.FromArgb(0xB0, 0xB0, 0xB0),
            Accent = Color.FromArgb(0x4C, 0xC2, 0xFF),
            AccentBackground = Color.FromArgb(0x15, 0x33, 0x45),
            Danger = Color.FromArgb(0xFF, 0x99, 0xA4),
            DangerBackground = Color.FromArgb(0x4A, 0x20, 0x20),
            OnDanger = Color.FromArgb(0x20, 0x20, 0x20),
            Success = Color.FromArgb(0x6B, 0xCF, 0x6B),
        };

        public static AppThemeMode Current { get; private set; } = AppThemeMode.Light;

        public static ThemePalette Palette => Current == AppThemeMode.Dark ? Dark : Light;

        public static AppThemeMode GetSystemTheme()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
                {
                    if (key?.GetValue("AppsUseLightTheme") is int useLightTheme && useLightTheme == 0)
                        return AppThemeMode.Dark;
                }
            }
            catch (Exception)
            {
                // Registry key unavailable (e.g. older Windows) -> fall back to light theme
            }
            return AppThemeMode.Light;
        }

        public static void ApplyColors(Control root, AppThemeMode mode)
        {
            Current = mode;
            ApplyRecursive(root, Palette);
        }

        private static void ApplyRecursive(Control control, ThemePalette palette)
        {
            switch (control)
            {
                case Form form:
                    form.BackColor = palette.Background;
                    break;
                case Button button:
                    StyleButton(button, palette);
                    break;
                case CheckBox checkBox when checkBox.Appearance == Appearance.Button:
                    checkBox.FlatStyle = FlatStyle.Flat;
                    checkBox.BackColor = palette.Surface;
                    checkBox.ForeColor = palette.Text;
                    checkBox.FlatAppearance.BorderSize = 1;
                    checkBox.FlatAppearance.BorderColor = palette.Border;
                    checkBox.FlatAppearance.CheckedBackColor = palette.AccentBackground;
                    break;
                case CheckBox checkBox:
                    checkBox.FlatStyle = FlatStyle.Flat;
                    checkBox.ForeColor = palette.Text;
                    // Transparent lets the checkmark glyph fall back to an opaque white box,
                    // making a light checkmark invisible in dark mode; give it a solid fill instead.
                    checkBox.BackColor = palette.Surface;
                    checkBox.FlatAppearance.BorderColor = palette.Border;
                    checkBox.FlatAppearance.CheckedBackColor = palette.Surface;
                    break;
                case Label label:
                    label.ForeColor = palette.Text;
                    label.BackColor = Color.Transparent;
                    break;
                case ComboBox comboBox:
                    comboBox.FlatStyle = FlatStyle.Flat;
                    comboBox.BackColor = palette.Surface;
                    comboBox.ForeColor = palette.Text;
                    break;
                case TextBoxBase textBox:
                    textBox.BackColor = palette.Surface;
                    textBox.ForeColor = palette.Text;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case NumericUpDown numericUpDown:
                    numericUpDown.BackColor = palette.Surface;
                    numericUpDown.ForeColor = palette.Text;
                    numericUpDown.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case GroupBox groupBox:
                    groupBox.ForeColor = palette.Text;
                    groupBox.BackColor = Color.Transparent;
                    break;
                case TabControl tabControl:
                    tabControl.BackColor = palette.Background;
                    StyleTabControl(tabControl);
                    break;
                case TabPage tabPage:
                    tabPage.BackColor = palette.Background;
                    tabPage.ForeColor = palette.Text;
                    break;
                case PictureBox pictureBox when pictureBox.BorderStyle == BorderStyle.FixedSingle:
                    pictureBox.BackColor = palette.Surface;
                    break;
                case Panel panel:
                    switch ((string)(panel.Tag ?? ""))
                    {
                        case "card":
                            panel.BackColor = palette.Surface;
                            break;
                        case "toolbar":
                            panel.BackColor = palette.ToolbarBackground;
                            break;
                        case "sidebar":
                            panel.BackColor = palette.Background;
                            break;
                    }
                    break;
            }

            foreach (Control child in control.Controls)
                ApplyRecursive(child, palette);
        }

        private static void StyleButton(Button button, ThemePalette palette)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;

            switch ((string)(button.Tag ?? ""))
            {
                case "danger":
                    button.BackColor = palette.DangerBackground;
                    button.ForeColor = palette.Danger;
                    button.FlatAppearance.BorderColor = palette.Danger;
                    break;
                case "accent":
                    button.BackColor = palette.AccentBackground;
                    button.ForeColor = palette.Accent;
                    button.FlatAppearance.BorderColor = palette.Accent;
                    break;
                case "icon":
                    button.BackColor = palette.ToolbarBackground;
                    button.ForeColor = palette.Text;
                    button.FlatAppearance.BorderSize = 0;
                    break;
                default:
                    button.BackColor = palette.Surface;
                    button.ForeColor = palette.Text;
                    button.FlatAppearance.BorderColor = palette.Border;
                    break;
            }
        }

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        private static void StyleTabControl(TabControl tabControl)
        {
            // Visual styles draw a themed page-frame border around the tab body that ignores
            // BackColor entirely. Stripping the theme from just this control drops that frame;
            // owner-draw below then fully controls the tab strip and page background. Any
            // remaining native border margin is handled by ThemedTabControl (see its WndProc)
            // since TabControl is a native-wrapped control and never raises Control.Paint.
            SetWindowTheme(tabControl.Handle, "", "");
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem -= TabControl_DrawItem;
            tabControl.DrawItem += TabControl_DrawItem;
            tabControl.Invalidate();
        }

        private static void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tabControl = (TabControl)sender;
            var palette = Palette;

            if (e.Index == 0)
            {
                var headerRect = new Rectangle(0, 0, tabControl.Width, tabControl.ItemSize.Height + 6);
                using (var headerBrush = new SolidBrush(palette.Background))
                    e.Graphics.FillRectangle(headerBrush, headerRect);
            }

            var tabPage = tabControl.TabPages[e.Index];
            var tabRect = tabControl.GetTabRect(e.Index);
            bool selected = e.Index == tabControl.SelectedIndex;

            using (var backBrush = new SolidBrush(selected ? palette.Surface : palette.Background))
                e.Graphics.FillRectangle(backBrush, tabRect);

            var textColor = selected ? palette.Text : palette.TextSecondary;
            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabControl.Font, tabRect, textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        /// Recolors a black-glyph icon (whether on an opaque white background or a
        /// transparent one) to the given color, deriving alpha from source luminance
        /// so the glyph stays crisp/anti-aliased against any theme background.
        public static Bitmap Tint(Bitmap source, Color color)
        {
            var result = new Bitmap(source.Width, source.Height, PixelFormat.Format32bppArgb);
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    var pixel = source.GetPixel(x, y);
                    int luminance = (pixel.R + pixel.G + pixel.B) / 3;
                    int alpha = pixel.A * (255 - luminance) / 255;
                    result.SetPixel(x, y, Color.FromArgb(alpha, color));
                }
            }
            return result;
        }

        [DllImport("dwmapi.dll", PreserveSig = true)]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attribute, ref int pvAttribute, int cbAttribute);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_OLD = 19;

        public static void ApplyDarkTitleBar(Form form, bool dark)
        {
            if (!form.IsHandleCreated)
                return;

            int value = dark ? 1 : 0;
            try
            {
                if (DwmSetWindowAttribute(form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref value, sizeof(int)) != 0)
                    DwmSetWindowAttribute(form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE_OLD, ref value, sizeof(int));
            }
            catch (DllNotFoundException)
            {
                // dwmapi attribute not supported on this Windows version
            }
        }
    }
}
