using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Phone.Devices.Notification;

namespace PlayTogether.Classes.Game
{
    public class GameMultiCore
    {
        #region atribut

        private int _lifeOne;
        private int _lifeTwo;
        private int round;
        private VibrationDevice vibrationDevice;
        private int _time;
        private int CurColorId;
        private int displayNameColorId;
        private List<int> blockId;
        private Random random = new Random();
        private ColorGame.ColorGameList colorList = new ColorGame.ColorGameList();
        public int lifeOne
        {
            get
            {
                return _lifeOne;
            }
            set
            {
                if (value >= 0)
                    _lifeOne = value;
            }
        }
        public int lifeTwo
        {
            get
            {
                return _lifeTwo;
            }
            set
            {
                if (value >= 0)
                    _lifeTwo = value;
            }
        }

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
        public bool onPlay;
        #endregion

        public GameMultiCore()
        {
            lifeOne = 0;
            lifeTwo = 0;
            time = App.settingsGame.timeStart;
            blockId = new List<int>();
            blockId.Add(0);
            blockId.Add(0);
            CurColorId = 0;
            displayNameColorId = 0;
            vibrationDevice = VibrationDevice.GetDefault();
            genCurColor();
        }

        #region privateMethode
        private void print()
        {
            Debug.WriteLine("Round : " + round.ToString());
            Debug.WriteLine("CurColor : " + CurColorId.ToString());
            Debug.WriteLine("DisplayColor : " + displayNameColorId.ToString());
            Debug.WriteLine("Color [0] = " + blockId[0].ToString());
            Debug.WriteLine("Color [1] = " + blockId[1].ToString());
        }
        private int getRandColor()
        {
            return random.Next(0, 10);
        }
        private bool isInList()
        {
            for (int i = 0; i < 2; i++)
            {
                if (blockId[i] == CurColorId)
                    return true;
            }
            return false;
        }

        #endregion

        #region publicMethode
        public void genCurColor()
        {
            CurColorId = getRandColor();
        }
        public void init()
        {
            lifeOne = 0;
            lifeTwo = 0;
            displayNameColorId = 0;
            CurColorId = 0;
            blockId[0] = 0;
            blockId[0] = 0;
            time = App.settingsGame.timeStart;
            genCurColor();
        }
        public void genColorList()
        {
            blockId[0] = getRandColor();
            blockId[1] = getRandColor();
            displayNameColorId = getRandColor();
            while (blockId[1] == blockId[0])
                blockId[1] = getRandColor();
            round++;
            if (round >= 4 && !isInList())
            {
                round = 0;
                blockId[random.Next(0, 2)] = CurColorId;
            }
            print();
        }
        public ColorGame.ColorGame getColor(int id)
        {
            if (id == 4)
                return colorList.list[CurColorId];
            else if (id == 5)
                return colorList.list[displayNameColorId];
            else if (id == 0)
                return colorList.list[blockId[0]];
            else
                return colorList.list[blockId[1]];
        }
        public bool checkBlokc(int id, int player)
        {
            if (blockId[id] == CurColorId)
            {
                time -= 10;
                if (App.settingsGame.vibration)
                    vibrationDevice.Vibrate(TimeSpan.FromMilliseconds(500));
                genCurColor();
                if (player == 0)
                    lifeOne++;
                else
                    lifeTwo++;
                return true;
            }
            if (player == 0)
                lifeOne--;
            else
                lifeTwo--;
            return false;
        }
        #endregion
    }
}
