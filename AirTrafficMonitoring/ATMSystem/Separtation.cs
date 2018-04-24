using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMSystem.Interfaces;

namespace ATMSystem
{
    public class Separtation :ISeperation
    {
        public Separtation(string tag, DateTime occurence)
        {
            Tag = tag;
            Occurence = occurence;
        }


        public void PrintSeperation()
        {
            Console.WriteLine("Seperation event occured: Tag" + Tag + " Occurance: " + Occurence);

        }

        public string Tag { get; set; }
        public DateTime Occurence { get; set; }
    }
}
