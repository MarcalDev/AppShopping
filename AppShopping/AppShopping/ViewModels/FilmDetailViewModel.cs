using AppShopping.Models;
using AppShopping.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    [QueryProperty("filmSerialized", "filmSerialized")]
    public class FilmDetailViewModel
    {
        public Film Film { get; set; }

        public string filmSerialized {
            set {
                // Deserializar e atribuir ao Film
                var decode = Uri.UnescapeDataString(value);
                var film = JsonConvert.DeserializeObject<Film>(decode);

                Film = film;
            }
        }
        public FilmDetailViewModel()
        {

        }
    }
}
