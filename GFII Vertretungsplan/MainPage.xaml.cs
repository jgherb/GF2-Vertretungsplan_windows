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

namespace GFII_Vertretungsplan
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static string klasse = "";
        public static string version = "0.2";
        public static string device_id = "winDEV";
        public static Windows.Storage.ApplicationDataContainer localSettings;
        public MainPage()
        {
            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            try
            {
                device_id = (string)localSettings.Values["device_id"];
                if (device_id.Length > 1)
                {

                }
                else {
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
            updateURLs();
            //string url = SecurityValues.url_data_klasse + klasse + SecurityValues.url_data_id + device_id + SecurityValues.url_data_version + "0.1";
            string url = SecurityValues.url_data;
            url = url.Replace("@@device_id@@", device_id);
            url = url.Replace("@@klasse@@", klasse);
            url = url.Replace("@@version@@", version);
            Uri targetUri = new Uri(url);
            webView.Navigate(targetUri);
        }

        async void updateURLs()
        {
            String db_buffer = (string)localSettings.Values["url_update"];
            try
            {
                if (db_buffer.Length > 0)
                {
                    SecurityValues.url_update = db_buffer;
                }
            }
            catch{}
            db_buffer = "";
            db_buffer = (string)localSettings.Values["auth_url"];
            try
            {
                if (db_buffer.Length > 0)
                {
                    SecurityValues.auth_url = db_buffer;
                }
            }
            catch{}
            db_buffer = "";
            db_buffer = (string)localSettings.Values["url_data"];
            try
            {
                if (db_buffer.Length > 0)
                {
                    SecurityValues.url_data = db_buffer;
                }
            }
            catch{}
            db_buffer = "";
            db_buffer = (string)localSettings.Values["url_data_beta"];
            try
            {
                if (db_buffer.Length > 0)
                {
                    SecurityValues.url_data_beta = db_buffer;
                }
            }
            catch{}
            db_buffer = "";
            db_buffer = (string)localSettings.Values["url_reg"];
            try
            {
                if (db_buffer.Length > 0)
                {
                    SecurityValues.url_reg = db_buffer;
                }
            }
            catch{}

            //Create an HTTP client object
            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

            //Add a user-agent header to the GET request. 
            var headers = httpClient.DefaultRequestHeaders;

            //The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
            //especially if the header value is coming from user input.
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

            string url = SecurityValues.url_update;
            url = url.Replace("@@device_id@@", device_id);
            Uri requestUri = new Uri(url);

            //Send the GET request asynchronously and retrieve the response as a string.
            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                String[] arr = httpResponseBody.Split(new string[] { "!!!" }, StringSplitOptions.RemoveEmptyEntries);
                localSettings.Values["url_update"] = arr[0];
                localSettings.Values["url_data"] = arr[1];
                localSettings.Values["url_data_beta"] = arr[2];
                localSettings.Values["url_data_reg"] = arr[3];
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Navigate2Second();
        }
    }
}
