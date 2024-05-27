using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public interface IAirborne
    {
        
        bool IsInAir { get; set; }
        void TakeOff() 
        {
            if (this is AbstractVehicle vehicle && vehicle.Speed >= 72 && !IsInAir && vehicle.SpeedUnits == SpeedUnits.KmH)
            {
                vehicle.SpeedUnits = SpeedUnits.Ms;
                vehicle.SetSpeed(vehicle._airMinSpeed);
                IsInAir = true;
            }
        }
        void Land()
        {
            if (this is AbstractVehicle vehicle && vehicle.Speed == vehicle._airMinSpeed && IsInAir)
            {
                vehicle.SpeedUnits = SpeedUnits.KmH;
                vehicle.SetSpeed(72);
                IsInAir = false;
            }

        }
    }
}
