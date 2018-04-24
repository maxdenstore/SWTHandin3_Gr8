using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSystem.Interfaces
{
    interface ISeperation
    {
        string Tag { get; set; }
        DateTime Occurence { get; set; }
        void PrintSeperation();

    }
}
