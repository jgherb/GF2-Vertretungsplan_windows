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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static string klasse = "";
        public MainPage()
        {
            string device_id = "winDEV";
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            try
            {
                device_id = (string)localSettings.Values["device_id"];
                if (device_id.Length > 1)
                {

                }
                else
                {
                    Random random = new Random();
                    device_id = "win" + random.Next();
                    localSettings.Values["device_id"] = device_id;
                }
            }
            catch
            {
                Random random = new Random();
                device_id = "win" + random.Next();
                localSettings.Values["device_id"] = device_id;
            }
            this.InitializeComponent();
            string url = "https://noscio.eu/gf2/" + klasse + ".php?i=" + device_id + "&v=" + "0.1";
            Uri targetUri = new Uri(url);
            webView.Navigate(targetUri);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Navigate2Second();
        }
    }
}
