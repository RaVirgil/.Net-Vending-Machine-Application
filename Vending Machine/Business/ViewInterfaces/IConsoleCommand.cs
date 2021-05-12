namespace Business.ViewInterfaces
{
    public interface IConsoleCommand
    {
        string Name { get; }

        string Description { get; }

        bool CanExecute { get; }

        void Execute();
    }
}