using AppShopping.LIbraries.Enums;
using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Services
{
    public class EstablishmentService
    {
        public List<Establishment> GetEstablishments()
        {
            var establishments = new List<Establishment>()
            {
                new Establishment()
                {
                    Id = 1,
                    Type = EstablishmentType.Store,
                    Logo = "",
                    Name = "Renner",
                    Description = "A Lojas Renner S.A. lorem ipsum",
                    Adress = "3 andar - Loja 10 - Setor Norte",
                    Phone = "(61) 3333-3333", 
                    }
            };
            return establishments;
        }
    }
}
