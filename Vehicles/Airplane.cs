using System;

namespace Vehicles
{
    public class Airplane : AbstractVehicle, IAirborne, ILand, IEngineVehicle
    {
        public int wheelCount { get; private set; }
        public bool IsInAir { get; set; }
        public EngineType _engine { get; set; }
        public int EnginePower { get; set; }

        public Airplane(EngineType engineType, int enginePower, int wheels)
        {
            this._engine = engineType;
            this.EnginePower = enginePower;
            this.wheelCount = wheels;
            this.SpeedUnits = SpeedUnits.KmH; 
            this.IsInAir = false;
            Stop();
        }

        public void TakeOff()
        {
            if (this.Speed >= this._airMinSpeed)
            {
                this.IsInAir = true;
                this.SpeedUnits = SpeedUnits.Ms; 
            }
        }

        public void Land()
        {
            if (this.Speed == this._airMinSpeed)
            {
                this.IsInAir = false;
                this.SpeedUnits = SpeedUnits.KmH; 
            }
        }
    }
}
