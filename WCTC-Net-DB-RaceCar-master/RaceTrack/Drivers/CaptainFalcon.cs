using RaceTrack.RaceTrack.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RaceTrack.RaceTrack.Drivers
{
    class CaptainFalcon : Driver
    {
        public CaptainFalcon(RaceCar car) : base(car)
        {
            Name = "Captain Falcon";
            SkillLevel = 15;
        }

        public override void Drive()
        {
            Car.Accelerate(SkillLevel);
        }
    }
}
