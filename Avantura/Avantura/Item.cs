using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avantura
{
    internal abstract class Item
    {
        protected double tezina;
        protected string naziv;
    }

    internal class Kljuc : Item
    {
        //TODO auto generisanje kljuceva
        (Soba soba, Pravci pravac) otkljucava;

        public Kljuc(Soba s, Pravci p)
        {
            this.otkljucava.soba = s;
            this.otkljucava.pravac = p;
            this.tezina = 0.1;
            this.naziv = $"Kljuc -- {s.Opis} -- {p}";
        }

        public override string ToString()
        {
            return naziv;
        }
    }
}
