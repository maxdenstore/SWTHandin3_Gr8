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
        private TOS Converted = null;
        public Converter(ITransponderReceiver receiver)
        {
            _transponderReceiver = receiver;

            _transponderReceiver.TransponderDataReady += transponderReceiverData;

        }

        public TOS convert(string data)
        {
            string[] DataSep = Seperator(data);
            String tag = DataSep[0];

            return new TOS(tag, "", "", "", "");
        }

        private string[] Seperator(string Seperate)
        {
            string pattern = "(;)";
            string[] result = Regex.Split(Seperate, pattern);

            string x = result[1];
            string y = result[2];
            string altitude = result[3];
            string year = result[4];
            string month = result[5];
            string date = result[6];
            string hour = result[7];
            string minute = result[8];
            string second = result[9];
            string milisecond = result[10];



            return result;
        }

        public void transponderReceiverData( object sender, RawTransponderDataEventArgs e) 
        {
            foreach (var track in e.TransponderData)
            {
                Converted = this.convert(track);
            }
            Converted.print();
        }
    }

}