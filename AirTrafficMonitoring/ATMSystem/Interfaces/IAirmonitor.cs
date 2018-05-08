using System.Collections.Generic;

namespace ATMSystem.Interfaces
{
    public interface IAirmonitor
    {
        void ReceiveNewTOS(TOS.TOS NewTOS);
        List<TOS.TOS> monitorList { get; set; }

    }
}