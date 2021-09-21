using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing.Classes
{
    abstract class Car
    {
        private Random _random;
        private int _maxSpeed;
        protected Car(int maxSpeed, Random speedRandomizer, string name)
        {
            _maxSpeed = maxSpeed;
            _random = new Random(speedRandomizer.Next());
            Name = name;
        }
        
        public double CurrentSpeed
        {
            get
            {
                return _random.Next(1, _maxSpeed) / (double)60;
            }
        }
        public double Position { get; private set; }
        public string Name { get; set; }

        public void Drive()
        {
            Position += CurrentSpeed;
        }
        private void OnUpdated()
        {
            Drive();
           
        }
        public void SubscribeOnGameEvents(Game game)
        {
            game.Updated += OnUpdated;
            game.Finished += OnFinished;
        }
        private void OnFinished(Car winCar)
        {
            if(this == winCar)
                Console.WriteLine($"Машина {Name} победила!");
        }
        
    }
}
