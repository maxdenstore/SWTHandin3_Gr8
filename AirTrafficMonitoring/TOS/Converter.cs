using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TransponderReceiver;

namespace TOS
{
    public class Converter
    {
        private ITransponderReceiver _transponderReceiver;
        public TOS Converted;
        public Converter(ITransponderReceiver receiver)
        {
            _transponderReceiver = receiver;

            _transponderReceiver.TransponderDataReady += transponderReceiverData;

        }

        public TOS convert(string data)
        {
            string[] DataSep = Seperator(data);

            string tag = DataSep[0];
            string xCord = PutOnMeters(DataSep[2]);
            string yCord = PutOnMeters(DataSep[4]);
            string Alt = PutOnMeters(DataSep[6]) ;
            string time =FormateDate(DataSep[8]);

            return new TOS(tag, xCord, yCord, Alt, time);
        }

        private string[] Seperator(string Seperate)
        {
            string pattern = "(;)";
            string[] result = Regex.Split(Seperate, pattern);

            return result;
        }

        private string PutOnMeters(string thisOne)
        {
            thisOne += " Meters";
            return thisOne;
        }

        private string FormateDate(string RawDate)
        {
            string year = RawDate.Substring(0, 4);
            string month = RawDate.Substring(4, 2);
            string dateOfMonth = RawDate.Substring(6, 2);
            string hour = RawDate.Substring(8, 2);
            string minute = RawDate.Substring(10, 2);
            string second = RawDate.Substring(12, 2);
            string milisecond = " and " + RawDate.Substring(14, 3) + " miliseconds";

            DateTime dates = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(dateOfMonth), Int32.Parse(hour), Int32.Parse(minute), Int32.Parse(second));

            string formatted = dates.ToString("F");
            formatted += milisecond;
            return formatted;
        }

        public void transponderReceiverData( object sender, RawTransponderDataEventArgs e) 
        {
            foreach (var track in e.TransponderData)
            {
                Converted = this.convert(track);
            }

            if (Converted != null)
            {
                Converted.print();
            }

        }
    }

}