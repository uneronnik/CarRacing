using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing.Classes
{
    
    
    class Game
    {
        public delegate void RacingHandler();
        public event RacingHandler Updated;
        public event RacingHandler Finished;
        List<Car> _cars = new List<Car>();

        public Game(List<Car> cars)
        {
            _cars = cars;
            foreach (var car in _cars)
            {
                car.SubscribeOnGameEvents(this);
            }
        }

        public IReadOnlyList<Car> Cars { get => _cars.AsReadOnly(); }
        public void StartRacing(int delayBeetwenUpdates)
        {
            RacingCycle(delayBeetwenUpdates);
        }
        async void RacingCycle(int delayBeetwenUpdates)
        {
            while(!IsFinished())
            {
                Console.Clear();
                Updated();
                await Task.Delay(delayBeetwenUpdates);
            }
            Finished();
        }

        bool IsFinished()
        {
            foreach (var car in Cars)
            {
                if (car.Position >= 100)
                    return true;
            }
            return false;
        }
    }
}
