using Business.ViewInterfaces;
using System.Collections.Generic;

namespace iQuest.Business.ViewInterfaces
{
    public interface IMainView
    {
        void DisplayApplicationHeader();

        IConsoleCommand ChooseCommand(IList<IConsoleCommand> useCases);

        void ShowInfo(string message);

        void ShowError(string message);
    }
}