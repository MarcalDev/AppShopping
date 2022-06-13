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
                    Logo = "https://logodownload.org/wp-content/uploads/2014/07/renner-logo-2-1.png",
                    Name = "Renner",
                    Description = "A Lojas Renner S.A. lorem ipsum",
                    Adress = "3 andar - Loja 10 - Setor Norte",
                    Phone = "(61) 3333-3333", 
                    },


                new Establishment()
                {
                    Id = 2,
                    Type = EstablishmentType.Store,
                    Logo = "https://www.anacouto.com.br/wp-content/uploads/2021/07/GALERIA-SITE-AMERICANAS.png",
                    Name = "Americanas",
                    Description = "A Lojas Americanas S.A. lorem ipsum",
                    Adress = "1 andar - Loja 4 - Setor Norte",
                    Phone = "(61) 2222-2222",
                    },

                new Establishment()
                {
                    Id = 3,
                    Type = EstablishmentType.Store,
                    Logo = "https://gkpb.com.br/wp-content/uploads/2021/01/novo-logo-burger-king-2021.png",
                    Name = "Burger King",
                    Description = "O Burger King, lorem ipsum",
                    Adress = "2 andar - Loja 9 - Setor Norte",
                    Phone = "(61) 3333-3333",
                    }
            };
            return establishments;
        }
    }
}
