
using System;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using ATMSystem.Interfaces;
using TOS.Interfaces;

namespace TOS
{


    public class TOS : ITOS
    {
        public string Tag { get; private set; }
        public int PosistionX { get; private set; }
        public int PosistionY { get; private set; }
        public int Altitude { get; private set; }
        public DateTime TimeStamp { get;private set; }
        public double Velocity { get; set; }
        public double degress { get; set; }

        public TOS(string tag, int posistionX, int posistionY, int altitude, DateTime timeStamp, IOutput output)
        {
            Tag = tag;
            PosistionX = posistionX;
            PosistionY = posistionY;
            Altitude = altitude;
            TimeStamp = timeStamp;

            string formattedDate = TimeStamp.ToString("F");
            formattedDate += " " + TimeStamp.Millisecond + " miliseconds";

            output.Print(("Tag:\t\t\t" + Tag));
            output.Print("X Coordinate:\t\t\t" + PosistionX + " Meters");
            output.Print("Y Corrdniate:\t\t\t" + PosistionY + " Meters");
            output.Print("Altitude:\t\t\t" + Altitude + "Meters ");
            output.Print("Timestamp:\t\t\t" + formattedDate);
            output.Print($"Velocity:\t\t\t{Velocity}");
            output.Print($"Degress:\t\t\t{degress}");

        }

    }

}
