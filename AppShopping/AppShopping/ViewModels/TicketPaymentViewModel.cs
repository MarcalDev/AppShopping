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
    public class TicketPaymentViewModel : BaseViewModel
    {
        private string _messages;
        public string Messages 
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

                Ticket = _ticketService.GetTicketInfo(value);

                // Pesquisar Ticket e jogar na tela.
            } 
        }

        private Ticket _ticket;

        public Ticket Ticket 
        {
            get { return _ticket; } 
            set { 
                SetProperty(ref _ticket, value);
                _ticket = value; } 
        }

        private CreditCard _creditCard;
        public CreditCard CreditCard 
        { 
            get { return _creditCard; } 
            set { SetProperty(ref _creditCard, value); }
        
        }

        public ICommand PaymentCommand { get; set; }

        private TicketService _ticketService;
        private PaymentService _paymentService;
        public TicketPaymentViewModel()
        {
            _ticketService = new TicketService();
            _paymentService = new PaymentService();

            CreditCard = new CreditCard();

            PaymentCommand = new Command(Payment);
        }

        private void Payment()
        {
            //Implementar
            //Validar
            //Integração com um Serviço API

            try
            {
                Messages = string.Empty;

                string messages = Valid(CreditCard);

                if (string.IsNullOrEmpty(messages))
                {
                    int paymentId = _paymentService.SendPayment(CreditCard);

                }
                else
                {
                    Messages = messages;
                }

            } catch (Exception ex)
            {

            }
            //Colocar mensagem de erro

        }

        private string Valid(CreditCard creditCard)
        {
            StringBuilder messages = new StringBuilder();

            if (string.IsNullOrEmpty(creditCard.Name))
            {
                messages.Append("O nome não foi preenchido" + Environment.NewLine);
            }

            if (string.IsNullOrEmpty(creditCard.Number))
            {
                messages.Append("O número do cartão não foi preenchido" + Environment.NewLine);
            } 
            else if(creditCard.Number.Length < 19)
            {
                messages.Append("O número do cartão está incompleto!" + Environment.NewLine);
            }

           
            try
            {
                var expiredString = creditCard.Expired.Split('/');
                var month = int.Parse(expiredString[0]);
                var year = int.Parse(expiredString[1]);

                new DateTime(month, year, 01);
            }catch (Exception ex)
            {
                messages.Append("A validade do cartão não é valida!" + Environment.NewLine);
            }

            if (string.IsNullOrEmpty(creditCard.SecurityCode))
            {
                messages.Append("O código de segurança não foi preenchido!" + Environment.NewLine);
            }
            else if (creditCard.SecurityCode.Length < 3)
            {
                messages.Append("O código de segurança está incompleto" + Environment.NewLine);
            }

            if (string.IsNullOrEmpty(creditCard.Document))
            {
                messages.Append("O CPF não foi preenchido!" + Environment.NewLine);
            }
            else if (creditCard.Document.Length < 14)
            {
                messages.Append("O CPF está incompleto" + Environment.NewLine);
            }
            else if (IsCpf(creditCard.Document))
            {
                messages.Append("O CPF é inválido" + Environment.NewLine);
            }


            return messages.ToString();


        }

        public bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
