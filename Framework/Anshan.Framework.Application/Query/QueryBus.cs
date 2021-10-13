using System.Threading.Tasks;
using Anshan.Framework.Core;

namespace Anshan.Framework.Application.Query
{
    public class QueryBus : IQueryBus
    {
        private readonly IServiceLocator _serviceLocator;

        public QueryBus(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public async Task<T> Dispatch<T>(IQuery<T> query)
        {
            dynamic handler = _serviceLocator.GetInstance<IQuery<T>>();
            var result = await handler.Handle(query);

            return result;
        }
    }
}