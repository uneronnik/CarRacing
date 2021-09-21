using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing.Classes.Cars
{
    class Truck : Car
    {

        const int _maxSpeed = 45;
        public Truck(Random speedRandomizer, string name) : base(_maxSpeed, speedRandomizer, name)
        {
        }
    }
}
