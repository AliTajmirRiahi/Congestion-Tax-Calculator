using System.Threading.Tasks;

namespace Anshan.Framework.Core
{
    public interface IUnitOfWork
    {
        void Begin();

        Task Commit();

        void Rollback();
    }
}