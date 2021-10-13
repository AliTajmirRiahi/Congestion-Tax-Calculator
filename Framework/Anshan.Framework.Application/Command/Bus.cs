using System;
using System.Threading.Tasks;
using Anshan.Framework.Core;

namespace Anshan.Framework.Application.Command
{
    public class Bus : IBus
    {
        private readonly IServiceLocator _serviceLocator;

        public Bus(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public async Task Dispatch<T>(T command)
        {
            var handler = _serviceLocator.GetInstance<TransactionalCommandHandlerDecorator<T>>();
            await handler.Handle(command);
        }

        public async Task DispatchLocal<T>(T command)
        {
            var handler = _serviceLocator.GetInstance<CommandHandlerDecorator<T>>();
            await handler.Handle(command);
        }

        public async Task<TResponse> Dispatch<TCommand, TResponse>(TCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var handler = _serviceLocator.GetInstance<TransactionalCommandHandlerDecorator<TCommand, TResponse>>();

            var result = await handler.Handle(command);

            return result;
        }

        public async Task<TResponse> DispatchLocal<TCommand, TResponse>(TCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var handler = _serviceLocator.GetInstance<CommandHandlerDecorator<TCommand, TResponse>>();

            var result = await handler.Handle(command);

            return result;
        }
    }
}