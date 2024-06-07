using System;

namespace Vehicles
{
    public class Motorboat : AbstractVehicle, IWater, IEngineVehicle
    {
        public int buoyancy { get; private set; }
        public EngineType _engine { get; set; } = EngineType.Diesel;
        public int EnginePower { get; set; }

        public Motorboat(int buoyancy, int enginePower)
        {
            this.buoyancy = buoyancy;
            this.EnginePower = enginePower;
            this.SpeedUnits = SpeedUnits.Knots;
        }
    }
}
