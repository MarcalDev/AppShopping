using AppShopping.LIbraries.Helpers.MVVM;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public ICommand OpenMapCommand { get; set; }

        public MenuViewModel()
        {
            OpenMapCommand = new AsyncCommand(OpenMap);
        }

        private async Task OpenMap()
        {
            var location = new Location(-22.332479029004844, -49.05297163121334);

            var options = new MapLaunchOptions { Name = "App - Shopping", NavigationMode = NavigationMode.Default };
            try
            {
                await Map.OpenAsync(location, options);
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro!", "Não conseguimos abrir o mapa do seu celular!", "OK");
            }
        }
    }
}
