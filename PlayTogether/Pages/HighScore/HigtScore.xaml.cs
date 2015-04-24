using PlayTogether.Classes.HigtScore;
using PlayTogether.Utils;
using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Shapes;

namespace PlayTogether.Pages.HighScore
{
    public sealed partial class HigtScore : Page
    {
        public HigtScore()
        {
            this.InitializeComponent();
            init();
        }

        private void init()
        {
            App.hS.setColor();
            if (App.hS.list.Count() >= 1)
                setResult(text1, App.hS.list[0]);
            if (App.hS.list.Count() >= 2)
                setResult(text2, App.hS.list[1]);
            if (App.hS.list.Count() >= 3)
                setResult(text3, App.hS.list[2]);
            
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

        private void setResult(TextBlock textblock, Score score)
        {
            textblock.Text = score.value.ToString() + " point";
            textblock.FontSize = score.size;
            if (score.value == 1)
                textblock.Text = "1 point";
            else if (score.value == 0)
                textblock.Text = "";
        }
    }
}
