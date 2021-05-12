using Autofac;
using iQuest.Business.UseCases;
using System;

namespace Presentation.Factories
{
    public class UseCaseFactory : IUseCaseFactory
    {
        private readonly ILifetimeScope scope;

        public UseCaseFactory(ILifetimeScope scope)
        {
            this.scope = scope ?? throw new ArgumentNullException(nameof(scope));
        }

        public T GetUseCase<T>() where T : IUseCase
        {
            return scope.Resolve<T>();
        }
    }
}