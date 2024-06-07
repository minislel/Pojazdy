using System;

namespace Vehicles
{
    public class Motorcycle : AbstractVehicle, ILand, IEngineVehicle
    {
        public int wheelCount { get; private set; }
        public EngineType _engine { get; set; }
        public int EnginePower { get; set; }

        public Motorcycle(int enginePower)
        {
            this.wheelCount = 2;
            this._engine = EngineType.Petrol;
            this.EnginePower = enginePower;
            this.SpeedUnits = SpeedUnits.KmH;
            Stop();
        }
    }
}
