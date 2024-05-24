using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public abstract class EngineVehicle : AbstractVehicle
    {
        private EngineType _enginetype;
        public EngineType EngineType { get { return _enginetype; } set { if (this is IWater) _enginetype = EngineType.Diesel; } }
        public int EnginePower { get; set; } 

    }
}
