using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedMVVM.Models
{
    public class Adress : ReactiveObject
    {
        [Reactive] public string Department { get; set; }

        [Reactive] public string StreetAdress { get; set; }

        [Reactive] public string City { get; set; }

        [Reactive] public string Country { get; set; }

        [Reactive] public string ZipCode { get; set; }
    }
}
