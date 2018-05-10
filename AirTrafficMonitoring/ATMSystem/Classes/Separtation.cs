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
        public IOutput _out;
        public Separtation(string tag, DateTime occurence, IOutput @out)
        {
            Tag = tag;
            Occurence = occurence;
            _out = @out;
        }


        public void PrintSeperation()
        {
         
            _out.Print("Seperation event occured: Tag" + Tag + " Occurance: " + Occurence);
        }

        public string Tag { get; set; }
        public DateTime Occurence { get; set; }
    }
}
