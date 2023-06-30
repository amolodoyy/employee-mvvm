using EmployeeMVVM.Models;
using EmployeeMVVM.Services;
using EmployeeMVVM.ViewModels;
using EmployeeMVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMVVM.Commands
{
    public class EditCommand : CommandBase
    {
        private readonly NavigationService _navigationService;
        private readonly ManageCSVViewModel _manageCSVViewModel;
        public EditCommand(ManageCSVViewModel manageCSVViewModel, NavigationService navigationService)
        {
            _navigationService = navigationService;
            _manageCSVViewModel = manageCSVViewModel;

            _manageCSVViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object parameter)
        {
            return _manageCSVViewModel.SelectedToEdit != null && base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            if(_manageCSVViewModel != null)
            {
                _navigationService.NavigateToEditView(_manageCSVViewModel.SelectedToEdit);
            }
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(ManageCSVViewModel.SelectedToEdit))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
