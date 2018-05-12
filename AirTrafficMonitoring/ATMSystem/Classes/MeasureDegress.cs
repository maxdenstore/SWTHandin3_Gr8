using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMSystem.Interfaces;

namespace ATMSystem
{
    public class MeasureDegress : IMessureDegrees
    {
        public void Measure(ITranspondObject old, ITranspondObject newer)
        {
            var xDiff = newer.PosistionX - old.PosistionX;
            var yDiff = newer.PosistionY - old.PosistionY;

            var result = Math.Round(Math.Atan2(yDiff, xDiff) * 180 / Math.PI); // simply math.

            if (result < 0)
            {
                result = 360 + result;
            }

            newer.degress = result;
        }
    }
}
