using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ATMSystem.Interfaces;
using TOS;
using TransponderReceiver;

namespace ATMSystem
{

    public class AirMonitor:IAirmonitor
    {
        public List<TOS.TOS> monitorList { get; set; }
        public List<Separtation> FlightsInConflic { get; set; }
        public bool Conflict { get; set; }

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
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("New data: ");
                
            //check for conflicts for each in monitor
            foreach (var Outer in monitorList)
            {
                foreach (var Inner in monitorList)//checking each against each other
                {
                    if (Outer.Tag != Inner.Tag)
                    {
                        Conflict = checkForConflict(Outer, Inner); //checking for conflicts
                        if (Conflict)
                        {

                            //there is conflict, do something mate!

                            //are the tags already in conflict??
                            if (FlightsInConflic.Exists(separtation => separtation.Tag == Inner.Tag))//yes
                            {
                                FlightsInConflic.RemoveAt(FlightsInConflic.FindIndex(x => x.Tag == Inner.Tag));
                            }

                            if (FlightsInConflic.Exists(separtation => separtation.Tag == Outer.Tag))
                            {
                                FlightsInConflic.RemoveAt(FlightsInConflic.FindIndex(x => x.Tag == Outer.Tag));
                            }

                            FlightsInConflic.Add(new Separtation(Outer.Tag, Outer.TimeStamp));
                            FlightsInConflic.Add(new Separtation(Inner.Tag, Inner.TimeStamp));

                            //

                            foreach (var separtation in FlightsInConflic)
                            {
                                separtation.PrintSeperation();
                            }

                        }
                        //no conflict, check if its in the flights in conflict
                        if (!Conflict)
                        {

                            if (FlightsInConflic.Exists(x => x.Tag == Outer.Tag))
                            {
                                FlightsInConflic.RemoveAt(FlightsInConflic.FindIndex(x => x.Tag == Outer.Tag));
                            }

                            if (FlightsInConflic.Exists(x => x.Tag == Inner.Tag))
                            {
                                FlightsInConflic.RemoveAt(FlightsInConflic.FindIndex(x => x.Tag == Inner.Tag));
                            }
                        }

                    }
                }

            }
            //print everything in our monitored airspace
            foreach (var VARIABLE in monitorList)
            {
                VARIABLE.print();
            }

        }

        private bool checkForConflict(TOS.TOS a, TOS.TOS b)
        {
            //need to check for timestamp too.

            int x = a.PosistionX - b.PosistionX;
            int y = a.PosistionY - b.PosistionY;
            int z = a.Altitude - b.Altitude;

            if ((x <= 300 && x >= -300 && y <= 300 && y >= -300) && z <= 5000 && z >= -5000) //conflict
            {
                return true;
            }

            return false;
        }

    }
}