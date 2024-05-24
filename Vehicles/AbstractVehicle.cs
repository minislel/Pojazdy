namespace Vehicles
{
    public enum VehicleState
    { 
        Moving, Stationary
    }
    public enum EngineType
    { 
        Electric, Petrol, Diesel, LPG, PetrolLPG, None
    }
    public enum SpeedUnits
    { 
        Knots, Kmh, Ms
    }
    public abstract class AbstractVehicle
    {
        public double _speed;
        public VehicleState State { get { return (Speed!=0 ? VehicleState.Moving : VehicleState.Stationary); } }

        public double Speed { 
            get 
            { 
                return _speed; 
            } 
            private set 
            {
                if (SpeedUnits == SpeedUnits.Knots && value > 40)
                { 
                    _speed = 40;
                }
                else if (SpeedUnits == SpeedUnits.Ms && value > 200) 
                {
                    _speed = 200;
                }
                else if (SpeedUnits == SpeedUnits.Kmh && value > 350)
                {
                    _speed = 350;
                }
                else if (SpeedUnits == SpeedUnits.Ms && (value < 20 && value !=0 ))
                {
                    _speed = 20;
                }
                else
                {
                    _speed = value;
                }
            } 
        }
        public virtual void Stop()
        {
            if (this is IAirborne a && !a.IsAirborne)
            { 
                Speed = 0;
            }
        }
        public SpeedUnits SpeedUnits { get; set; }
    }
}
