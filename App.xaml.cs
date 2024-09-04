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

        private const string TestUrl = "https://www.reqbin.com";

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            var current = Connectivity.NetworkAccess;
            bool isWebsiteReachable = await IsWebsiteReachable(TestUrl);

            if (current == NetworkAccess.Internet && isWebsiteReachable)
            {
                MainPage = new LoginPage();  // Navigate to LoginPage if online
            }
            else
            {
                MainPage = new OfflinePage();  // Navigate to OfflinePage if offline
            }
        }

        public async Task<bool> IsWebsiteReachable(string url) // Change this to public
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
