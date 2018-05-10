using System.Collections.Generic;

namespace ATMSystem.Interfaces
{
    public interface IAirmonitor
    {
        void ReceiveNewTranspondObject(ITranspondObject NewTOS);
        List<TranspondObject> monitorList { get; set; }

    }
}