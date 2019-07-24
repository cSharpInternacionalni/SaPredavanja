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

        public Igrac(Soba s)
        {
            this.TrenutnaSoba = s;
        }
        
    }
}
