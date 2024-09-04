namespace Module02Exercise01.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();  // This method is generated during XAML compilation
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string enteredUsername = UsernameEntry.Text;
            string enteredPassword = PasswordEntry.Text;

            if (enteredUsername == "admin" && enteredPassword == "password123")
            {
                await Navigation.PushAsync(new EmployeePage());
            }
            else
            {
                ErrorMessage.Text = "Invalid username or password. Please try again.";
                ErrorMessage.IsVisible = true;
            }
        }
    }
}