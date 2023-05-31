using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachetniyRadaktor.IO
{
    internal interface IFromStringConverter<T>
    {
        bool FromString(string str, out T? result);
    }
}
