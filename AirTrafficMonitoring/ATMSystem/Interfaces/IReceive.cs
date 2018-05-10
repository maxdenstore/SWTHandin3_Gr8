using TransponderReceiver;

namespace ATMSystem.Interfaces
{
    public interface IReceive
    {
        void transponderReceiverData(object sender, RawTransponderDataEventArgs e);
    }
}