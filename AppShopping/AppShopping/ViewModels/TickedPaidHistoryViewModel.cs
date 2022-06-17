using AppShopping.LIbraries.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.ViewModels
{
    public class TickedPaidHistoryViewModel : BaseViewModel
    {
        public List<Ticket> Tickets { get; set; }
        public TickedPaidHistoryViewModel()
        {
            Tickets = new TicketService().GetTicketsPaid();
        }
    }
}
