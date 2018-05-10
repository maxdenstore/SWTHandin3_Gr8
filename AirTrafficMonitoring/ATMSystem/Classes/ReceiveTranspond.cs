﻿using System;
using System.Text.RegularExpressions;
using ATMSystem;
using ATMSystem.Interfaces;


using TransponderReceiver;

namespace ATMSystem
{
    public class ReceiveTranspond :IReceive
    {

        private readonly IAirmonitor _airspace;
        private readonly ITransponderReceiver _transponderReceiver;
        private readonly IOutput _out;
        public EventArgs e = null;
        public TranspondObject Received;

        public ReceiveTranspond(ITransponderReceiver receiver, IOutput @out, IAirmonitor airSpace = null)
        {
            _transponderReceiver = receiver;
            _out = @out;

            _transponderReceiver.TransponderDataReady += transponderReceiverData;

            _airspace = airSpace;
        }

        public TranspondObject receive(string data)
        {
            var DataSep = Seperator(data);

            var tag = DataSep[0];
            var xCord = int.Parse(DataSep[2]);
            var yCord = int.Parse(DataSep[4]);
            var Alt = int.Parse(DataSep[6]);
            var time = FormateDate(DataSep[8]);

            return new TranspondObject(tag, xCord, yCord, Alt, time,_out);
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

        public void transponderReceiverData(object sender, RawTransponderDataEventArgs e)
        {
            foreach (var track in e.TransponderData)
            { 
            Received = receive(track);

            if (Received != null)
            {
                if (_airspace != null)
                {
                    //also calculate if its withing this airspace parameters!
                    //we only have one airspace so its defined here..
                    
                    if ((Received.PosistionX >= 10000) &&
                        (Received.PosistionY >= 10000) &&
                        (Received.PosistionX <= 90000) &&
                        (Received.PosistionY <= 90000))
                    {
                        _airspace.ReceiveNewTranspondObject(Received);
                    }

                    else //remove the aircraft from the airspace list
                    {
                        if (_airspace.monitorList.Exists(x => x.Tag == Received.Tag)) //check if it exsists in the airspace, means its now out of our airspace
                        {
                            _airspace.monitorList.RemoveAt(_airspace.monitorList.FindIndex(x => x.Tag == Received.Tag));
                        }
                        
                    }

                }
            }
        }
            }
    }

}