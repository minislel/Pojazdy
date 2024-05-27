using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    internal class Amphibia : AbstractVehicle, IWater, ILand
    {
        public int buoyancy { get; private set; }

        public int wheelCount { get; private set; }

        public Amphibia()
            {
            
            
        }


    }
    
    
}
