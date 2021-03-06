﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMSystem.Interfaces;

namespace ATMSystem
{
    public class MeasureVelocity : IMessureVelocity
    {

        public void Measure(ITranspondObject old,ITranspondObject newer)
        {

          var distance = Math.Sqrt(Math.Pow(newer.PosistionX - old.PosistionX, 2) + Math.Pow(newer.PosistionY - old.PosistionY, 2));

          var timeDifference = newer.TimeStamp.Subtract(old.TimeStamp);
          var miliseconds = timeDifference.TotalMilliseconds;

          var meterPerSec =  (distance*1000)/miliseconds;

            newer.Velocity =Math.Round(meterPerSec);

        } 

    }
}
