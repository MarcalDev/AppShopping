﻿using AppShopping.LIbraries.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    [QueryProperty("Number", "number")]
    public class TicketPaymentSuccessViewModel : BaseViewModel
    {
        private string _number;
        public String Number
        {
            set
            {
                SetProperty(ref _number, value);

                Ticket = _ticketService.GetTicket(value);

                // Pesquisar Ticket e jogar na tela.
            }
        }

        private Ticket _ticket;

        public Ticket Ticket
        {
            get { return _ticket; }
            set {
                SetProperty(ref _ticket, value); 
            }
        }

        public ICollection OKCommand { get; set; }
        private TicketService _ticketService;

        public TicketPaymentSuccessViewModel()
        {
            OKCommand = new Command(OK);

            _ticketService = new TicketService();
        }

        private void OK()
        {
            Shell.Current.Navigation.PopToRootAsync();
        }

    }
}
