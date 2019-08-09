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
using System.Windows.Forms;

namespace ExtendedMVVM.ViewModels
{
    
    internal class MainWindowViewModel : ReactiveObject
    {

        [Reactive] public Company SelectedCompany { get; set; }

        public ObservableCollection<Company> Companies { get; private set; }

        public ICommand ShowCompanyView { get; private set; }

        public CompanyView _CompanyView { get; set; }


        public MainWindowViewModel()
        {
            Companies = new ObservableCollection<Company>(Company.GetCompanies());



            _CompanyView = new CompanyView();


            ShowCompanyView = new InterfaceCommand(ShowCompanyViewCommand, CanShowCompanyViewCommand);
                       

        }

        private void ShowCompanyViewCommand(object obj)
        {

            SelectedCompany = (obj as Company);




            //Companies.Add(SelectedCompany);
            //MessageBox.Show(obj.ToString());
            //ShowCompanyView();
        }

        private bool CanShowCompanyViewCommand(object arg)
        {



            return ((arg as Company) != null) &&
                ((arg as Company) != SelectedCompany);


        }
















    }
}
