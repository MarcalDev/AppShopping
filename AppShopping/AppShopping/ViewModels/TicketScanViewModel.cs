using AppShopping.LIbraries.Helpers.MVVM;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace AppShopping.ViewModels
{
    public class TicketScanViewModel : BaseViewModel
    {
        public string TicketNumber { get; set; }
        public ICommand TicketTextChangedCommand { get; set; }
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
            TicketScanCommand = new MvvmHelpers.Commands.AsyncCommand(TicketScan);
            TicketTextChangedCommand = new Command(TicketTextChanged);
            TicketPaidHistoryCommand = new Command(TicketPaidHistory);
        }

       
        private async Task TicketScan()
        {
            // Camera - Scanear o código de barras. (ZXing.Net.Mobile)

            var scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += async (result) =>
            {
                scanPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async() =>
                {

                    await Shell.Current.Navigation.PopAsync();
                    Message = result.Text;
                    TicketProccess(result.Text);
                });
            };

            await Shell.Current.Navigation.PushAsync(scanPage);
            // Implementar Async




            //  TicketNumber > Método novo

            /*
             * GetTicketInfo(Numero Ticket)
             * > Message
             * > Ticket > GoToAsync
             */
        }

        private void TicketTextChanged()
        {
            if(TicketNumber.Length == 15)
            {
                var ticketNumber = TicketNumber.Replace("", string.Empty);
                TicketProccess(ticketNumber);
            }
        }
        private void TicketProccess(string ticketNumber)
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
            Shell.Current.GoToAsync("ticket/paid/history");
        }
    }
}
