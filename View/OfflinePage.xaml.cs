using Microsoft.Maui.Controls;


namespace Module02Exercise01.View
{
    public partial class OfflinePage : ContentPage
    {
        public OfflinePage()
        {
            InitializeComponent();
        }

        private async void OnRetryClicked(object sender, EventArgs e)
        {
            // Access the IsWebsiteReachable and Connectivity check from App class
            var current = Connectivity.NetworkAccess;
            bool isWebsiteReachable = await ((App)Application.Current).IsWebsiteReachable("\"https://www.example.com");

            if (current == NetworkAccess.Internet && isWebsiteReachable)
            {
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                // Stay on OfflinePage
                await DisplayAlert("Connection Failed", "Still no internet connection.", "OK");
            }
        }

        private void OnCloseClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}