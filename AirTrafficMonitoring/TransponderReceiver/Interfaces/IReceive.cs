using TransponderReceiver;

namespace TOS.Interfaces
{
    public interface IReceive
    {
        void transponderReceiverData(object sender, RawTransponderDataEventArgs e);
    }
}