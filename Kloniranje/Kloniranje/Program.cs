using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kloniranje
{
    class Stanica
    {
        internal string naziv;
    }
    class Bus : ICloneable
    {
        internal int predjenoKilometara;
        internal Stanica trenutna;

        public object Clone()
        {
            Bus temp = (Bus)this.MemberwiseClone();
            Stanica neka = new Stanica();
            neka.naziv = this.trenutna.naziv;
            temp.trenutna = neka;
            //temp.predjenoKilometara = this.predjenoKilometara;
            //temp.stanica = this.stanica;
            return temp;
        }
    }

    class Izvestaj
    {
        internal Bus nekiBus;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bus a = new Bus();
            a.predjenoKilometara = 250;
            Stanica s = new Stanica();
            s.naziv = "Novi Pazar";
            a.trenutna = s;

            Izvestaj izv = new Izvestaj();
            izv.nekiBus = (Bus)a.Clone();
            s.naziv = "asd";
            a.predjenoKilometara = 500;
            s = new Stanica();
            s.naziv = "Senta";
            a.trenutna = s;

        }
    }
}
