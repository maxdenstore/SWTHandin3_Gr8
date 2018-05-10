using System;

namespace ATMSystem.Interfaces
{

        public interface ITranspondObject
        {
            string Tag { get; }
            int PosistionX { get; }
            int PosistionY { get; }
            int Altitude { get; }
            DateTime TimeStamp { get; }
            double Velocity { get; set; }
            double degress { get; set; }

        }
    }