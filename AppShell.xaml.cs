
using Module02Exercise01.View;
namespace Module02Exercise01
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("EmployeePage", typeof(EmployeePage));
        }
    }
}
