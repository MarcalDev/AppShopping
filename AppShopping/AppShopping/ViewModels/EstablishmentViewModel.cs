using AppShopping.LIbraries.Enums;
using AppShopping.LIbraries.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    public abstract class EstablishmentViewModel : BaseViewModel
    {
        public string SearchWord { get; set; }
        public ICommand SearchCommand { get; set; }
        private List<Establishment> _establishments;
        public List<Establishment> Establishments
        {
            get
            {
                return _establishments;
            }
            set
            {
                SetProperty(ref _establishments, value);
            }

        }
        private List<Establishment> _allEstablishments;

        public ICommand DetailCommand { get; set; }

        private EstablishmentType _establishmentType;

        public EstablishmentViewModel(EstablishmentType establishmentType)
        {
            _establishmentType = establishmentType;
            SearchCommand = new Command(Search);
            DetailCommand = new Command<Establishment>(Detail);

            var allEstablishment = new EstablishmentService().GetEstablishments();
            var allStores = allEstablishment.Where(a => a.Type == establishmentType).ToList();

            Establishments = allStores;
            _allEstablishments = allStores;
        }

        private void Search()
        {

            Establishments = _allEstablishments.Where(a => a.Name.ToLower().Contains(SearchWord.ToLower())).ToList();
        }

        private void Detail(Establishment establishment)
        {
            String establishmentSerialized = JsonConvert.SerializeObject(establishment);
            Shell.Current.GoToAsync($"establishment/detail?establishmentSerialized={Uri.EscapeDataString(establishmentSerialized)}");
        }
    }
}
