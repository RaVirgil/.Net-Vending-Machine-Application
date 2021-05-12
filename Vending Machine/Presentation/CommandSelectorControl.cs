using Business.ViewInterfaces;
using System;
using System.Collections.Generic;

namespace iQuest.Presentation
{
    public class CommandSelectorControl : DisplayBase
    {
        public IEnumerable<IConsoleCommand> UseCaseCommands { get; set; }

        public IConsoleCommand Display()
        {
            DisplayUseCaseCommands();
            return SelectUseCaseCommand();
        }

        private void DisplayUseCaseCommands()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Available commands:");
            Console.WriteLine();

            foreach (IConsoleCommand useCaseCommand in UseCaseCommands)
                DisplayUseCaseCommand(useCaseCommand);
        }

        private static void DisplayUseCaseCommand(IConsoleCommand useCaseCommand)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(useCaseCommand.Name);

            Console.ForegroundColor = oldColor;

            Console.WriteLine(" - " + useCaseCommand.Description);
        }

        private IConsoleCommand SelectUseCaseCommand()
        {
            while (true)
            {
                string rawValue = ReadCommandName();
                IConsoleCommand selectedUseCase = FindUseCaseCommand(rawValue);

                if (selectedUseCase != null)
                    return selectedUseCase;

                DisplayLine("Invalid command. Please try again.", ConsoleColor.Red);
            }
        }

        private IConsoleCommand FindUseCaseCommand(string rawValue)
        {
            IConsoleCommand selectedUseCase = null;

            foreach (IConsoleCommand x in UseCaseCommands)
            {
                if (x.Name == rawValue)
                {
                    selectedUseCase = x;
                    break;
                }
            }

            return selectedUseCase;
        }

        private string ReadCommandName()
        {
            Console.WriteLine();
            Display("Choose command: ", ConsoleColor.Cyan);
            string rawValue = Console.ReadLine();
            Console.WriteLine();

            return rawValue;
        }
    }
}