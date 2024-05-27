using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public interface IEngineVehicle 
    {
        EngineType _engine { get; set; }
        public virtual EngineType EngineType { get { return _engine; } set { if (this is IWater && this is IEngineVehicle) _engine = EngineType.Diesel; else _engine = value; } }
        public int EnginePower { get; set; } 

    }
}
