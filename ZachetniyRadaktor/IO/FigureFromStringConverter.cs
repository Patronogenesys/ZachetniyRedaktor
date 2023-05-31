using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZachetniyRadaktor.Drawings;

namespace ZachetniyRadaktor.IO
{
    internal class FigureFromStringConverter :
        IFromStringConverter<Drawings.Rectangle>, IFromStringConverter<Ellipse>, IFromStringConverter<Car>,
        IFromStringConverter<Point>, IFromStringConverter<Color>
    {

        // "(position) (size) (color)"
        public bool FromString(string str, out Drawings.Rectangle? result)
        {
            result = null;
            var results = str.Split();
            if (!FromString(results[0], out Point position)) return false;
            if (!FromString(results[1], out Point sizeTmp)) return false;
            if (!FromString(results[2], out Color color)) return false;
            if (!bool.TryParse(results[3].Replace("(", "").Replace(")", ""), out bool isEnabled)) return false;

            Size size = new Size(sizeTmp);
            result = new(position, size, color, isEnabled);
            return true;
        }

        // "(position) (size) (color)"
        public bool FromString(string str, out Ellipse? result)
        {
            result = null;
            var results = str.Split();
            if (!FromString(results[0], out Point position)) return false;
            if (!FromString(results[1], out Point sizeTmp)) return false;
            if (!FromString(results[2], out Color color)) return false;
            //var a = bool.TryParse(results[3].Replace("(", "").Replace(")", ""), out _);
            if (!bool.TryParse(results[3].Replace("(", "").Replace(")", ""), out bool isEnabled)) return false;

            Size size = new Size(sizeTmp);
            result = new(position, size, color, isEnabled);
            return true;
        }

        // "(position) (size) (color) (colorTop) (colorMiddle) (colorLeft) (colorRight)"
        public bool FromString(string str, out Car? result)
        {
            result = null;
            var results = str.Split();
            if (!FromString(results[0], out Point position)) return false;
            if (!FromString(results[1], out Point sizeTmp)) return false;
            if (!FromString(results[2], out Color color)) return false;
            if (!FromString(results[3], out Color colorTop)) return false;
            if (!FromString(results[4], out Color colorMiddle)) return false;
            if (!FromString(results[5], out Color colorLeft)) return false;
            if (!FromString(results[6], out Color colorRight)) return false;
            if (!bool.TryParse(results[7].Replace("(", "").Replace(")", ""), out bool isEnabled)) return false;

            Size size = new Size(sizeTmp);
            result = new(position, size, color, colorTop, colorMiddle, colorLeft, colorRight, isEnabled);
            return true;
        }
        // "(x,y)"
        public bool FromString(string str, out Point result)
        {
            result = Point.Empty;
            var results = str.Replace("(", "").Replace(")", "").Split(",");
            if (!int.TryParse(results[0], out int x)) return false;
            if (!int.TryParse(results[1], out int y)) return false;

            result = new(x, y);
            return true;
        }

        // "(a,r,g,b)"
        public bool FromString(string str, out Color result)
        {
            result = Color.Black;
            var results = str.Replace("(", "").Replace(")", "").Split(",");
            if (!int.TryParse(results[0], out int a)) return false;
            if (!int.TryParse(results[1], out int r)) return false;
            if (!int.TryParse(results[2], out int g)) return false;
            if (!int.TryParse(results[3], out int b)) return false;

            result = Color.FromArgb(a, r, g, b);
            return true;
        }
    }
}
