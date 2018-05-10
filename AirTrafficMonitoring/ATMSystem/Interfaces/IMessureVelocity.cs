namespace ATMSystem.Interfaces
{
    public interface IMessureVelocity
    {
        void Measure(ITranspondObject old, ITranspondObject newer);
    }
}