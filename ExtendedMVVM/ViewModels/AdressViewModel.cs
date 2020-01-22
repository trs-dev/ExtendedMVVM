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
    class AdressViewModel : ReactiveObject
    {
        [Reactive] public Adress SelectedAdress { get; set; }
    }
}
