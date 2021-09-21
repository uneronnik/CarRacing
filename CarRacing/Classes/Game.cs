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
        private int _traceLenght;
        public Game(List<Car> cars, int traceLenght)
        {
            _cars = cars;
            foreach (var car in _cars)
            {
                car.SubscribeOnGameEvents(this);
            }
            _traceLenght = traceLenght;
        }

        public IReadOnlyList<Car> Cars { get => _cars.AsReadOnly(); }
        public void StartRacing(int delayBeetwenUpdates)
        {
            RacingCycle(delayBeetwenUpdates);
        }
        private void WriteTextQuickly(List<string> linesToWrite, int xOffset, int yOffset)
        {
            Console.CursorVisible = false;
            int i = 0;
            foreach (var line in linesToWrite)
            {
                int j = 0;
                foreach (var ch in line)
                {
                    Console.SetCursorPosition(j + xOffset, i + yOffset); // Быстрое обновление консоли
                    Console.Write(ch);
                    j++;
                }
                i++;
            }
            Console.CursorVisible = true;
        }
        private void WriteCarsPositions()
        {
            
            List<string> textToWrite = new List<string>();
            foreach (var car in Cars)
            {
                string line = $"{car.Name}:".PadRight(19);
                for (int tracePartIndex = 0; tracePartIndex < _traceLenght; tracePartIndex++)
                {

                    if ((int)car.Position == tracePartIndex)
                        line += 'C';
                    else
                        line += '_';
                }
                line += '\n';
                textToWrite.Add(line);
            }

            WriteTextQuickly(textToWrite, 0, 0);
            
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

        private Car FindWinCar()// Если 2 или больше машин закончили одновременно побеждает та, что проехала дальше
        {
            Car winCar = Cars.ElementAt(0);
            foreach (var car in Cars)
            {
                if (winCar.Position < car.Position)
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
                if (car.Position >= _traceLenght)
                    return true;
            }
            return false;
        }
    }
}
