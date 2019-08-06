using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedMVVM.Models
{
    public class Employee : ReactiveObject
    {
        [Reactive] public string Name { get; set; }

        [Reactive] public string PhoneNumber { get; set; }

        [Reactive] public string Position { get; set; }
    }
}
