using Business.ViewInterfaces;
using iQuest.Business.Exceptions;
using iQuest.Business.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.VendingMachine
{
    internal class VendingMachineApplication
    {
        private readonly List<IConsoleCommand> useCaseCommands;
        private readonly IMainView mainView;

        public VendingMachineApplication(IList<IConsoleCommand> useCaseCommands, IMainView mainView)
        {
            this.useCaseCommands = useCaseCommands?.ToList() ?? throw new ArgumentNullException(nameof(useCaseCommands));
            this.mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
        }

        public void Run()
        {
            mainView.DisplayApplicationHeader();

            while (true)
            {
                List<IConsoleCommand> availableUseCaseCommands = GetExecutableUseCaseCommands();

                IConsoleCommand useCase = mainView.ChooseCommand(availableUseCaseCommands);
                try
                {
                    useCase.Execute();
                }
                catch (CancelException e)
                {
                    mainView.ShowInfo(e.Message);
                }
                catch (Exception e)
                {
                    mainView.ShowError(e.Message);
                }
            }
        }

        private List<IConsoleCommand> GetExecutableUseCaseCommands()
        {
            List<IConsoleCommand> executableUseCaseCommands = new List<IConsoleCommand>();

            foreach (IConsoleCommand useCaseCommand in useCaseCommands)
            {
                if (useCaseCommand.CanExecute)
                    executableUseCaseCommands.Add(useCaseCommand);
            }

            return executableUseCaseCommands;
        }
    }
}