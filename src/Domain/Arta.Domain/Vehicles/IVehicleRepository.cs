using Anshan.Framework.Application;
using Arta.Domain.Vehicles;
using System.Threading.Tasks;

namespace Arta.Domain.Models.Consumers
{
    public interface IVehicleRepository : IRepository
    {
        Task<int> CreateVehicle(Vehicle vehicle);
        Task<Vehicle> Get(int vehicleId);
    }
}
