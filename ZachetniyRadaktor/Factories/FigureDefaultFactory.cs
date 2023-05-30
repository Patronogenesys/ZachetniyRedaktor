using System.CodeDom.Compiler;
using ZachetniyRadaktor.Drawings;

namespace ZachetniyRadaktor.Factories
{
    internal abstract class FigureDefaultFactory
    {
        protected System.Drawing.Rectangle createArea;
        protected int maxDimentions;
        protected int minDimentions;
        private Random random = new();
        public FigureDefaultFactory(System.Drawing.Rectangle createArea, int minDimentions, int maxDimentions)
        {
            this.createArea = createArea;
            this.minDimentions = minDimentions;
            this.maxDimentions = maxDimentions;
        }

        protected virtual (Point postion, Size size, Color color) GenerateValues()
        {
            var size = new Size(random.Next(minDimentions, maxDimentions), random.Next(minDimentions, maxDimentions));

            var maxX = createArea.Width + createArea.X - size.Width;
            var minX = createArea.X;
            var maxY = createArea.Height + createArea.Y - size.Height;
            var minY = createArea.Y;
            var postion = new Point(random.Next(minX, maxX), random.Next(minY, maxY));

            var color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));

            return (postion, size, color);
        }
    }
}