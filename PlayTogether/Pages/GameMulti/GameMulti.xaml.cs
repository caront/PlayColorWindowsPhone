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


namespace PlayTogether.Pages.GameMulti
{
    public sealed partial class GameMulti : Page
    {
        #region atribut
        private GameMultiCore game = new GameMultiCore();
        private DispatcherTimer timer = new DispatcherTimer();
        #endregion

        public GameMulti()
        {
            this.InitializeComponent();
            
            init();

        }

        #region init

        private void init()
        {
            newBlock();
            timer.Interval = TimeSpan.FromMilliseconds(game.time);
            timer.Tick += timer_Tick;
            timer.Start();
        }


        #endregion

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

        #region methode
        private void newBlock()
        {
            game.genColorList();
            BlockOnePlayerOne.Fill = new SolidColorBrush(game.getColor(0).color);
            BlockOnePlayerTwo.Fill = new SolidColorBrush(game.getColor(0).color);
            BlockTwoPlayerOne.Fill = new SolidColorBrush(game.getColor(1).color);
            BlockTwoPlayerTwo.Fill = new SolidColorBrush(game.getColor(1).color);
            ColorFindPlayerOne.Text = game.getColor(4).name;
            ColorFindPlayerTwo.Text = game.getColor(4).name;
            ColorDiplayPlayerOne.Fill = new SolidColorBrush(game.getColor(5).color);
            ColorDiplayPlayerTwo.Fill = new SolidColorBrush(game.getColor(5).color);
            ColorFindPlayerOne.Foreground = new SolidColorBrush(ConvertColor.GetColorFromHex("#FFFFFFFF"));
            ColorFindPlayerTwo.Foreground = new SolidColorBrush(ConvertColor.GetColorFromHex("#FFFFFFFF"));
            if (game.getColor(5).colorString == "#FFFFFFFF" || game.getColor(5).colorString == "#FFFFFF00" || game.getColor(5).colorString == "#FF66FFFF")
            {
                ColorFindPlayerOne.Foreground = new SolidColorBrush(ConvertColor.GetColorFromHex("#FF000000"));
                ColorFindPlayerTwo.Foreground = new SolidColorBrush(ConvertColor.GetColorFromHex("#FF000000"));
            }
            LifePtrPlayerOne.Text = game.lifeOne.ToString() + " / " + App.settingsGame.scoreMulti.ToString();
            LifePtrPlayerTwo.Text = game.lifeTwo.ToString() + " / " + App.settingsGame.scoreMulti.ToString();
        }
        private void timer_Tick(object sender, object e)
        {
            newBlock();
        }

        private void check(int id, int player)
        {
            if (player == 0)
            {
                if (game.checkBlokc(id, 0))
                {
                    if (App.settingsGame.sound)
                        CorrectSound.Play();
                    CorrectAnnimOne.Begin();
                }
                else
                {
                    if (App.settingsGame.sound)
                        WrongSound.Play();
                    CWrongAnnimOne.Begin();
                }
            }
            if (player == 1)
            {
                if (game.checkBlokc(id, 1))
                {
                    if (App.settingsGame.sound)
                        CorrectSound.Play();
                    CorrectAnnimTwo.Begin();
                }
                else
                {
                    if (App.settingsGame.sound)
                        WrongSound.Play();
                    CWrongAnnimTwo.Begin();
                }
            }
        }

        private void checkWin()
        {
            if (game.lifeOne >= App.settingsGame.scoreMulti)
                winOne();
            else if (game.lifeTwo >= App.settingsGame.scoreMulti)
                winTwo();
        }

        private void winOne()
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            rectOne.Fill = new SolidColorBrush(ConvertColor.GetColorFromHex("#FF66FF33"));
            textOne.Text = loader.GetString("Win"); 
            textOne.Foreground = new SolidColorBrush(ConvertColor.GetColorFromHex("#FFFFFFFF"));
            rectTwo.Fill = new SolidColorBrush(ConvertColor.GetColorFromHex("#FFFF0000"));
            textTwo.Text = loader.GetString("Lose");
            textTwo.Foreground = new SolidColorBrush(ConvertColor.GetColorFromHex("#FFFFFFFF"));
            EndGridOne.Visibility = Visibility.Visible;
            EndGridTwo.Visibility = Visibility.Visible;
        }

        private void winTwo()
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
          
            rectTwo.Fill = new SolidColorBrush(ConvertColor.GetColorFromHex("#FF66FF33"));
            textTwo.Text = loader.GetString("Win"); 
            textTwo.Foreground = new SolidColorBrush(ConvertColor.GetColorFromHex("#FFFFFFFF"));
            rectOne.Fill = new SolidColorBrush(ConvertColor.GetColorFromHex("#FFFF0000"));
            textOne.Text = loader.GetString("Lose");
            textOne.Foreground = new SolidColorBrush(ConvertColor.GetColorFromHex("#FFFFFFFF"));
            EndGridOne.Visibility = Visibility.Visible;
            EndGridTwo.Visibility = Visibility.Visible;
        }
        #endregion

        #region navigation
        
        #endregion

        #region callback
        private void BlockOnePlayerOne_Tapped(object sender, TappedRoutedEventArgs e)
        {
            check(0, 0);
            checkWin();
        }

        private void BlockTwoPlayerOne_Tapped(object sender, TappedRoutedEventArgs e)
        {
            check(1, 0);
            checkWin();
        }

        private void BlockOnePlayerTwo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            check(0, 1);
            checkWin();
        }

        private void BlockTwoPlayerTwo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            check(1, 1);
            checkWin();
        }

        private void EndGridOne_Tapped(object sender, TappedRoutedEventArgs e)
        {
            timer.Stop();
            Frame.GoBack();
        }

        private void EndGridTwo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            timer.Stop();
            Frame.GoBack();
        }

        private void PauseGridOne_Tapped(object sender, TappedRoutedEventArgs e)
        {
            check(0, 1);
            checkWin();
        }
        #endregion
    }
}
