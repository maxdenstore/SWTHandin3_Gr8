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

        } 

    }
}
