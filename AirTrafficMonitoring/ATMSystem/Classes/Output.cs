﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
