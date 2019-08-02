using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plate
{
    class Radnik
    {
        internal Pozicija radnoMesto { private set; get; }
        internal string Ime { private set; get; }
        internal string Prezime { private set; get; }
        internal string PunoIme
        {
            get => $"{this.Prezime} {this.Ime}";
        }
        //TODO ovo ne koristimo jos!
        internal uint neplaceniDani;

        //Celobrojno izrazen procenat, +- na platu
        internal int modifikator;

        internal long ID { private set; get; }

        static long iduciID;

        public Radnik(string i, string p, Pozicija poz)
        {
            this.Ime = i;
            this.Prezime = p;
            this.ID = iduciID++;
            this.radnoMesto = poz;
            this.radnoMesto.radnici.Add(this);
        }

        /*Lambda izraz, ovo je isto kao i
         * public override string ToString()
         * {
         *      return $"{this.ID} -- {this.PunoIme}";
         * } */
        public override string ToString() => $"{this.ID} -- {this.radnoMesto.naziv} -- {this.PunoIme}";
    }

    class Pozicija
    {
        internal string naziv { private set; get; }
        internal decimal plata { set; get; }
        internal List<Radnik> radnici = new List<Radnik>();
        internal Pozicija(string n, decimal p)
        {
            this.naziv = n;
            this.plata = p;
        }

        public override string ToString() => $"{this.naziv} -- Plata: {this.plata} -- Broj zaposlenih na radnom mestu: {this.radnici.Count}";
    }
}
