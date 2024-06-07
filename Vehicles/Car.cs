using System;

namespace Vehicles
{
    public class Car : AbstractVehicle, ILand, IEngineVehicle
    {
        public int wheelCount { get; private set; }
        public EngineType _engine { get; set; }
        public int EnginePower { get; set; }

        public Car(int wheels, EngineType engineType, int enginePower)
        {
            this.wheelCount = wheels;
            this._engine = engineType;
            this.EnginePower = enginePower;
            this.SpeedUnits = SpeedUnits.KmH;
            Stop();
        }
    }
}
