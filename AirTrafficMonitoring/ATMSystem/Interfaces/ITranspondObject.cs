using System;

namespace ATMSystem.Interfaces
{

        public interface ITranspondObject
        {
            string Tag { get; set; }
            int PosistionX { get; set; }
            int PosistionY { get; set; }
            int Altitude { get; set; }
            DateTime TimeStamp { get; }
            double Velocity { get; set; }
            double degress { get; set; }

            void Print();

        }
    }