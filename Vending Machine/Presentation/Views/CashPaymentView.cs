using iQuest.Business.Exceptions;
using iQuest.Business.ViewInterfaces;
using System;

namespace iQuest.Presentation.Views
{
    public class CashPaymentView : DisplayBase, ICashPaymentView
    {
        public float CollectMoneyCash()
        {
            float money;
            int tries = 3;

            while (tries != 0)
            {
                Display("Please insert money ", ConsoleColor.White);
                string input = Console.ReadLine();
                if (input.Equals("cancel"))
                {
                    throw new CancelException();
                }

                if (Single.TryParse(input, out money))
                {
                    return money;
                }

                tries--;
            }

            throw new CancelException();
        }

        public void NeedToPayMore(float priceToPay)
        {
            DisplayLine("You still need to pay " + priceToPay, ConsoleColor.Yellow);
        }

        public void ReturnChange(float change)
        {
            DisplayLine("Your change is " + change, ConsoleColor.Green);
        }
    }
}