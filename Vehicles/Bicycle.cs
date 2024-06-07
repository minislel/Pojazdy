using System;

namespace Vehicles
{
    public class Bicycle : AbstractVehicle, ILand
    {
        public int wheelCount { get; private set; }

        public Bicycle()
        {
            this.wheelCount = 2;
            this.SpeedUnits = SpeedUnits.KmH;
            Stop();
        }
    }
}
