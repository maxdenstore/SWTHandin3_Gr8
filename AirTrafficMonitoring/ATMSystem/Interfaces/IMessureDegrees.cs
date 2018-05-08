namespace ATMSystem.Interfaces
{
    public interface IMessureDegrees
    {
        double degrees { get; set; }
        void Measure(TOS.TOS old, TOS.TOS newer);
    }
}