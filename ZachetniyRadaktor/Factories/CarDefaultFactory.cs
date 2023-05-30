using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZachetniyRadaktor.Drawings;

namespace ZachetniyRadaktor.Factories
{
    internal class CarDefaultFactory : FigureDefaultFactory , IFactory<Car>
    {
        public CarDefaultFactory(System.Drawing.Rectangle createArea, int minDimentions, int maxDimentions) : base(createArea, minDimentions, maxDimentions) { }

        public Car Create()
        {
            Point postion; Size size; Color color;
            do
                (postion, size, color) = GenerateValues();
            while (size.Width < size.Height);
            return new(postion, size, color);
        }
    }
}
