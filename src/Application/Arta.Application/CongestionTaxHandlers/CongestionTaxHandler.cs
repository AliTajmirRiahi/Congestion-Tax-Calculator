using Anshan.Framework.Application.Command;
using Arta.Application.CongestionTaxHandlers;
using Arta.Application.Contracts.CongestionTax;
using Arta.Application.Contracts.VehiclesCommands;
using Arta.Domain.Models.Consumers;
using Arta.Domain.Vehicles;
using FluentValidation;
using Framework.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arta.Application.ConsumerHandlers
{
    public class CongestionTaxCommandValidator : AbstractValidator<CalculatorCongestionTaxCommand>
    {
        public CongestionTaxCommandValidator()
        {
            //RuleFor(p => p.Title).NotEmpty().WithMessage("Title can't be empty").NotNull().WithMessage("Title can't be empty");
        }
    }
    public class CongestionTaxHandler : ICommandHandler<CalculatorCongestionTaxCommand, List<TaxResult>>
    {
        private readonly IBus _bus;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IConfiguration _configuration;
        private readonly CongestionTaxCalculator _congestionTaxCalculator;

        public CongestionTaxHandler(IBus bus, IVehicleRepository vehicleRepository, IConfiguration configuration, CongestionTaxCalculator congestionTaxCalculator)
        {
            _bus = bus;
            _vehicleRepository = vehicleRepository;
            _configuration = configuration;
            _congestionTaxCalculator = congestionTaxCalculator;
        }
        public async Task<List<TaxResult>> Handle(CalculatorCongestionTaxCommand command)
        {
            Vehicle vehicle = await EnsureVehicleExist(command);

            return _congestionTaxCalculator.GetTax(vehicle, command.Dates);
        }

        private async Task<Vehicle> EnsureVehicleExist(CalculatorCongestionTaxCommand command)
        {
            var vehicle = await _vehicleRepository.Get(command.VehicleId);

            if (vehicle == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, "Vehicle was not found");

            return vehicle;
        }

        
    }
}
