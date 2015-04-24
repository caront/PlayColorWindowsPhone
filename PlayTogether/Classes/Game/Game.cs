using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTogether.Classes.ColorGame;
using System.Diagnostics;
using Windows.Phone.Devices.Notification;
using Windows.UI.Xaml.Controls;

namespace PlayTogether.Classes.Game
{
    public class Game
    {
        public bool onPlay;
        private int round;
        private VibrationDevice vibrationDevice;
        private int _time;
        private int CurColorId;
        private int displayNameColorId;
        private List<int> blockId;
        private Random random = new Random();
        private ColorGame.ColorGameList colorList = new ColorGame.ColorGameList();
        public int score;
        public int time
        {
            get
            {
                return _time;
            }
            set
            {
                if (value >= 50)
                    _time = value;
            }
        }

        public Game()
        {
            score = 0;
            time = App.settingsGame.timeStart;
            CurColorId = 0;
            displayNameColorId = 0;
            blockId = new List<int>();
            blockId.Add(1);
            blockId.Add(1);
            blockId.Add(1);
            blockId.Add(1);
            vibrationDevice = VibrationDevice.GetDefault();
            onPlay = true;
            round = 0;
            genCurColor();
        }

        #region PrivateMethode
        private int getRandColor()
        {
            return random.Next(0, 10);
        }
        private void genColor(int id)
        {
            if (id == 4)
            {
                displayNameColorId = getRandColor();
                return;
            }
            blockId[id] = getRandColor();

        }
        private void print()
        {
            int j = 0;
            Debug.WriteLine("curColor = " + CurColorId.ToString());
            Debug.WriteLine("displayColor = " + displayNameColorId.ToString());
            foreach (int i in blockId)
            {
                Debug.WriteLine("id[" + j.ToString() + "] = " + i.ToString());
                j++;
            }
        }

        private bool isInList()
        {
            for (int i = 0; i < 4; i++)
            {
                if (blockId[i] == CurColorId)
                    return true;
            }
            return false;
        }
        #endregion

        #region publicMethode
        public void restart()
        {
            score = 0;
            round = 0;
            time = App.settingsGame.timeStart;
            blockId[0] = 0;
            blockId[1] = 0;
            blockId[2] = 0;
            blockId[3] = 0;
            CurColorId = 0;
            genCurColor();
            displayNameColorId = 0;
            onPlay = true;
        }

        public void genColorList()
        {
            Debug.WriteLine("genColorList");
            for (int i = 0; i < 4; i++)
            {
                blockId[i] = random.Next(0, 10);
            }
            blockId[0] = random.Next(0, 10);
            while (blockId[1] == blockId[0])
                blockId[1] = random.Next(0, 10);
            while (blockId[2] == blockId[0] || blockId[2] == blockId[1])
                blockId[2] = random.Next(0, 10);
            while (blockId[3] == blockId[0] || blockId[3] == blockId[1] || blockId[3] == blockId[2])
                blockId[3] = random.Next(0, 10);
            while (displayNameColorId == CurColorId || displayNameColorId == blockId[0])
                displayNameColorId = random.Next(0, 10);
            round++;
            if (round >= 4 && !isInList())
            {
                round = 0;
                blockId[random.Next(0, 4)] = CurColorId;
            }
            print();
        }

        public void genCurColor()
        {
            CurColorId = random.Next(0, 10);
        }

        public ColorGame.ColorGame getColor(int id)
        {
            if (id == 4)
                return colorList.list[displayNameColorId];
            if (id == 5)
                return colorList.list[CurColorId];
            return colorList.list[blockId[id]];
        }

        public bool checkBlokc(int id)
        {
            if (blockId[id] == CurColorId)
            {
                score++;
                time -= 10;
                genCurColor();
                if (App.settingsGame.vibration)
                    vibrationDevice.Vibrate(TimeSpan.FromMilliseconds(500));
                return true;
            }
            return false;
        }

        #endregion
    }
}
