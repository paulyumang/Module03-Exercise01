using Microsoft.Maui.Controls;
using Microsoft.Maui.Networking; // Corrected namespace
using System.Net.Http;
using System.Threading.Tasks;
using Module02Exercise01.View; // Add this to resolve LoginPage and OfflinePage
using System.Diagnostics;


namespace Module02Exercise01
{
    public partial class App : Application
    {
        private const string TestUrl = "https://www.example.com";

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            // base.OnStart(); // No need to call base for OnStart in MAUI

            var current = Connectivity.NetworkAccess;
            bool isWebsiteReachable = await IsWebsiteReachable(TestUrl);

            if (current == NetworkAccess.Internet && isWebsiteReachable)
            {
                await Shell.Current.GoToAsync("//LoginPage");
                Debug.WriteLine("Application Started (Online)");
            }
            else
            {
                await Shell.Current.GoToAsync("//OfflinePage");
                Debug.WriteLine("Application Started (Offline)");
            }
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("Application Sleeping");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("Application Resumed");
        }

        // Change the access modifier from private to public
        public async Task<bool> IsWebsiteReachable(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}