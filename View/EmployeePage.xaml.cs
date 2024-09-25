namespace Module02Exercise01.View;
using Module02Exercise01.ViewModel;
using System.Threading.Tasks;

public partial class EmployeePage : ContentPage
{
	public EmployeePage()
	{
		InitializeComponent();
        BindingContext = new EmployeeViewModel();
    }
	
	private async void GoToAddEmployee(Object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("//AddEmployee");
    }
}