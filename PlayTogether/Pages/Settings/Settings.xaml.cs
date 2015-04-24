using PlayTogether.Classes.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PlayTogether.Pages.Settings
{
    public sealed partial class Settings : Page
    {
        #region attributs

        private SettingsGame settingsGame = new SettingsGame(App.settingsGame);

        #endregion

        public Settings()
        {
            this.InitializeComponent();
            init();
        }

        #region init

        private void init()
        {
            TimeStartText.Text = ((double)settingsGame.timeStart / 1000.0).ToString() + " Seconds";
            NbrColorText.Text = settingsGame.scoreMulti.ToString() + " Points";
            if (settingsGame.sound)
                soundText.Text = "On";
            else
                soundText.Text = "Off";
            if (settingsGame.vibration)
                vibText.Text = "On";
            else
                vibText.Text = "Off";
        }

        #endregion

        #region navigation
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

        private void Title_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
        private void timeStartUp(object sender, TappedRoutedEventArgs e)
        {
            settingsGame.upTime();
            init();
        }
        private void timeStartDown(object sender, TappedRoutedEventArgs e)
        {
            settingsGame.DownTime();
            init();
        }

        private void scoreStartUp(object sender, TappedRoutedEventArgs e)
        {
            settingsGame.upScore();
            init();
        }
        private void scoreStartDown(object sender, TappedRoutedEventArgs e)
        {
            settingsGame.DownScore();
            init();
        }

        private void Save_Tapped(object sender, RoutedEventArgs e)
        {
            settingsGame.Save(App.settingsGame);
            App.settingsGame.Save();
            Frame.GoBack();
        }

        private void Cancel_Tapped(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        #endregion

        private void SoundGrid_Tapped(object sender, RoutedEventArgs e)
        {
            settingsGame.sound = !settingsGame.sound;
            init();
        }

        private void VibrationGrid_Tapped(object sender, RoutedEventArgs e)
        {
            settingsGame.vibration = !settingsGame.vibration;
            init();
        }
    }
}
