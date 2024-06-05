using Anshan.Framework.Application.Command;
using Arta.Application.Contracts.VehiclesCommands;
using Arta.Domain.Models.Consumers;
using Arta.Domain.Vehicles;
using FluentValidation;
using Framework.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;

namespace Arta.Application.ConsumerHandlers
{
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("Title can't be empty").NotNull().WithMessage("Title can't be empty");
        }
    }
    public class CreateVehicleHandler : ICommandHandler<CreateVehicleCommand, int>
    {
        private readonly IBus _bus;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IConfiguration _configuration;

        public CreateVehicleHandler(IBus bus, IVehicleRepository vehicleRepository, IConfiguration configuration)
        {
            _bus = bus;
            _vehicleRepository = vehicleRepository;
            _configuration = configuration;
        }
        public async Task<int> Handle(CreateVehicleCommand command)
        {
            Vehicle vehicle = await CreateConsumer(command);

            return vehicle.Id;
        }

        private async Task<Vehicle> CreateConsumer(CreateVehicleCommand command)
        {
            Vehicle vehicle = new(command.Title, command.VehicleType);

            await _vehicleRepository.CreateVehicle(vehicle);
            return vehicle;
        }

        
    }
}
