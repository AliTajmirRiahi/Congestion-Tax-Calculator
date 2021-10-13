using System.Threading.Tasks;

namespace Anshan.Framework.Application.Command
{
    public interface IBus
    {
        Task Dispatch<T>(T command);
        Task DispatchLocal<T>(T command);
        Task<TResponse> Dispatch<TCommand, TResponse>(TCommand command);
        Task<TResponse> DispatchLocal<TCommand, TResponse>(TCommand command);
    }

    public interface ICustomCommandBus
    {
        Task Dispatch<T>(T command);
    }
}