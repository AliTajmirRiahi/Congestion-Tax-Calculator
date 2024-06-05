using Arta.Domain.Models.Consumers;
using Arta.Domain.Vehicles;
using Arta.Persistence.EF.Contexts;
using Framework.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;

namespace Arta.Persistence.EF.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ArtaDbContext _dbContext;

        public VehicleRepository(ArtaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<int> SaveChange()
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateVehicle(Vehicle vehicle)
        {
            _dbContext.Vehicles.Add(vehicle);

            if (await _dbContext.SaveChangesAsync() > 0)
                return vehicle.Id;

            throw new RestException(System.Net.HttpStatusCode.BadRequest,"Server Error");
        }

        public async Task<Vehicle> Get(int vehicleId)
        {
            return await _dbContext.Vehicles.FindAsync(vehicleId);
        }
    }
}
