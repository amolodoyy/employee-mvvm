using EmployeeMVVM.DbContexts;
using EmployeeMVVM.Models;
using EmployeeMVVM.Services.EmployeeCreators;
using EmployeeMVVM.Services.EmployeeEditors;
using EmployeeMVVM.Services.EmployeeProviders;
using EmployeeMVVM.Stores;
using EmployeeMVVM.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Windows;

namespace EmployeeMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=employeemvvm.db";
        private readonly NavigationStore _navigationStore;
        private readonly EmployeeDbContextFactory _employeeDbContextFactory;
        private readonly EmployeeList _employeesList;
        public App()
        {

            _employeeDbContextFactory = new EmployeeDbContextFactory(CONNECTION_STRING);

            IEmployeeCreator employeeCreator = new DatabaseEmployeeCreator(_employeeDbContextFactory);
            IEmployeeEditor employeeEditor = new DatabaseEmployeeEditor(_employeeDbContextFactory);
            IEmployeeProvider employeeProvider = new DatabaseEmployeeProvider(_employeeDbContextFactory);

            _employeesList = new EmployeeList(employeeCreator, employeeEditor, employeeProvider);

            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            using (EmployeeDbContext dbContext = _employeeDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            _navigationStore.CurrentViewModel = CreateManageCSVViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }

        private ManageCSVViewModel CreateManageCSVViewModel()
        {
            return new ManageCSVViewModel(_employeesList, new Services.NavigationService(_navigationStore, CreateEditEmployeeViewModel));
        }
        private EditEmployeeViewModel CreateEditEmployeeViewModel(EmployeeViewModel e)
        {
            return new EditEmployeeViewModel(e, new Services.NavigationService(_navigationStore, CreateUpdatedManageCSVViewModel), _employeesList);
        }
        private ManageCSVViewModel CreateUpdatedManageCSVViewModel()
        {
            return ManageCSVViewModel.LoadViewModel(_employeesList, new Services.NavigationService(_navigationStore, CreateEditEmployeeViewModel));
        }
    }
}
