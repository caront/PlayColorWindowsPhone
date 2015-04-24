using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PlayTogether.Classes.Settings
{
    public class SettingsGame
    {
        public int timeStart;
        public int scoreMulti;
        public bool sound;
        public bool vibration;
        private Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

        public SettingsGame()
        {
            timeStart = 1000;
            scoreMulti = 5;
            sound = true;
            vibration = true;
        }

        private void print()
        {
            Debug.WriteLine("TimeStart : " + timeStart.ToString());
            Debug.WriteLine("ScoreMulti : " + scoreMulti.ToString());
            Debug.WriteLine("Sound : " + sound.ToString());
            Debug.WriteLine("Vib : " + vibration.ToString());
        }

        public void load()
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("TimeStart"))
            {
                timeStart = (int)(ApplicationData.Current.LocalSettings.Values["TimeStart"]);
            }
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("ScoreMulti"))
            {
                scoreMulti = (int)(ApplicationData.Current.LocalSettings.Values["ScoreMulti"]);
            }
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("Sound"))
            {
                sound = (bool)(ApplicationData.Current.LocalSettings.Values["Sound"]);
            }
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("Vib"))
            {
                vibration = (bool)(ApplicationData.Current.LocalSettings.Values["Vib"]);
            }
            Debug.WriteLine("Load Settings");
            print();
        }

        public SettingsGame(SettingsGame settings)
        {
            timeStart = settings.timeStart;
            scoreMulti = settings.scoreMulti;
            sound = settings.sound;
            vibration = settings.vibration;
        }

        public void upTime()
        {
            timeStart += 500;
            if (timeStart > 2000)
                timeStart = 500;
        }

        public void upScore()
        {
            scoreMulti += 1;
            if (scoreMulti > 10)
                scoreMulti = 5;
        }
        public void DownTime()
        {
            timeStart -= 500;
            if (timeStart < 500)
                timeStart = 2000;
        }

        public void DownScore()
        {
            scoreMulti -= 1;
            if (scoreMulti < 5)
                scoreMulti = 10;
        }
        
        public void Save()
        {
            ApplicationData.Current.LocalSettings.Values["TimeStart"] = timeStart;
            ApplicationData.Current.LocalSettings.Values["ScoreMulti"] = scoreMulti;
            ApplicationData.Current.LocalSettings.Values["Sound"] = sound;
            ApplicationData.Current.LocalSettings.Values["Vib"] = vibration;
            Debug.WriteLine("Save Settings");
            print();
        }

        public void Save(SettingsGame settings)
        {
            settings.scoreMulti = scoreMulti;
            settings.timeStart = timeStart;
            settings.sound = sound;
            settings.vibration = vibration;
        }
    }
}
