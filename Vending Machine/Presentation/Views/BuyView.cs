using iQuest.Business.Exceptions;
using iQuest.Business.ViewInterfaces;
using System;

namespace iQuest.Presentation.Views
{
    public class BuyView : DisplayBase, IBuyView
    {
        public int AskForColumnId()
        {
            string input = "";
            int id;
            while (!Int32.TryParse(input, out id))
            {
                Console.Write("Please enter a column number (or 'cancel' if you want to return to main menu): ");
                input = Console.ReadLine();
                if (input.Equals("cancel"))
                {
                    throw new CancelException();
                }
            }
            return id;
        }

        public void DispenseProduct(string name)
        {
            DisplayLine("\nProduct " + name + " has been dispensed, enjoy :)", ConsoleColor.Green);
        }
    }
}