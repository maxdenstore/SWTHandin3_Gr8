using System;
using System.Text.RegularExpressions;
using ATMSystem.Interfaces;
using TransponderReceiver;

namespace ATMSystem
{
    public class ReceiveTranspond : IReceive
    {
        private readonly IAirmonitor _airspace;
        private readonly IOutput _out;
        private readonly ITransponderReceiver _transponderReceiver;
        public EventArgs e = null;
        public TranspondObject Received;

        public ReceiveTranspond(ITransponderReceiver receiver, IOutput @out, IAirmonitor airSpace = null)
        {
            _transponderReceiver = receiver;
            _out = @out;

            _transponderReceiver.TransponderDataReady += transponderReceiverData;

            _airspace = airSpace;
        }

        public void transponderReceiverData(object sender, RawTransponderDataEventArgs e)
        {
            foreach (var track in e.TransponderData)
            {
                Received = Receive(track);

                if (Received != null)
                    if (_airspace != null)
                        _airspace.ReceiveNewTranspondObject(Received);
            }
        }


        public TranspondObject Receive(string data)
        {
            var DataSep = Seperator(data);

            var tag = DataSep[0];
            var xCord = int.Parse(DataSep[2]);
            var yCord = int.Parse(DataSep[4]);
            var Alt = int.Parse(DataSep[6]);
            var time = FormateDate(DataSep[8]);

            return new TranspondObject(tag, xCord, yCord, Alt, time, _out);
        }

        private string[] Seperator(string Seperate)
        {
            var pattern = "(;)";
            var result = Regex.Split(Seperate, pattern);

            return result;
        }

        private DateTime FormateDate(string RawDate)
        {
            var year = RawDate.Substring(0, 4);
            var month = RawDate.Substring(4, 2);
            var dateOfMonth = RawDate.Substring(6, 2);
            var hour = RawDate.Substring(8, 2);
            var minute = RawDate.Substring(10, 2);
            var second = RawDate.Substring(12, 2);
            var msec = RawDate.Substring(14, 3);

            var dates = new DateTime(int.Parse(year), int.Parse(month), int.Parse(dateOfMonth), int.Parse(hour),
                int.Parse(minute), int.Parse(second), int.Parse(msec));

            return dates;
        }
    }
}