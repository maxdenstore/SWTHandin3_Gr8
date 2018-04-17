using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSystem
{
    public class MeasureVelocity
    {

       public void Measure(TOS.TOS old,TOS.TOS newer)
        {

          double distance = Math.Sqrt(Math.Pow(newer.PosistionX - old.PosistionX, 2) + Math.Pow(newer.PosistionY - old.PosistionY, 2));

          TimeSpan timeDifference = newer.TimeStamp.Subtract(old.TimeStamp);
          double miliseconds = timeDifference.Milliseconds;

          double meterPerSec =  (distance*1000)/miliseconds;

            newer.Velocity = meterPerSec;

        } 

    }
}
