
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace TOS
{
    public class TOS
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

        //private string[] Seperator(string Seperate)
        //{
        //    string pattern = "(;)";
        //    string[] result = Regex.Split(Seperate, pattern);

        //    return result;
        //}
    }

}
