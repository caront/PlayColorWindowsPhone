using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PlayTogether.AppSettings
{
    public class AppSettings
    {
        protected ApplicationDataContainer localSettings { get; set; }

        public AppSettings()
        {
            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        }
    }
}
