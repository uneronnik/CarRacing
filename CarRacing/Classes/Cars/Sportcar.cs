using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing.Classes.Cars
{
    class Sportcar : Car
    {
        const int _maxSpeed = 120;
        public Sportcar(Random speedRandomizer, string name) : base(_maxSpeed, speedRandomizer, name)
        {
        }
    }
}
