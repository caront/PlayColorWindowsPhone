using PlayTogether.Classes.ColorGame;
using PlayTogether.Classes.Game;
using PlayTogether.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace PlayTogether.Pages.GameSolo
{
    public sealed partial class GameSolo : Page
    {
        private DispatcherTimer timer = new DispatcherTimer();

        public GameSolo()
        {
            this.InitializeComponent();
            init();
        }

        #region init

        private void init()
        {

            App.game.restart();
            App.game.genCurColor();
            newBlock();
            timer.Interval = TimeSpan.FromMilliseconds(App.game.time);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        #endregion

        #region methode

        void timer_Tick(object sender, object e)
        {
            newBlock();
            recPoint.Opacity = 0;
        }

        private void check(int id)
        {
            if (App.game.checkBlokc(id) == false)
            {
                timer.Stop();
                if (App.settingsGame.sound)
                    WrongSound.Play();
                Frame.Navigate(typeof(EndGame.EndGame));
            }
            else
            {
                if (App.settingsGame.sound)
                    CorrectSound.Play();
                CorrectAnnim.Begin();
                timer.Stop();
                timer.Interval = TimeSpan.FromMilliseconds(App.game.time);
                timer.Start();
                newBlock();
            }
        }
        private void newBlock()
        {
            App.game.genColorList();
            BlockA.Fill = new SolidColorBrush(App.game.getColor(0).color);
            BlockB.Fill = new SolidColorBrush(App.game.getColor(1).color);
            BlockC.Fill = new SolidColorBrush(App.game.getColor(2).color);
            BlockD.Fill = new SolidColorBrush(App.game.getColor(3).color);
            ColorToFind.Text = App.game.getColor(5).name;
            ColorRectangle.Fill = new SolidColorBrush(App.game.getColor(4).color);
            ColorToFind.Foreground = new SolidColorBrush(ConvertColor.GetColorFromHex("#FFFFFFFF"));
            if (App.game.getColor(4).colorString == "#FFFFFFFF" || App.game.getColor(4).colorString == "#FFFFFF00" || App.game.getColor(4).colorString == "#FF66FFFF")
                ColorToFind.Foreground = new SolidColorBrush(ConvertColor.GetColorFromHex("#FF000000"));
            Score.Text = App.game.score.ToString();
        }

        #endregion

        #region Navigation
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null && rootFrame.CanGoBack)
            {
                rootFrame.Navigate(typeof(MainPage));
                e.Handled = true;
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
        }

        #endregion

        #region callback

        private void BlockA_Tapped(object sender, TappedRoutedEventArgs e)
        {
            check(0);
        }

        private void BlockB_Tapped(object sender, TappedRoutedEventArgs e)
        {
            check(1);
        }

        private void BlockC_Tapped(object sender, TappedRoutedEventArgs e)
        {
            check(2);
        }

        private void BlockD_Tapped(object sender, TappedRoutedEventArgs e)
        {
            check(3);
        }

      
        #endregion

        private void Sound_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Debug.WriteLine("Media Failed");
            Debug.WriteLine(e.ErrorMessage);
        }
    }
}
