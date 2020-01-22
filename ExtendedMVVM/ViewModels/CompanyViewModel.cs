using ExtendedMVVM.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedMVVM.ViewModels
{
    class CompanyViewModel : ReactiveObject
    {
        [Reactive] public Company SelectedCompany { get; set; }

        public List<string> TypesOfStructure { get; private set; }

        public CompanyViewModel()
        {
            TypesOfStructure = new List<string> { "", "Corporation", "General Partnership", "Limited Liability Company", "Sole Proprietorship", "Association", "Estate", "Joint Venture",
                "Limited Liability Limited Partnership", "Limited Liability Partnership", "Limited Partnership", "Municipality", "Trust" };


        }

    }
}
