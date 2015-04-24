using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.Classes.ColorGame
{
    public class ColorGameList
    {
        public List<ColorGame> list;
        

        public ColorGameList()
        {
            list = new List<ColorGame>();
            list.Add(new Blue());
            list.Add(new Brown());
            list.Add(new Green());
            list.Add(new Orange());
            list.Add(new Pink());
            list.Add(new Red());
            list.Add(new Violet());
            list.Add(new White());
            list.Add(new Yellow());
            list.Add(new Sky());
        }
    }
}
