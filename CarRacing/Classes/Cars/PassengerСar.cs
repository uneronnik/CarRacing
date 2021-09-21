using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing.Classes.Cars
{
    class PassengerСar : Car
    {

        const int _maxSpeed = 60;
        public PassengerСar(Random speedRandomizer, string name) : base(_maxSpeed, speedRandomizer, name)
        {

        }
    }
}
