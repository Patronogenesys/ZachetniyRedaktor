using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZachetniyRadaktor.Drawings;
using ZachetniyRadaktor.IO;

namespace ZachetniyRadaktor.Factories.Read
{
    internal abstract class FigureReadFactory
    {
        protected readonly string[] input;
        protected readonly FigureFromStringConverter convert = new();
        public FigureReadFactory(string[] input)
        {
            this.input = input;
        }

    }
}
