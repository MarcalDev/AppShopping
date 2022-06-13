using AppShopping.LIbraries.Enums;
using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    public class StoresViewModel
    {
        public string SearchWord { get; set; }
        public ICommand SearchCommand { get; set; }
        public List<Establishment> Establishments { get; set; }

        public StoresViewModel()
        {
            SearchCommand = new Command(Search);

            var allEstablishment = new EstablishmentService().GetEstablishments();
            var allStores = allEstablishment.Where(a => a.Type == EstablishmentType.Store).ToList();
           
            Establishments = allStores;
        }

        private void Search()
        {
            
        }
    }
}
