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

            string tag = DataSep[0];
            string xCord = DataSep[1];
            string yCord = DataSep[2];
            string Alt = DataSep[3];
            string time = DataSep[4];

            return new TOS(tag, xCord, yCord, Alt, time);
        }

        private string[] Seperator(string Seperate)
        {
            string pattern = "(;)";
            string[] result = Regex.Split(Seperate, pattern);

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