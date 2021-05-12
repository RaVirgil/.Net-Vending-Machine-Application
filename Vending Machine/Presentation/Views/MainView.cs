using Business.ViewInterfaces;
using iQuest.Business.ViewInterfaces;
using System.Collections.Generic;

namespace iQuest.Presentation.Views
{
    public class MainView : DisplayBase, IMainView
    {
        public void DisplayApplicationHeader()
        {
            ApplicationHeaderControl applicationHeaderControl = new ApplicationHeaderControl();
            applicationHeaderControl.Display();
        }

        public IConsoleCommand ChooseCommand(IList<IConsoleCommand> useCaseCommands)
        {
            CommandSelectorControl commandSelectorControl = new CommandSelectorControl
            {
                UseCaseCommands = useCaseCommands
            };
            return commandSelectorControl.Display();
        }

        public void ShowInfo(string message)
        {
            DisplayLine(message, System.ConsoleColor.Yellow);
        }

        public void ShowError(string message)
        {
            DisplayLine(message, System.ConsoleColor.Red);
        }
    }
}