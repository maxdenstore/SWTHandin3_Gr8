using System;
using ATMSystem.Interfaces;

namespace ATMSystem
{


    public class TranspondObject : ITranspondObject
    {
        public string Tag { get; private set; }
        public int PosistionX { get; private set; }
        public int PosistionY { get; private set; }
        public int Altitude { get; private set; }
        public DateTime TimeStamp { get;private set; }
        public double Velocity { get; set; }
        public double degress { get; set; }
        public readonly IOutput _output;

        public TranspondObject(string tag, int posistionX, int posistionY, int altitude, DateTime timeStamp, IOutput _out) 
        {
            _output = _out;
            Tag = tag;
            PosistionX = posistionX;
            PosistionY = posistionY;
            Altitude = altitude;
            TimeStamp = timeStamp;
            Print();
        }

         public void Print()
        {
            string formattedDate = TimeStamp.ToString("F");
            formattedDate += " " + TimeStamp.Millisecond + " miliseconds";
            
            _output.Print(("Tag:\t\t\t" + Tag));
            _output.Print("X Coordinate:\t\t\t" + PosistionX + " Meters");
            _output.Print("Y Corrdniate:\t\t\t" + PosistionY + " Meters");
            _output.Print("Altitude:\t\t\t" + Altitude + "Meters ");
            _output.Print("Timestamp:\t\t\t" + formattedDate);
            _output.Print($"Velocity:\t\t\t{Velocity}");
            _output.Print($"Degress:\t\t\t{degress}");
        }

    }

}
