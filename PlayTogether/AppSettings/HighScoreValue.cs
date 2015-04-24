using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.AppSettings
{
    public class HighScoreValue : AppSettings
    {
        private const string hightScoreKeyName = "HighScoreKeyName";

        private const int hightScoreDefaultValue = 0;

        public int higtScore
        {
            get
            {
                Debug.WriteLine("");
                object value = localSettings.Values[hightScoreKeyName];
                if (value == null)
                    return hightScoreDefaultValue;
                else
                    return Convert.ToInt32(value);
            }
            set
            {
                localSettings.Values[hightScoreKeyName] = value.ToString();
            }
        }

        public HighScoreValue()
            : base()
        {

        }
    }
}
