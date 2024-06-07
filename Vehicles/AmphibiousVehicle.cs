using System;

namespace Vehicles
{
    public class AmphibiousVehicle : AbstractVehicle, ILand, IWater, IEngineVehicle
    {
        public int wheelCount { get; private set; }
        public int buoyancy { get; private set; }
        public EngineType _engine { get; set; }
        public int EnginePower { get; set; }

        public AmphibiousVehicle(int wheels, int buoyancy, EngineType engineType, int enginePower)
        {
            this.wheelCount = wheels;
            this.buoyancy = buoyancy;
            this._engine = engineType;
            this.EnginePower = enginePower;
            this.SpeedUnits = SpeedUnits.KmH;
            Stop();
        }

        public void SwitchToWater()
        {
            this.SpeedUnits = SpeedUnits.Knots;
        }

        public void SwitchToLand()
        {
            this.SpeedUnits = SpeedUnits.KmH;
        }
    }
}
