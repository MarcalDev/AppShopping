using AppShopping.LIbraries.Helpers.MVVM;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

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
            // Camera - Scanear o código de barras. (ZXing.Net.Mobile)

            var scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;

                Shell.Current.Navigation.PopAsync();

                Message = result.Text;
            };
            // Implementar Async
            Shell.Current.Navigation.PushAsync(scanPage);


            TicketProcess("");
            //  TicketNumber > Método novo

            /*
             * GetTicketInfo(Numero Ticket)
             * > Message
             * > Ticket > GoToAsync
             */
        }
        private void TicketProcess(string ticketNumber)
        {
            try
            {
                var ticket = new TicketService().GetTicketInfo(ticketNumber);

                // Navegar para página de pagamento do Ticket
            } catch (Exception e)
            {
                Message = e.Message;
            }
        }
        private void TicketPaidHistory()
        {

        }
    }
}
