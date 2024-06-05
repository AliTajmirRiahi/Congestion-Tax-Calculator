using Framework.Enums;

namespace Arta.Application.Contracts.VehiclesCommands
{
    public class CreateVehicleCommand
    {
        public string Title { get; set; }
        public VehiclesType VehicleType { get; set; }
    }
}
