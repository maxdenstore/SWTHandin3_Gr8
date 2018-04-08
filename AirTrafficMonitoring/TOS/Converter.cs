using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace TOS
{
    public class Converter
    {
        private ITransponderReceiver _transponderReceiver;



        public Converter(ITransponderReceiver receiver)
        {
            _transponderReceiver = receiver;

            _transponderReceiver.TransponderDataReady += transponderReceiverData;



        }


        public void transponderReceiverData object sender, Raw e) //her
        {
            foreach (var track in e.TransponderData)
            {
                TOS Convert_Data = Convert(track);
                Console.WriteLine(ConvertetTrack.ToString());
            }
        }
    }

    


}