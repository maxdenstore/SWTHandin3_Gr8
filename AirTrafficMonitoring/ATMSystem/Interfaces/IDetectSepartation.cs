using System.Collections.Generic;
using TOS.Interfaces;

namespace ATMSystem.Interfaces
{
    public interface IDetectSepartation
    {
        void detect(ITOS a, ITOS b);
        void handleConflict(ITOS a, ITOS b);
        void handleNoConflict(ITOS a, ITOS b);

        void printSeparations();
    }
}