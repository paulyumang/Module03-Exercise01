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
            await ((App)Application.Current).CheckConnectivityAsync();
        }

        private void OnCloseClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}