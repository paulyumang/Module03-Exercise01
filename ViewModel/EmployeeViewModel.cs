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
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Employee> Managers { get; set; }
        public Command LoadEmployeeDataCommand { get; }

        private List<Employee> allEmployees; // To store the full list of employees, including managers
        private bool isManagerListVisible;

        public bool IsManagerListVisible
        {
            get => isManagerListVisible;
            set
            {
                if (isManagerListVisible != value)
                {
                    isManagerListVisible = value;
                    OnPropertyChanged(nameof(IsManagerListVisible));
                }
            }
        }

        public EmployeeViewModel()
        {
            // Initialize the full list of employees (with managers)
            allEmployees = new List<Employee>
        {
            new Employee { FirstName = "Paul", LastName = "Yumang", Department = "IT", Position = "Security Guard", IsActive = true },
            new Employee { FirstName = "Lhizel", LastName = "Tabual", Department = "IT", Position = "Teacher", IsActive = false },
            new Employee { FirstName = "John", LastName = "Doe", Department = "Management", Position = "Manager", IsActive = true }
        };

            // Initialize the observable collections
            Employees = new ObservableCollection<Employee>(allEmployees.Where(e => e.Position != "Manager"));
            Managers = new ObservableCollection<Employee>();

            // Hide managers by default
            IsManagerListVisible = false;

            // Command to load the managers when the button is pressed
            LoadEmployeeDataCommand = new Command(ShowManagers);
        }

        // Method to add only the managers to the Managers collection and show them
        private void ShowManagers()
        {
            // Add managers only if the list is currently hidden
            if (!IsManagerListVisible)
            {
                var managers = allEmployees.Where(e => e.Position == "Manager").ToList();

                foreach (var manager in managers)
                {
                    // Only add managers if they aren't already in the list
                    if (!Managers.Contains(manager))
                    {
                        Managers.Add(manager);
                    }
                }

                // Show the managers list
                IsManagerListVisible = true;
            }
        }

        // Standard implementation for INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
