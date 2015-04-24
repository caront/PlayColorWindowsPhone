using PlayTogether.Pages.HighScore;
using PlayTogether.Pages.NewGame;
using PlayTogether.Pages.Settings;
using PlayTogether.Pages.Test;
using PlayTogether.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PlayTogether
{
    public sealed partial class MainPage : Page
    {

        #region attribut
        #endregion
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        #region init
        #endregion

        #region navigation
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
        #endregion

        #region callback
        private void Title_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void NewGame_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewGamePage));
        }

        private void HightScore_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(HigtScore));
        }

        private void Settings_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Settings));
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewGamePage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HigtScore));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Settings));
        }
    }
}
