using Microsoft.Maui.Controls;
using Microsoft.Maui.Networking; // Corrected namespace
using System.Net.Http;
using System.Threading.Tasks;
using Module02Exercise01.View; // Add this to resolve LoginPage and OfflinePage

namespace Module02Exercise01
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await CheckConnectivityAsync();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            Console.WriteLine("The app is in sleep mode.");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Console.WriteLine("The app has resumed.");
        }

        public async Task CheckConnectivityAsync()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                // Ping a webpage to confirm internet availability
                if (await PingWebsiteAsync("https://reqbin.com"))
                {
                    MainPage = new LoginPage();
                }
                else
                {
                    MainPage = new OfflinePage();
                }
            }
            else
            {
                MainPage = new OfflinePage();
            }
        }

        private async Task<bool> PingWebsiteAsync(string url)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(url);
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
