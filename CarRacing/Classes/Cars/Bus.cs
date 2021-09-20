using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing.Classes.Cars
{
    class Bus : Car
    {

        const int _maxSpeed = 5;
        public Bus(Random speedRandomizer, string name) : base(_maxSpeed, speedRandomizer, name)
        {
        }
    }
}
