
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace TOS
{
    public class TOS
    {
        public string Tag { get; set; }
        public string PosistionX { get; set; }
        public string PosistionY { get; set; }
        public string Altitude { get; set; }
        public string TimeStamp { get; set; }

        //public string HorizontalVelocity { get; set; }
        //public string CompassDegress { get; set; }

        public TOS(string Receive)
        {

        }

        private string[] Seperator(string Seperate)
        {
            string pattern = "(;)";
            string[] result = Regex.Split(Seperate, pattern);

            return result;
        }
    }

}
