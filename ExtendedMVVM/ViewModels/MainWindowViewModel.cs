using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedMVVM.Models;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;

namespace ExtendedMVVM.ViewModels
{
    internal class MainWindowViewModel : ReactiveObject
    {
        [Reactive] public Company SelectedCompany { get; set; }

        public ObservableCollection<Company> Companies { get; private set; }

        public MainWindowViewModel()
        {
            Companies = new ObservableCollection<Company>(Company.GetCompanies());
        }


    }
}
