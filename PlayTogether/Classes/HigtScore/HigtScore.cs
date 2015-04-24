using PlayTogether.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Storage;

namespace PlayTogether.Classes.HigtScore
{
    public class HigtScore
    {
        private Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        public List<Score> list;

        public HigtScore()
        {
            list = new List<Score>();
            list.Add(new Score(0));
            list.Add(new Score(0));
            list.Add(new Score(0));
            list.Add(new Score(0));
            list.Add(new Score(0));
            list.Add(new Score(0));
        }

        private bool isMost(int score)
        {
            foreach (Score s in list)
            {
                if (s.value < score)
                    return true;
            }
            return false;
        }

        public void add(int score)
        {

            list.Add(new Score(score));
            list = list.OrderByDescending(ex => ex.value).ToList();
        }

        public void load()
        {
            Debug.WriteLine("Load HS");
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("First"))
            {
                newLoad();
            }
            else
            {
                oldLoad();
            }
        }

        public async void oldLoad()
        {
            try
            {
                StorageFile sampleFile = await localFolder.GetFileAsync("HigtScore.txt");
                String timestamp = await FileIO.ReadTextAsync(sampleFile);
                Debug.WriteLine("content : " + timestamp);
                string[] splinter = timestamp.Split(new Char[] { ' ' });
                foreach (string s in splinter)
                {
                    if (s != " ")
                        add(Convert.ToInt32(s));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void newLoad()
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("value1"))
            {
                add((int)(ApplicationData.Current.LocalSettings.Values["value1"]));
            }
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("value2"))
            {
                add((int)(ApplicationData.Current.LocalSettings.Values["value2"]));
            }
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("value3"))
            {
                add((int)(ApplicationData.Current.LocalSettings.Values["value3"]));
            }
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("value4"))
            {
                add((int)(ApplicationData.Current.LocalSettings.Values["value4"]));
            }
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("value5"))
            {
                add((int)(ApplicationData.Current.LocalSettings.Values["value5"]));
            }
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("value6"))
            {
                add((int)(ApplicationData.Current.LocalSettings.Values["value6"]));
            }
        }

        public void save()
        {
            ApplicationData.Current.LocalSettings.Values["First"] = 0;
            ApplicationData.Current.LocalSettings.Values["value1"] = list[0].value;
            ApplicationData.Current.LocalSettings.Values["value2"] = list[1].value;
            ApplicationData.Current.LocalSettings.Values["value3"] = list[2].value;
            ApplicationData.Current.LocalSettings.Values["value4"] = list[3].value;
            ApplicationData.Current.LocalSettings.Values["value5"] = list[4].value;
            ApplicationData.Current.LocalSettings.Values["value6"] = list[5].value;
        }

        public void remove()
        {
            try
            {
                foreach (Score s in list)
                {
                    list.Remove(s);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void setColor()
        {
            int size = 40;

            foreach (Score s in list)
            {
                s.size = size;
                size -= 3;
            }
        }
    }
}
