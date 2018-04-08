using System;
using System.Linq;
using System.Text.RegularExpressions;

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

            string[] ReceivedArray = Seperator(Receive);

            if (new TagValidator().validateTag(ReceivedArray[0]))
            {
                Tag = ReceivedArray[0];
            }

        }

        private string[] Seperator(string Seperate)
        {
            string pattern = "(;)";
            string[] result = Regex.Split(Seperate, pattern);

            return result;
        }
    }

    public class TagValidator
    {
        public bool validateTag(string tag)
        {
            if (tag.Length == 6 && tag.Any(char.IsLetterOrDigit))
                return true;
            else return false;
        }
    }
}
