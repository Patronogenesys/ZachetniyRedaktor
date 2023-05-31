using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachetniyRadaktor.Factories.Read
{
    internal class RectangleReadFactory : FigureReadFactory, IFactory<IEnumerable<Drawings.Rectangle>>
    {
        public RectangleReadFactory(string[] input) : base(input) { }

        public IEnumerable<Drawings.Rectangle> Create()
        {
            foreach (var s in input)
            {
                convert.FromString(s, out Drawings.Rectangle res);
                yield return res;
            }
        }
    }
}
