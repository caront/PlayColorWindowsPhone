using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using PlayTogether.Utils;
using System.Resources;

namespace PlayTogether.Classes.ColorGame
{
    public class ColorGame
    {
        private Color _color;
        private string _name;

        public Color color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public string name 
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != "")
                    _name = value;
            }
        }
        public string colorString { get; private set; }


        public ColorGame(string colorString, string name)
        {
            
            color = ConvertColor.GetColorFromHex(colorString);
            this.colorString = colorString;
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            string result = loader.GetString(name);
            this.name = result;
        }
    }
}
