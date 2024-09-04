namespace Module02Exercise01.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (username == "admin" && password == "123")
            {
                try
                {
                    await Shell.Current.GoToAsync("//EmployeePage");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                }

            }
            else
            {
                await DisplayAlert("Login Failed", "Invalid username or password. The username is admin  and password is 123", "OK");
            }
        }

    }

}