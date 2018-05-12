using System;
using ATMSystem.Interfaces;

namespace ATMSystem
{
    public class Output : IOutput
    {
        public void Print(string _out)
        {
            Console.WriteLine(_out);
        }

        public void ClearScreen()
        {
            Console.Clear();
            Console.WriteLine("New data: ");
        }
    }
}