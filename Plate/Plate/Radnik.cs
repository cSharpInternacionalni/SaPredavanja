using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plate
{
    class Radnik
    {
        //TODO titula
        internal string Ime { private set; get; }
        internal string Prezime { private set; get; }
        internal string PunoIme
        {
            get => $"{this.Prezime} {this.Ime}";
        }

        internal uint neplaceniDani;

        //Celobrojno izrazen procenat, +- na platu
        internal int modifikator;

        //EXP objasni properties i pozadinska polja
        //EXP objasni tagove, kada smo kod toga :D
        private long id;
        internal long ID
        {
          private set => this.id = Radnik.iduciID++;
          get => this.id;
        }

        static long iduciID;

        public Radnik(string i, string p)
        {
            this.Ime = i;
            this.Prezime = p;
            //HACK koristimo property, vrednost se zanemaruje ovde
            this.ID = 0;
        }

        /*Lambda izraz, ovo je isto kao i
         * public override string ToString()
         * {
         *      return $"{this.ID} -- {this.PunoIme}";
         * } */
        public override string ToString() => $"{this.ID} -- {this.PunoIme}";
    }
}
