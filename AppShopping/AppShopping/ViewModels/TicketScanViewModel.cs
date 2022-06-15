﻿using AppShopping.LIbraries.Helpers.MVVM;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AppShopping.ViewModels
{
    public class TicketScanViewModel : BaseViewModel
    {
        public string TicketNumber { get; set; }
        public ICommand TicketScanCommand { get; set; }
        private string _message;
        public string Message {
            get
            {
                return _message;
            }
            set 
            {
                SetProperty(ref _message, value);
            } 
        }

        public ICommand TicketPaidHistoryCommand { get; set; }
        public TicketScanViewModel()
        {
            TicketScanCommand = new Command(TicketScan);
            TicketPaidHistoryCommand = new Command(TicketPaidHistory);
        } 
        
        private void TicketScan()
        {

        }
        private void TicketPaidHistory()
        {

        }
    }
}
