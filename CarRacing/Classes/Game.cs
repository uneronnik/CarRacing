using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing.Classes
{
    
    
    class Game
    {
        public delegate void UpdateHandler();
        public delegate void FinishHandler(Car WinCar);
        public event UpdateHandler Updated;
        public event FinishHandler Finished;
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
        private void WriteCarsPositions()
        {
            Console.CursorVisible = false;
            List<string> textToWrite = new List<string>();
            foreach (var car in Cars)
            {
                textToWrite.Add($"{car.Name}: {Math.Round(car.Position, 2)}\n");
            }
            int i = 0;
            
            foreach (var str in textToWrite)
            {
                int j = 0;
                foreach (var ch in str)
                {
                    Console.SetCursorPosition(j, i); // Быстрое обновление консоли
                    
                    Console.Write(ch);
                    j++;
                }
                i++;
            }
            Console.CursorVisible = true;
        }
        async void RacingCycle(int delayBeetwenUpdates)
        {
            await Task.Run(async () => // Чтобы можно было выключить в любой момент
            {
                while (!IsFinished())
                {
                    Updated();
                    WriteCarsPositions();
                    await Task.Delay(delayBeetwenUpdates);
                }
                Finished(FindWinCar()); // Если 2 или больше машин закончили одновременно побеждает та, что проехала дальше
            });
        }

        private Car FindWinCar()
        {
            Car winCar = Cars.ElementAt(0);
            foreach (var car in Cars)
            {
                if(winCar.Position < car.Position)
                {
                    winCar = car;
                }
            }
            return winCar;
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
