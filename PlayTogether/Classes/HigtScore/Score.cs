using PlayTogether.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace PlayTogether.Classes.HigtScore
{
    public class Score
    {
        public int value;
        public int size;
        public DateTime time;
        public SolidColorBrush color;

        public Score(int value)
        {
            this.value = value;
        }

        public void setColor(string hexa)
        {
            this.color = new SolidColorBrush(ConvertColor.GetColorFromHex(hexa));
        }

    }
}
