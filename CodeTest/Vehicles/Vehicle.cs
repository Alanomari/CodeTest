using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Vehicles
{
    public enum VehicleType
    {
        Motorbike,
        Car,
    }

    public interface IVehicle
    {
        VehicleType GetVehicleType();
    }
}