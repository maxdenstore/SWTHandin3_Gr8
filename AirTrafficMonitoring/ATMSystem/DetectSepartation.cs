using System.Collections.Generic;
using ATMSystem.Interfaces;


namespace ATMSystem
{
    public class DetectSepartation : IDetectSepartation
    {
        private readonly IOutput _out;
        public List<Separtation> FlightsInConflic { get; set; } = new List<Separtation>();
        public bool Conflict { get; set; } = false;

        public DetectSepartation(IOutput @out)
        {
            _out = @out;
        }
        public void detect(ITranspondObject a, ITranspondObject b)
        {
            {
                //need to check for timestamp too.

                int x = a.PosistionX - b.PosistionX;
                int y = a.PosistionY - b.PosistionY;
                int z = a.Altitude - b.Altitude;

                if ((x <= 300 && x >= -300 && y <= 300 && y >= -300) && z <= 5000 && z >= -5000) //conflict
                {
                    Conflict = true;
                    handleConflict(a,b);
                }

                Conflict = false;
                handleNoConflict(a,b);
            }
        }

        public void handleNoConflict(ITranspondObject a, ITranspondObject b)
        {
            //no conflict, check if its in the flights in conflict
            if (FlightsInConflic.Exists(x => x.Tag == a.Tag))
            {
                FlightsInConflic.RemoveAt(FlightsInConflic.FindIndex(x => x.Tag == a.Tag));
            }

            if (FlightsInConflic.Exists(x => x.Tag == b.Tag))
            {
                FlightsInConflic.RemoveAt(FlightsInConflic.FindIndex(x => x.Tag == b.Tag));
            }
        }

        public void printSeparations()
        {
            foreach (var separtation in FlightsInConflic)
            {
                separtation.PrintSeperation();
            }
        }

        public void handleConflict(ITranspondObject a, ITranspondObject b)
        {
            //there is conflict, do something mate!
            //are the tags already in conflict??
            if (FlightsInConflic.Exists(separtation => separtation.Tag == b.Tag))//yes
            {
                FlightsInConflic.RemoveAt(FlightsInConflic.FindIndex(x => x.Tag == b.Tag));
            }

            if (FlightsInConflic.Exists(separtation => separtation.Tag == a.Tag))
            {
                FlightsInConflic.RemoveAt(FlightsInConflic.FindIndex(x => x.Tag == a.Tag));
            }

            FlightsInConflic.Add(new Separtation(a.Tag, a.TimeStamp,_out));
            FlightsInConflic.Add(new Separtation(b.Tag, b.TimeStamp,_out)); 
        }
    }
}