using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZachetniyRadaktor.Drawings;

namespace ZachetniyRadaktor.Factories
{
    internal class EllipseDefaultFactory : FigureDefaultFactory, IFactory<Ellipse>
    {
        public EllipseDefaultFactory(System.Drawing.Rectangle createArea, int minDimentions, int maxDimentions) : base(createArea, minDimentions, maxDimentions) { }

        public Ellipse Create()
        {
            (Point postion, Size size, Color color) = GenerateValues();
            return new(postion, size, color);
        }
    }
}
