using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZachetniyRadaktor.Drawings;

namespace ZachetniyRadaktor.Factories
{
    internal class RectangleDefaultFactory : FigureDefaultFactory, IFactory<Drawings.Rectangle>
    {
        public RectangleDefaultFactory(System.Drawing.Rectangle createArea, int minDimentions, int maxDimentions) : base(createArea, minDimentions, maxDimentions) { }

        public Drawings.Rectangle Create()
        {
            (Point postion, Size size, Color color) = GenerateValues();
            return new(postion, size, color);
        }
    }
}
