using System.Collections.Generic;

namespace ATMSystem.Interfaces
{
    public interface IAirmonitor
    {
        void ReceiveNewTranspondObject(ITranspondObject NewTOS);
        List<ITranspondObject> monitorList { get; set; }

    }
}