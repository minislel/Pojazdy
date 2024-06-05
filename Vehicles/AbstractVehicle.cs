using System.Text;

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
        Knots, KmH, Ms
    }
    public abstract class AbstractVehicle
    {
        private double _speed;
        private SpeedUnits _units;
        
        public VehicleState State { get { return (Speed!=0 ? VehicleState.Moving : VehicleState.Stationary); } }
        

        public readonly double _landMaxSpeed = 350;
        public readonly double _landMinSpeed = 1;
        public readonly double _airMaxSpeed = 200;
        public readonly double _airMinSpeed = 20;
        public readonly double _waterMaxSpeed = 40;
        public readonly double _waterMinSpeed = 1;


        public double Speed { 
            get 
            { 
                return _speed; 
            } 
            protected set 
            {
                if (SpeedUnits == SpeedUnits.Knots && value > _waterMaxSpeed)
                { 
                    _speed = _waterMaxSpeed;
                }
                else if (SpeedUnits == SpeedUnits.Ms && value >_airMaxSpeed) 
                {
                    _speed = _airMaxSpeed;
                }
                else if (SpeedUnits == SpeedUnits.KmH && value > _landMaxSpeed)
                {
                    _speed = _landMaxSpeed;
                }
                else if (SpeedUnits == SpeedUnits.Ms && value < _airMinSpeed)
                {
                    _speed = _airMinSpeed;
                }
                else if (SpeedUnits == SpeedUnits.KmH && value < _landMinSpeed)
                {
                    _speed = _landMinSpeed;
                }
                else if (SpeedUnits == SpeedUnits.Knots && value < _waterMinSpeed)
                {
                    _speed = _waterMinSpeed;
                }

                else
                {
                    _speed = value;
                }
            } 
        }
        public virtual void Stop()
        {
            if (this is IAirborne a && !a.IsInAir)
            { 
                _speed = 0;
            }
            if (!(this is IAirborne))
            {
                _speed = 0;
            }
        }
        public virtual void SetSpeed(double speed)
        {
            if (this.State == VehicleState.Moving)
            { 
                Speed = speed;
            }
        }
        public SpeedUnits SpeedUnits
        {
            get { return _units; }
            set {
                if (this is IWater && this is ILand && _units == SpeedUnits.KmH && value == SpeedUnits.Knots)
                {
                    _units = value;
                    _speed = _speed * 0.5399568034557;
                }
                else if (this is IWater && this is ILand && _units == SpeedUnits.Knots && value == SpeedUnits.KmH)
                {
                    _units = value;
                    _speed = _speed * 1.852;
                }
                else if (this is IAirborne && this is ILand && _units == SpeedUnits.KmH && value == SpeedUnits.Ms)
                {
                    _units = value;
                    _speed = _speed * 0.2777777777778;
                }
                else if (this is IAirborne && this is ILand && _units == SpeedUnits.Ms && value == SpeedUnits.KmH)
                {
                    _units = value;
                    _speed = _speed * 3.6;
                }
                else if (this is IAirborne && this is IWater && _units == SpeedUnits.Ms && value == SpeedUnits.Knots)
                {
                    _units = value;
                    _speed = _speed * 0.5144444444444;
                }
                else if (this is IAirborne && this is IWater && _units == SpeedUnits.Knots && value == SpeedUnits.Ms)
                {
                    _units = value;
                    _speed = _speed * 1.943844492441;
                }
                else if (this is IWater && value == SpeedUnits.Knots)
                {
                    _units = value;
                }
                else if (this is IAirborne && value == SpeedUnits.Ms)
                {
                    _units = value;
                }
                else if (this is ILand && value == SpeedUnits.KmH)
                {
                    _units = value;
                }
                else throw new InvalidOperationException();
            }        
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Type: {this.GetType()}, ");
            if (this is IEngineVehicle) sb.Append(" Engine Vehicle ");
            if (this is IAirborne) sb.Append(" Air Vehicle ");
            if (this is ILand) sb.Append(" Land Vehicle ");
            if (this is IWater) sb.Append(" Water Vehicle ");
            sb.Append("\nCurrent Environment: ");
            if (this.SpeedUnits == SpeedUnits.Knots) sb.Append($"Water\n, speed range: {_waterMinSpeed} - {_waterMaxSpeed} Knots");
            if (this.SpeedUnits == SpeedUnits.KmH) sb.Append($"Land\n, speed range: {_landMinSpeed} - {_landMaxSpeed} Km/H");
            if (this.SpeedUnits == SpeedUnits.Ms) sb.Append($"Air\n, speed range: {_airMinSpeed} - {_airMaxSpeed} M/s");
            if (this.State == VehicleState.Moving) sb.Append($"Moving at {Speed} {nameof(this.SpeedUnits)}");
            else sb.Append("Not moving\n");
            if (this is IEngineVehicle e) sb.Append($"Engine type: {e.EngineType}, {e.EnginePower}\n");
            if (this is IWater w) sb.Append($"Buoyancy: {w.buoyancy}\n");
            if (this is ILand l) sb.Append($"Wheel Count: {l.wheelCount}\n");

            return sb.ToString();
        }
    }
}
