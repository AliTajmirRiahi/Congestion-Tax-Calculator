using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Framework.Enums
{
    public enum VehiclesType
    {
        NormalVehicle = 0,
        Motorcycle = 1,
        Busses = 2,
        Emergency = 3,
        Diplomat = 4,
        Foreign = 5,
        Military = 6
    }
}
