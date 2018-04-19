using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TOS;
using TransponderReceiver;

namespace ATMSystem
{
    public class AirMonitor
    {
        public List<TOS.TOS> monitorList = new List<TOS.TOS>();
        public List<Separtation> FlightsInConflic = new List<Separtation>();
        public bool Conflict = false;
        private MeasureVelocity _measureVelocity = new MeasureVelocity();
        private MeasureDegress _measureDegress = new MeasureDegress();
        public AirMonitor()
        {
            
        }

        public void ReceiveNewTOS(TOS.TOS NewTOS)
        {
            
            if (monitorList.Exists(x => x.Tag == NewTOS.Tag)) //if the tag exsists in the list
            {
                int index = monitorList.FindIndex(x => x.Tag == NewTOS.Tag);
                TOS.TOS old = monitorList[index];
                
                //measue speed
                _measureVelocity.Measure(old,NewTOS);

                //measure degress
                _measureDegress.Measure(old,NewTOS);

                //replace
                monitorList[index] = NewTOS;
            }

            else
            {
                monitorList.Add(NewTOS);
            }

            Console.Clear();
            Console.WriteLine("New data: ");

            //check for conflicts for each
            foreach (var VARIABLE in monitorList)
            {
               Conflict = checkForConflict(VARIABLE,NewTOS);
                if (Conflict)
                {
                    //there is conflict, do something mate!
                    FlightsInConflic.Add(new Separtation(VARIABLE.Tag,VARIABLE.TimeStamp));
                    FlightsInConflic.Add(new Separtation(NewTOS.Tag, NewTOS.TimeStamp));

                    //check all conflicts
                }
            }

            foreach (var VARIABLE in monitorList)
            {
                VARIABLE.print();
            }

        }

        private bool checkForConflict(TOS.TOS a, TOS.TOS b)
        {
            int x = a.PosistionX - b.PosistionX;
            int y = a.PosistionY - b.PosistionY;
            int z = a.Altitude - b.Altitude;

            if ((x <= 300 && x >= -300 || y <= 300 && y >= -300) && z <= 5000 && z >= -5000) //conflict
            {
                return true;
            }

            return false;
        }

    }
}