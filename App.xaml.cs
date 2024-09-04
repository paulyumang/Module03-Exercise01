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
        private const string TestUrl = "https://www.github.com";

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            // Check network access
            var current = Connectivity.NetworkAccess;

            // Detailed logging
            Debug.WriteLine($"Network Access: {current}");

            bool isWebsiteReachable = await IsWebsiteReachable(TestUrl);

            // Check if both network access and website reachability are good
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

        // Updated method to handle exceptions and connectivity checks more robustly
        private async Task<bool> IsWebsiteReachable(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0");
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
