using TransponderReceiver;

namespace ATMSystem.Interfaces
{
    public interface IReceive
    {

        void transponderReceiverData(object sender, RawTransponderDataEventArgs e);

        /// <summary>
        /// put in a string with flith info
        /// </summary>
        /// <param name="data">The flight info</param>
        /// <returns>transponder Object</returns>
        TranspondObject Receive(string data);
    }
}