using iQuest.Business.UseCases;

namespace Presentation.Factories
{
    public interface IUseCaseFactory
    {
        T GetUseCase<T>() where T : IUseCase;
    }
}