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
        
        public int CurrentSpeed
        {
            get
            {
                return _random.Next(1, _maxSpeed);
            }
        }
        public int Position { get; private set; }
        public string Name { get; set; }

        public  void Drive()
        {
            Position += CurrentSpeed;
        }
        private void OnUpdated()
        {
            Console.WriteLine($"{Name}: {Position}");
            Drive();
        }
        public void SubscribeOnGameEvents(Game game)
        {
            game.Updated += OnUpdated;
            game.Finished += OnFinished;
        }
        private void OnFinished()
        {
            if(Position >= 100)
                Console.WriteLine($"Машина {Name} победила!");
        }
        
    }
}
