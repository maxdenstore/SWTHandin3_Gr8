
using System;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace TOS
{

    public interface ITOS
    {
        string Tag { get;}
        int PosistionX { get;}
        int PosistionY { get;}
        int Altitude { get; }
        DateTime TimeStamp { get;}
        double Velocity { get; set; }
        double degress { get; set; }

    }
    public class TOS : ITOS
    {
        public string Tag { get; private set; }
        public int PosistionX { get; private set; }
        public int PosistionY { get; private set; }
        public int Altitude { get; private set; }
        public DateTime TimeStamp { get;private set; }
        public double Velocity { get; set; }
        public double degress { get; set; }

        public TOS(string tag, int posistionX, int posistionY, int altitude, DateTime timeStamp)
        {
            Tag = tag;
            PosistionX = posistionX;
            PosistionY = posistionY;
            Altitude = altitude;
            TimeStamp = timeStamp;
        }

        public void print()
        {
            string formattedDate = TimeStamp.ToString("F");
            formattedDate += " " + TimeStamp.Millisecond + " miliseconds";
            Console.WriteLine("Tag:\t\t\t" + Tag);
            Console.WriteLine("X Coordinate:\t\t\t" + PosistionX + " Meters");
            Console.WriteLine("Y Corrdniate:\t\t\t" + PosistionY + " Meters");
            Console.WriteLine("Altitude:\t\t\t" + Altitude + "Meters ");
            Console.WriteLine("Timestamp:\t\t\t" + formattedDate);
        }
    }

}
