using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTrack.RaceTrack.Cars
{
    class FzeroRacer : RaceCar
    {
        public FzeroRacer()
        {
            Name = "F-Zero Racer";
            TopSpeed = 200;
        }

        public override void StartEngine()
        {
            Console.WriteLine($"The {Name}'s quantum engine fires up");
        }
        public override void Brake()
        {
            Console.WriteLine($"The {Name} stops on a dime");
            base.Brake();
        }
    }
}
