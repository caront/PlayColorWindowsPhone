using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PlayTogether.Pages.GameSolo;
using Windows.Phone.UI.Input;
using System.Diagnostics;


namespace PlayTogether.Pages.NewGame
{
    public sealed partial class NewGamePage : Page
    {
        public NewGamePage()
        {
            this.InitializeComponent();
        }

        private void go_back_button(object sender, BackPressedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

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

        #region callback
        private void title_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void Solo_Tapped(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GameSolo.GameSolo));
        }

        private void Multi_Tapped(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GameMulti.GameMulti));
        }

        private void goBack_Tapped(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        #endregion

        private void AdControl_ErrorOccurred(object sender, Microsoft.Advertising.Mobile.Common.AdErrorEventArgs e)
        {
            Debug.WriteLine("AdControl error: " + e.Error.Message);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
