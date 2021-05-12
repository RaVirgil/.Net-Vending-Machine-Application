using iQuest.Business.Exceptions;
using iQuest.Business.PaymentMethods;
using iQuest.Business.ViewInterfaces;
using System;
using System.Collections.Generic;

namespace iQuest.Presentation.Views
{
    public class PayView : DisplayBase, IPayView
    {
        public IPaymentMethod AskPaymentMethod(IEnumerable<IPaymentMethod> paymentMethods)
        {
            Display("You can choose between ", ConsoleColor.White);
            foreach (IPaymentMethod method in paymentMethods)
            {
                DisplayLine(method.Name + " ", ConsoleColor.Yellow);
            }

            string input = AskInputThreeTimes();

            foreach (IPaymentMethod method in paymentMethods)
            {
                if (input.ToLower().Equals(method.Name.ToLower()))
                    return method;
            }
            DisplayLine("Invalid payment method ", ConsoleColor.Red);
            throw new CancelException();
        }

        private string AskInputThreeTimes()
        {
            int tries = 3;
            string input = "";
            while (tries != 0)
            {
                if (input.Trim().Equals(""))
                {
                    Display("Please enter a payment method (or 'cancel') ", ConsoleColor.White);
                    input = Console.ReadLine();
                    if (input.Equals("cancel"))
                    {
                        throw new CancelException();
                    }
                }
                else
                {
                    return input;
                }
                tries--;
            }
            throw new CancelException();
        }

        public void AnnounceSuccessfulPayment()
        {
            DisplayLine("Payment successful", ConsoleColor.Green);
        }
    }
}