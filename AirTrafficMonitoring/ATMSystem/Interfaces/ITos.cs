using System;

namespace TOS.Interfaces
{

        public interface ITOS
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