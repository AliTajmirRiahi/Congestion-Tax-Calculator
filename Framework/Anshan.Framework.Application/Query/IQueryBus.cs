using System.Threading.Tasks;

namespace Anshan.Framework.Application.Query
{
    public interface IQueryBus
    {
        Task<T> Dispatch<T>(IQuery<T> query);
    }
}