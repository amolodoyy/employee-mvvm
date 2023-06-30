using EmployeeMVVM.Models;
using EmployeeMVVM.Stores;
using EmployeeMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMVVM.Services
{
    public class NavigationService
    {
        private readonly NavigationStore? _navigationStore;
        private readonly Func<ViewModelBase>? _createViewModel;
        private Func<EmployeeViewModel, EditEmployeeViewModel>? _createEditEmployeeViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public NavigationService(NavigationStore navigationStore, Func<EmployeeViewModel, EditEmployeeViewModel> createEditEmployeeViewModel)
        {
            _navigationStore = navigationStore;
            _createEditEmployeeViewModel = createEditEmployeeViewModel;
        }
#pragma warning disable CS8602
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
        public void NavigateToEditView(EmployeeViewModel? e)
        {
            _navigationStore.CurrentViewModel = _createEditEmployeeViewModel(e);
        }
#pragma warning restore CS8602
    }
}
