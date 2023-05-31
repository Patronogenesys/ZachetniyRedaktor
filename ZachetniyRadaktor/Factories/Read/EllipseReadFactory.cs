using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZachetniyRadaktor.Drawings;

namespace ZachetniyRadaktor.Factories.Read
{
    internal class EllipseReadFactory : FigureReadFactory, IFactory<IEnumerable<Ellipse>>
    {
        public EllipseReadFactory(string[] input) : base(input) { }

        public IEnumerable<Ellipse> Create()
        {
            foreach (var s in input)
            {
                convert.FromString(s, out Ellipse res);
                yield return res;
            }
        }
    }
}
