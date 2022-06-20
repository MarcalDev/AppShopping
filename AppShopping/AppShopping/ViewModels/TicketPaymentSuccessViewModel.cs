using AppShopping.LIbraries.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    [QueryProperty("Number", "number")]
    [QueryProperty("Message", "message")]
    public class TicketPaymentSuccessViewModel : BaseViewModel
    {
        private string _messages;

        public string Message
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

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

        public ICommand OKCommand { get; set; }
        private TicketService _ticketService;

        public TicketPaymentSuccessViewModel()
        {
            OKCommand = new Command(OK);

            _ticketService = new TicketService();

            /*
             [0] - TicketScan
             [1] - TicketPayment
             [2] - Success/Failed
             */
            int indexScreenToRemove = 1;
            Shell.Current.Navigation.RemovePage(
                Shell.Current.Navigation.NavigationStack[indexScreenToRemove]
            );

        }

        private void OK()
        {
            Shell.Current.Navigation.PopToRootAsync();
        }

    }
}
