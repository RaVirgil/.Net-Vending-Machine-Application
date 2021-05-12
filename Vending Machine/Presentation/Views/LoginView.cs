using iQuest.Business.ViewInterfaces;
using System;

namespace iQuest.Presentation.Views
{
    public class LoginView : DisplayBase, ILoginView
    {
        public string AskForPassword()
        {
            Console.WriteLine();
            Display("Type the admin password: ", ConsoleColor.Cyan);
            return Console.ReadLine();
        }
    }
}