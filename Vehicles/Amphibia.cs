using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    internal class Amphibia : AbstractVehicle, IWater, ILand, IEngineVehicle
    {
        public int buoyancy { get; private set; }

        public int wheelCount { get; private set; }
        public EngineType _engine { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int EnginePower { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Amphibia()
        {
            SpeedUnits = SpeedUnits.KmH;
            Speed = 0;
            wheelCount = 6;
        }
    } 
}
