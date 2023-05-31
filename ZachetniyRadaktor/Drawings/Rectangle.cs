using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachetniyRadaktor.Drawings
{
    public class Rectangle : Figure
    {

        public Rectangle(Point position, Size size, Color color, bool isEnabled = true) : base(position, size, color, isEnabled) { }

        public override void DrawFigureAt(Graphics gr, Point location)
        {
            System.Drawing.Rectangle rect = new(location, size);
            var color = IsEnabled ? Color : Color.FromArgb(255 / 2, Color);
            SolidBrush brush = new SolidBrush(color);
            gr.FillRectangle(brush, rect);
        }

        public override void DrawOutline(Graphics gr, Point location)
        {
            System.Drawing.Rectangle rect = new(location - new Size(5, 5), size + new Size(10, 10));
            var color = Color.FromArgb(255 - Color.R, 255 - Color.G, 255 - Color.B);
            SolidBrush brush = new SolidBrush(color);
            gr.FillRectangle(brush, rect);
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
