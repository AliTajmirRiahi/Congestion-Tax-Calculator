using System;
using System.Threading.Tasks;

namespace Anshan.Framework.Application.Command
{
    public class CommandHandlerDecorator<T> : ICommandHandler<T>
    {
        private readonly ICommandHandler<T> _commandHandler;

        public CommandHandlerDecorator(ICommandHandler<T> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public async Task Handle(T command)
        {
            try
            {
                await _commandHandler.Handle(command);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }
    }
    
    public class CommandHandlerDecorator<TCommand, TResponse> : ICommandHandler<TCommand,TResponse>
    {
        private readonly ICommandHandler<TCommand, TResponse> _commandHandler;

        public CommandHandlerDecorator(ICommandHandler<TCommand, TResponse> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public async Task<TResponse> Handle(TCommand command)
        {
            TResponse result;
            try
            {
                result = await _commandHandler.Handle(command);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return result;
        }
    }
}