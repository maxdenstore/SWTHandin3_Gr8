using System.Collections.Generic;

namespace ATMSystem.Interfaces
{
    public interface IAirmonitor
    {
        void ReceiveNewTranspondObject(TranspondObject NewTOS);
        List<TranspondObject> monitorList { get; set; }

    }
}