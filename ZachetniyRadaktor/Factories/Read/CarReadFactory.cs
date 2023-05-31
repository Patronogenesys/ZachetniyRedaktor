using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZachetniyRadaktor.Drawings;

namespace ZachetniyRadaktor.Factories.Read
{
    internal class CarReadFactory : FigureReadFactory, IFactory<IEnumerable<Car>>
    {
        public CarReadFactory(string[] input) : base(input) { }

        public IEnumerable<Car> Create()
        {
            foreach (var s in input)
            {
                convert.FromString(s, out Car res);
                yield return res;
            }
        }
    }
}
