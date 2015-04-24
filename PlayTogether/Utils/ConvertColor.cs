using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace PlayTogether.Utils
{
    class ConvertColor
    {
        internal static Color GetColorFromHex(string hexString)
        {
            if (hexString.StartsWith("#"))
            {
                hexString = hexString.Substring(1, 8);
            }
            var a = Convert.ToByte(Int32.Parse(hexString.Substring(0, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            var r = Convert.ToByte(Int32.Parse(hexString.Substring(2, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            var g = Convert.ToByte(Int32.Parse(hexString.Substring(4, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            var b = Convert.ToByte(Int32.Parse(hexString.Substring(6, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            return Color.FromArgb(a, r, g, b);
        }

        internal static string addToColor(string hexString, string add)
        {
            if (hexString.StartsWith("#"))
            {
                hexString = hexString.Substring(1, 8);
            }
            if (add.StartsWith("#"))
            {
                add = add.Substring(1, 8);
            }
            var a = Convert.ToByte(Int32.Parse(hexString.Substring(0, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            var r = Convert.ToByte(Int32.Parse(hexString.Substring(2, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            var g = Convert.ToByte(Int32.Parse(hexString.Substring(4, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            var b = Convert.ToByte(Int32.Parse(hexString.Substring(6, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            var aAdd = Convert.ToByte(Int32.Parse(add.Substring(0, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            var rAdd = Convert.ToByte(Int32.Parse(add.Substring(2, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            var gAdd = Convert.ToByte(Int32.Parse(add.Substring(4, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            var bAdd = Convert.ToByte(Int32.Parse(add.Substring(6, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            a += aAdd;
            r += rAdd;
            g += gAdd;
            b += bAdd;
            hexString = "#" + a.ToString() + r.ToString() + g.ToString() + b.ToString();
            return hexString;
        }
    }
}
