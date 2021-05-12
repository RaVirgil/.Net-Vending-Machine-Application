using iQuest.Business.Exceptions;
using iQuest.Business.ViewInterfaces;
using System;

namespace iQuest.Presentation.Views
{
    public class CardPaymentView : DisplayBase, ICardPaymentView
    {
        public string AskCardNumber()
        {
            Display("Please enter your card number (or 'cancel') ", ConsoleColor.White);
            string input = Console.ReadLine();
            while (input.Trim().Equals(""))
            {
                Display("Please enter your card number (or 'cancel') ", ConsoleColor.White);
                input = Console.ReadLine();
                if (input.Equals("cancel"))
                {
                    throw new CancelException();
                }
            }
            return input;
        }
    }
}