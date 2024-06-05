using Anshan.Framework.Domain;
using Domain.Models.Users;
using Framework.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arta.Domain.Vehicles
{
    public class Vehicle : AggregateRoot<int>
    {
        public Vehicle()
        {
            Title = "";
            VehicleType = VehiclesType.NormalVehicle;
        }

        public Vehicle(string title, VehiclesType vehicleType)
        {
            Title = title;
            VehicleType = vehicleType;
        }

        public string Title { get; set; }
        public VehiclesType VehicleType { get; set; }
    }
}
