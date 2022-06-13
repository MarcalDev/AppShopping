using AppShopping.LIbraries.Enums;
using System;
using System.Collections.Generic;
using System.Text;


namespace AppShopping.Models
{
    public class Establishment
    {
        public int Id { get; set; }
        public EstablishmentType Type { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
    }
}
