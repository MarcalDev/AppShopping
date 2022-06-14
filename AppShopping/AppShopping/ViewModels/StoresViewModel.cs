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
    public class StoresViewModel : EstablishmentViewModel
    {
        public StoresViewModel(EstablishmentType establishmentType) : base(establishmentType)
        {
        }
    }
}
