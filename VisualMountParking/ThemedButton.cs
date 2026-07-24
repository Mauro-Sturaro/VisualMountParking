using System.Drawing;
using System.Windows.Forms;

namespace VisualMountParking
{
    public sealed class ThemedButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (Enabled || FlatStyle != FlatStyle.Flat)
            {
                base.OnPaint(pevent);
                return;
            }

            var g = pevent.Graphics;
            using (var backBrush = new SolidBrush(BackColor))
                g.FillRectangle(backBrush, ClientRectangle);

            if (FlatAppearance.BorderSize > 0)
            {
                using (var borderPen = new Pen(FlatAppearance.BorderColor, FlatAppearance.BorderSize))
                    g.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
            }

            var disabledColor = Blend(ForeColor, BackColor, 0.45);
            TextRenderer.DrawText(g, Text, Font, ClientRectangle, disabledColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        private static Color Blend(Color foreground, Color background, double weight)
        {
            int r = (int)(foreground.R * weight + background.R * (1 - weight));
            int g = (int)(foreground.G * weight + background.G * (1 - weight));
            int b = (int)(foreground.B * weight + background.B * (1 - weight));
            return Color.FromArgb(r, g, b);
        }
    }
}
