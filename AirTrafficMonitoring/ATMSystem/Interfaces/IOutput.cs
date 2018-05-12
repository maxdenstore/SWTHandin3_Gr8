using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSystem.Interfaces
{
    public interface IOutput
    {
        void Print(string _out);
        void ClearScreen();
    }
}
