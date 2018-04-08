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
        private string Tag { get; set; }
        private ITransponderReceiver _transponderReceiver;

        public Converter(ITransponderReceiver receiver)
        {
            _transponderReceiver = receiver;

            _transponderReceiver.TransponderDataReady += transponderReceiverData;

        }


        public void convert(string data)
        {
            string[] DataSep = Seperator(data);
            Tag = DataSep[0];
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
                TOS Convert_Data = Convert(track);
                Console.WriteLine(ConvertetTrack.ToString());
            }
        }
    }

}