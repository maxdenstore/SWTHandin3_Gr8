using System;
using System.Collections.Generic;
using ATMSystem.Interfaces;


namespace ATMSystem
{

    public class AirMonitor: IAirmonitor
    {
        public List<ITranspondObject> monitorList { get; set; } = new List<ITranspondObject>();


        private IDetectSepartation _detectSepartation;
        private IMessureDegrees _measureDegress;
        private IMessureVelocity _measureVelocity;
        
        public AirMonitor(IMessureDegrees measureDegress, IMessureVelocity measureVelocity, IDetectSepartation detectSepartation)
        {
            _measureDegress = measureDegress;
            _measureVelocity = measureVelocity;
            _detectSepartation = detectSepartation;
        }

        public void ReceiveNewTranspondObject(ITranspondObject NewTOS)
        {
            
            if (monitorList.Exists(x => x.Tag == NewTOS.Tag)) //if the tag exsists in the list
            {
                int index = monitorList.FindIndex(x => x.Tag == NewTOS.Tag);
                ITranspondObject old = monitorList[index];
                
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
                        _detectSepartation.detect(Outer,Inner);
                    }
                }

            }
            //print all separations (if any)
            _detectSepartation.printSeparations();


            //print everything in our monitored airspace
            foreach (var VARIABLE in monitorList)
            {                
                VARIABLE.Print();
            }

        }
    }
}