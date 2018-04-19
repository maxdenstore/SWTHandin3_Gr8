using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSystem
{
    public class Separtation
    {
        public Separtation(string tag, DateTime occurence)
        {
            Tag = tag;
            Occurence = occurence;
        }
        public string Tag { get; set; }
        public DateTime Occurence { get; set; }
    }
}
