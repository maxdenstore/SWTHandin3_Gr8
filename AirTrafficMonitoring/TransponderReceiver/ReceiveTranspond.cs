
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ATMSystem;
using TransponderReceiver;

namespace TOS
{
    public class ReceiveTranspond
    {
        private AirMonitor _airspace = null;
        public EventArgs e = null;
        public delegate void TosReceived(TOS sender, EventArgs e);
        public event TosReceived recivedEvent;
        private ITransponderReceiver _transponderReceiver;
        public TOS Received;
        public ReceiveTranspond(ITransponderReceiver receiver, AirMonitor airSpace = null)
        {
            _transponderReceiver = receiver;

            _transponderReceiver.TransponderDataReady += transponderReceiverData;

            _airspace = airSpace;

        }

        public TOS receive(string data)
        {
            string[] DataSep = Seperator(data);

            string tag = DataSep[0];
            int xCord = Int32.Parse(DataSep[2]);
            int yCord = Int32.Parse(DataSep[4]);
            int Alt = Int32.Parse(DataSep[6]); 
            DateTime time =FormateDate(DataSep[8]);

            return new TOS(tag, xCord, yCord, Alt, time);
        }

        private string[] Seperator(string Seperate)
        {
            string pattern = "(;)";
            string[] result = Regex.Split(Seperate, pattern);

            return result;
        }

        private DateTime FormateDate(string RawDate)
        {
            string year = RawDate.Substring(0, 4);
            string month = RawDate.Substring(4, 2);
            string dateOfMonth = RawDate.Substring(6, 2);
            string hour = RawDate.Substring(8, 2);
            string minute = RawDate.Substring(10, 2);
            string second = RawDate.Substring(12, 2);
            string msec = RawDate.Substring(14, 3);

            DateTime dates = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(dateOfMonth), Int32.Parse(hour), Int32.Parse(minute), Int32.Parse(second), Int32.Parse((msec)));

            return dates;
        }

        public void transponderReceiverData( object sender, RawTransponderDataEventArgs e) 
        {
            foreach (var track in e.TransponderData)
            {
                Received = this.receive(track);
            }

            if (Received != null)
            {
                Received.print();
                if (_airspace != null)
                {
                    _airspace.ReceiveNewTOS(Received);
                }
                
            }

        }
    }

}