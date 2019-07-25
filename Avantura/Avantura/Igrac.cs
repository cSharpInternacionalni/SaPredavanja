using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avantura
{
    class Igrac
    {
        //Soba u kojoj se trenutno nalazimo
        internal Soba TrenutnaSoba
        {set; get; }
        internal bool imaKljuc;


        public Igrac(Soba s)
        {
            this.TrenutnaSoba = s;
        }

        public bool otkljucano(Soba s)
        {
            return false;
        }
        
    }
}
