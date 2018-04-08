
using System;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace TOS
{

    public interface ITOS
    {
        string Tag { get;}
        string PosistionX { get;}
        string PosistionY { get;}
        string Altitude { get; }
        string TimeStamp { get;}
    }
    public class TOS : ITOS
    {
        public string Tag { get; private set; }
        public string PosistionX { get; private set; }
        public string PosistionY { get; private set; }
        public string Altitude { get; private set; }
        public string TimeStamp { get;private set; }

        public TOS(string tag, string posistionX, string posistionY, string altitude, string timeStamp)
        {
            Tag = tag;
            PosistionX = posistionX;
            PosistionY = posistionY;
            Altitude = altitude;
            TimeStamp = timeStamp;
        }

        public void print()
        {
            Console.WriteLine("Tag:\t\t\t" + Tag);
            Console.WriteLine("X Coordinate:\t\t\t" + PosistionX);
            Console.WriteLine("Y Corrdniate:\t\t\t" + PosistionY);
            Console.WriteLine("Altitude:\t\t\t" + Altitude);
            Console.WriteLine("Timestamp:\t\t\t" + TimeStamp);
        }
    }

}
