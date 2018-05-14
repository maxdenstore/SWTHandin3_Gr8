using System.Collections.Generic;
using ATMSystem.Interfaces;

namespace ATMSystem
{
    public class DetectSepartation : IDetectSepartation
    {
        private readonly IOutput _out;

        public DetectSepartation(IOutput outParam)
        {
            _out = outParam;
        }

        private List<Separtation> FlightsInConflic { get; } = new List<Separtation>();
        public bool Conflict { get; set; }

        public void detect(ITranspondObject a, ITranspondObject b)
        {
            {
                //need to check for timestamp too.

                var x = a.PosistionX - b.PosistionX;
                var y = a.PosistionY - b.PosistionY;
                var z = a.Altitude - b.Altitude;

                if (x <= 300 && x >= -300 && y <= 300 && y >= -300 && z <= 5000 && z >= -5000) //conflict
                {
                    Conflict = true; // make sure alarm is on
                    handleConflict(a, b);
                }

                else
                {

                    handleNoConflict(a, b);

                    if (FlightsInConflic.Count < 1)
                    {
                        Conflict = false; // so theres no more conflicts, no alarm.
                    }

                    
             
                }
            }
        }

        public void printSeparations()
        {
            foreach (var separtation in FlightsInConflic) separtation.PrintSeperation();
        }

        private void handleNoConflict(ITranspondObject a, ITranspondObject b)
        {
            //no conflict, check if its in the flights in conflict
            if (FlightsInConflic.Exists(x => x.Tag == a.Tag))
                FlightsInConflic.RemoveAt(FlightsInConflic.FindIndex(x => x.Tag == a.Tag));

            if (FlightsInConflic.Exists(x => x.Tag == b.Tag))
                FlightsInConflic.RemoveAt(FlightsInConflic.FindIndex(x => x.Tag == b.Tag));
        }

        private void handleConflict(ITranspondObject a, ITranspondObject b)
        {
            //are the tags already in conflict??
            if (FlightsInConflic.Exists(separtation => separtation.Tag == b.Tag)) //yes
                FlightsInConflic.RemoveAt(FlightsInConflic.FindIndex(x => x.Tag == b.Tag));

            if (FlightsInConflic.Exists(separtation => separtation.Tag == a.Tag))
                FlightsInConflic.RemoveAt(FlightsInConflic.FindIndex(x => x.Tag == a.Tag));

            FlightsInConflic.Add(new Separtation(a.Tag, a.TimeStamp, _out));
            FlightsInConflic.Add(new Separtation(b.Tag, b.TimeStamp, _out));
        }
    }
}