using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module02Exercise01.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Module02Exercise01.ViewModel
{ 
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        //Role of ViewModel
        private Employee _employee;
        private string _fullname; //variable to combine the FirstName and LastName into one, using Conversion

        public EmployeeViewModel()
        {
            _employee = new Employee { FirstName = "John", LastName = "Doe", Department = "IT", Position = "Manager"};

            LoadEmployeeDataCommand = new Command(async () => await LoadEmployeeDataAsync());

            Employees = new ObservableCollection<Employee>
            {
                new Employee { FirstName = "Paul", LastName = "Yumang", Department = "IT", Position = "Security Guard", IsActive = true },
                new Employee { FirstName = "Lhizel", LastName = "Tabual", Department = "IT", Position = "Teacher", IsActive = false }
            };
        }

        public ObservableCollection<Employee> Employees { get; set; }

        public string FullName
        {
            get => _fullname;
            set
            {
                if (_fullname != value)
                {
                    _fullname = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public ICommand LoadEmployeeDataCommand { get; }

        private async Task LoadEmployeeDataAsync()
        {
            await Task.Delay(1000); // I/O operation
            FullName = $"{_employee.FirstName} {_employee.LastName}"; //Data Conversion for FirstName and LastName

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
