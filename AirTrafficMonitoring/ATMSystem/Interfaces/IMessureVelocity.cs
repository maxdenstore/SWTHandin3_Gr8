namespace ATMSystem.Interfaces
{
    public interface IMessureVelocity
    {
        double velocity { get; set; }
        void Measure(TOS.TOS old, TOS.TOS newer);
    }
}