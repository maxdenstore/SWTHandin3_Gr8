using System.Collections.Generic;

namespace ATMSystem.Interfaces
{
    public interface IDetectSepartation
    {
        void detect(ITranspondObject a, ITranspondObject b);


        void printSeparations();

        bool Conflict { get; set; }
    }
}