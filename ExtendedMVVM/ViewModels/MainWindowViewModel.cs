using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedMVVM.Models;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Input;
using ExtendedMVVM.Views;
using System.Windows.Controls;

namespace ExtendedMVVM.ViewModels
{
    
    internal class MainWindowViewModel : ReactiveObject
    {
        #region main database, collections or lists, that contains all program data
        public ObservableCollection<Company> Companies { get; private set; }
        #endregion

        #region a parts of main db/collection/list, that must be shown
        [Reactive] public Company SelectedCompany { get; set; }
        #endregion

        #region main window control, in which we will show all another Views
        [Reactive] public UserControl MainContent { get; set; }
        #endregion

        #region declaration of all Views for binding
        public CompanyView CompanyViewBinding { get; set; }
        public AdressView AdressViewBinding { get; set; }
        public EmployeeView EmployeeViewBinding { get; set; }
        #endregion

        #region declaration of all View Models for binding
        public CompanyViewModel CompanyViewModelBinding { get; set; }
        public AdressViewModel AdressViewModelBinding { get; set; }
        public EmployeeViewModel EmployeeViewModelBinding { get; set; }
        #endregion

        #region declaration and realization of all commands 
        public ICommand ShowCompanyView { get; private set; }
        private void ShowCompanyView_Execute(object obj)
        {
            SelectedCompany = obj as Company;
            CompanyViewModelBinding.SelectedCompany = obj as Company;


            if (SelectedCompany != null)
                MainContent = CompanyViewBinding;
        }
        private bool ShowCompanyView_CanExecute(object arg)
        {
            return arg as Company != null &&
                   arg as Company != SelectedCompany;
        }

        public ICommand ChangeElement { get; private set; }
        private void ChangeElement_Execute(object obj)
        {
            AdressViewModelBinding.SelectedAdress = obj as Adress;
            EmployeeViewModelBinding.SelectedEmployee = obj as Employee;

            if (AdressViewModelBinding.SelectedAdress != null)
            {
                MainContent = AdressViewBinding;
                SelectedCompany = Companies.Where(x => x.Adresses.Contains(AdressViewModelBinding.SelectedAdress)).FirstOrDefault();
            }
            if (EmployeeViewModelBinding.SelectedEmployee != null)
            {
                MainContent = EmployeeViewBinding;
                SelectedCompany = Companies.Where(x => x.Employees.Contains(EmployeeViewModelBinding.SelectedEmployee)).FirstOrDefault();
            }
        }
        private bool ChangeElement_CanExecute(object arg)
        {
            return (arg as Adress != null && arg as Adress != AdressViewModelBinding.SelectedAdress)
                    || (arg as Employee != null && arg as Employee != EmployeeViewModelBinding.SelectedEmployee);
        }
        #endregion



        public MainWindowViewModel()
        {
            #region initialisation of main db
            Companies = new ObservableCollection<Company>(Company.GetCompanies()); //with test data - Company.GetCompanies()
            #endregion

            #region initialisation of commands
            ShowCompanyView = new InterfaceCommand(ShowCompanyView_Execute, ShowCompanyView_CanExecute);
            ChangeElement = new InterfaceCommand(ChangeElement_Execute, ChangeElement_CanExecute);
            #endregion

            #region initialisation of all Views for bindind
            CompanyViewBinding = new CompanyView();
            AdressViewBinding = new AdressView();
            EmployeeViewBinding = new EmployeeView();
            #endregion

            #region initialisation of all View Models for bindind
            CompanyViewModelBinding = new CompanyViewModel();
            AdressViewModelBinding = new AdressViewModel();
            EmployeeViewModelBinding = new EmployeeViewModel();
            #endregion

            #region bind all View Models to Views
            CompanyViewBinding.DataContext = CompanyViewModelBinding;
            AdressViewBinding.DataContext = AdressViewModelBinding;
            EmployeeViewBinding.DataContext = EmployeeViewModelBinding;
            #endregion
        }
    }
}
