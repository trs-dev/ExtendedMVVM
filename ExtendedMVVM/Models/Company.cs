using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedMVVM.Models
{
    public class Company : ReactiveObject
    {
        [Reactive] public string CompanyName { get; set; }

        [Reactive] public string Structure { get; set; }

        [Reactive] public List<Adress> Adresses { get; set; }

        [Reactive] public List<Employee> Employees { get; set; }

               
        
        private readonly ObservableAsPropertyHelper<string> _FullCompanyName;
        public string FullCompanyName => _FullCompanyName.Value;


        public Company(string _CompanyName, string _Structure, List<Adress> _Adresses, List<Employee> _Employees)
        {
            CompanyName = _CompanyName;
            Structure = _Structure;
            Adresses = _Adresses;
            Employees = _Employees;


            _FullCompanyName = this.WhenAnyValue(company => company.CompanyName, company => company.Structure)
                .Select(t => t.Item1 + " " + t.Item2)
                .ToProperty(this, vm => vm.FullCompanyName);
        }

        public static List<Company> GetCompanies()
        {
            var result = new List<Company> {
                new Company("TEST-2019", "LLC",
                new List<Adress>
                {
                    new Adress {Country="USA", City="New York" , StreetAdress="Wall Street,13/56", ZipCode="10005", Department="Central Office"},
                    new Adress {Country="USA", City="New York" , StreetAdress="Old Road,720", ZipCode="11234", Department="Warehouse"}
                },
                new List<Employee>
                {
                    new Employee {Name="Bob Johnson", PhoneNumber="0000000000", Position="Warehouse manager"},
                    new Employee {Name="Sarah Miller", PhoneNumber="1111111111", Position="CEO"},
                    new Employee {Name="Ann Brown", PhoneNumber="2222222222", Position="Manager"}
                }),

                new Company("Davis And Partners", "LLP",
                new List<Adress>
                {
                    new Adress {Country="USA", City="Washington " , StreetAdress="Greenwater, 421", ZipCode="98022", Department="Central Office"},
                    
                },
                new List<Employee>
                {
                    new Employee {Name="Oprah Davis", PhoneNumber="33333333333", Position="Owner"}
                })

            };
            return result;
        }







    }
}
