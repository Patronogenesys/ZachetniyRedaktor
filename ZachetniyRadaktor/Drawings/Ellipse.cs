using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachetniyRadaktor.Drawings
{
    public class Ellipse : Figure
    {
        public Ellipse(Point position, Size size, Color color) : base(position, size, color) { }

        public override void DrawFigureAt(Graphics gr, Point location)
        {
            System.Drawing.Rectangle rect = new(location, size);
            var color = IsEnabled ? Color : Color.FromArgb(255 / 2, Color);
            SolidBrush brush = new SolidBrush(color);
            gr.FillEllipse(brush, rect);
        }
        protected override bool IsTouched(Point touchPosition)
        {
            return Math.Pow(touchPosition.X - Center.X, 2d) / Math.Pow(size.Width / 2d, 2d) +
                   Math.Pow(touchPosition.Y - Center.Y, 2d) / Math.Pow(size.Height / 2d, 2d) < 1d;
        }

        public override void DrawOutline(Graphics gr, Point location)
        {
            System.Drawing.Rectangle rect = new(location - new Size(5, 5), size + new Size(10, 10));
            var color = Color.FromArgb(255 - Color.R, 255 - Color.G, 255 - Color.B);
            SolidBrush brush = new SolidBrush(color);
            gr.FillEllipse(brush, rect);
        }
    }
}
