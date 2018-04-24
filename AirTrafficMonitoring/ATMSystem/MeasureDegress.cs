using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSystem
{
    public class MeasureDegress
    {

        public void Measure(TOS.TOS old, TOS.TOS newer)
        {
            int xDiff = newer.PosistionX - old.PosistionX;
            int yDiff = newer.PosistionY - old.PosistionY;

            double result = Math.Round(Math.Atan2(yDiff, xDiff) * 180 / Math.PI);

            if (result < 0)
            {
                result = 360 + result;
            }

            newer.degress = result;

        }
    }
}
