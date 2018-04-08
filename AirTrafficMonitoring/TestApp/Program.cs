using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOS;
using TransponderReceiver;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Converter con = new Converter(TransponderReceiverFactory.CreateTransponderDataReceiver());
            Console.ReadLine();

        }


    }
}