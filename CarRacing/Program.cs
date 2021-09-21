using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRacing.Classes;
using CarRacing.Classes.Cars;
namespace CarRacing
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            //cars.Add(new Bus(speedRandomizer, "№1"));
            //cars.Add(new PassengerСar(speedRandomizer, "№2"));
            //cars.Add(new Sportcar(speedRandomizer, "№3"));
            //cars.Add(new Truck(speedRandomizer, "№4"));

            Random speedRandomizer = new Random();

            cars.Add(new Sportcar(speedRandomizer, "№1"));
            cars.Add(new Sportcar(speedRandomizer, "№2"));
            cars.Add(new Sportcar(speedRandomizer, "№3"));
            cars.Add(new Sportcar(speedRandomizer, "№4"));

            Game game = new Game(cars);

            game.StartRacing(100);



            Console.ReadKey();
        }
    }
}
