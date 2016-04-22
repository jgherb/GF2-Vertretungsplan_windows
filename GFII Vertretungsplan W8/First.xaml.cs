using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace GFII_Vertretungsplan_W8
{

    public sealed partial class FirstPage : Page
    {
        public FirstPage()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            //Wenn auf den Fertig-Button gedrückt wird, wird das Passwort zur Überprüfung an den Server geschickt
            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();
            var headers = httpClient.DefaultRequestHeaders;
            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }
            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }
            //Adresse für den Server (daran wird das Passwort angehängt)
            Uri requestUri = new Uri("https://noscio.eu/gf2_auth.php?p="+passwordBox.Password);
            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
            string httpResponseBody = "";
            try
            {
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
            //Es wird geprüft, ob die Antwort vom Server "true" ist (somit wäre das Passwort richtig)
            if(httpResponseBody.Contains("true"))
            {
                //Wenn das so ist, wird die 2. Seite aufgerufen (Die mit der Klassenauswahl)
                App.Navigate2Second();
            }
        }

        private async void textBlock_Copy_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Wenn man auf den Noscio-Schriftzug tippt, wird die Noscio-Website aufgerufen
            var uriBing = new Uri(@"https://noscio.eu");
            var success = await Windows.System.Launcher.LaunchUriAsync(uriBing);
        }
    }
}
