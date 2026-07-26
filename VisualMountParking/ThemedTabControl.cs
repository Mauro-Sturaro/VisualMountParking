using System.Drawing;
using System.Windows.Forms;

namespace VisualMountParking
{
    // TabControl wraps the native Win32 tab control, so it never raises the normal .NET
    // Paint event for its own chrome (only WM_DRAWITEM for owner-drawn tab headers reaches
    // managed code). The page-frame border is baked into its native WM_PAINT handling and
    // can't be recolored via any property, so we intercept WM_PAINT here and paint over the
    // border margin afterwards.
    public sealed class ThemedTabControl : TabControl
    {
        private const int WM_PAINT = 0x000F;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT && IsHandleCreated)
                PaintOverNativeBorder();
        }

        private void PaintOverNativeBorder()
        {
            var palette = Theme.Palette;
            var display = DisplayRectangle;
            var client = ClientRectangle;

            using (var g = Graphics.FromHwnd(Handle))
            using (var brush = new SolidBrush(palette.Background))
            {
                g.FillRectangle(brush, Rectangle.FromLTRB(client.Left, display.Top, display.Left, client.Bottom));
                g.FillRectangle(brush, Rectangle.FromLTRB(display.Right, display.Top, client.Right, client.Bottom));
                g.FillRectangle(brush, Rectangle.FromLTRB(display.Left, display.Bottom, display.Right, client.Bottom));
            }
        }
    }
}
