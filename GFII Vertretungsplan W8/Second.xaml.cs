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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GFII_Vertretungsplan_W8
{

    public sealed partial class SecondPage : Page
    {
        public SecondPage()
        {
            string device_id = "winDEV";
            this.InitializeComponent();
        }

        private void button5a_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "5a";
            App.Navigate2Main();
        }

        private void button5b_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "5b";
            App.Navigate2Main();
        }

        private void button5c_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "5c";
            App.Navigate2Main();
        }

        private void button6a_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "6a";
            App.Navigate2Main();
        }

        private void button6b_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "6b";
            App.Navigate2Main();
        }

        private void button6c_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "6c";
            App.Navigate2Main();
        }

        private void button7a_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "7a";
            App.Navigate2Main();
        }

        private void button7b_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "7b";
            App.Navigate2Main();
        }

        private void button7c_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "7c";
            App.Navigate2Main();
        }

        private void button8a_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "8a";
            App.Navigate2Main();
        }

        private void button8b_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "8b";
            App.Navigate2Main();
        }

        private void button8c_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "8c";
            App.Navigate2Main();
        }

        private void button9a_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "9a";
            App.Navigate2Main();
        }

        private void button9b_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "9b";
            App.Navigate2Main();
        }

        private void button9c_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "9c";
            App.Navigate2Main();
        }

        private void button10a_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "10a";
            App.Navigate2Main();
        }

        private void button10b_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "10b";
            App.Navigate2Main();
        }

        private void button10c_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "10c";
            App.Navigate2Main();
        }

        private void buttonKs1_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "Ks1";
            App.Navigate2Main();
        }

        private void buttonAll_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "Alle";
            App.Navigate2Main();
        }

        private void buttonKs2_Click(object sender, RoutedEventArgs e)
        {
            MainPage.klasse = "Ks2";
            App.Navigate2Main();
        }
        private async void textBlock_Copy_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var uriBing = new Uri(@"https://noscio.eu");

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uriBing);

            if (success)
            {
                // URI launched
            }
            else
            {
                // URI launch failed
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            double width = 0.25 * grid.ActualWidth;
            button5a.Width = width;
            button5b.Width = width;
            button5c.Width = width;
            button6a.Width = width;
            button6b.Width = width;
            button6c.Width = width;
            button7a.Width = width;
            button7b.Width = width;
            button7c.Width = width;
            button8a.Width = width;
            button8b.Width = width;
            button8c.Width = width;
            button9a.Width = width;
            button9b.Width = width;
            button9c.Width = width;
            button10a.Width = width;
            button10b.Width = width;
            button10c.Width = width;
            buttonKs1.Width = width;
            buttonAll.Width = width;
            buttonKs2.Width = width;
        }
    }
}
