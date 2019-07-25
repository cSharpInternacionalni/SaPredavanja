using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avantura
{
    public enum Pravci : byte
    {
        sever, 
        istok,
        jug,
        zapad
    }
    class Soba
    {
        //Opis citamo odakle god iz asemblija,
        //pa je internal, no setter nam je 
        //private da se osiguramo da nesto trece
        //nije u stanju da ga zameni 
        internal string Opis { get; private set; }

        //Svaka soba pamti reference ka 
        //sobama koje su joj susedne
        private (Soba soba, bool zakljucana)[] povezaneSobe = new (Soba, bool)[4];

        //TODO treba lista za predemete unutar sobe

        public bool prohodno(int i, out Soba s)
        { //Funkcija koja proverava imamo li
          //sobu u nekom pravcu. Vracamo bool 
          //po kome znamo da li ima sobe i da je 
          //smestena u s, ili nema i s je null
            s = this.povezaneSobe[i].soba;
            return (s == null) ? false : true;
        }

        public bool zakljucana(Pravci p) => this.povezaneSobe[(int)p].zakljucana;
        

        public Soba(string s)
        {
            this.Opis = s;
        }

        public static void poveziSobe(Soba a, Soba b, Pravci p, bool z = false)
        {

            int pravac = (int)p;
            //Kada povezujemo sobu proveravamo da vec nema sobu
            //u tom pravcu, i ako je ima, podesava izlaz iz druge sobe
            //na null, da ne bi slucajno dobili situaciju da imamo
            //dve sobe koje vode ka jednoj istoj sobi
            if (a.povezaneSobe[pravac].soba!= null)
                a.povezaneSobe[pravac].soba.povezaneSobe[(pravac + 2) % 4].soba = null;

            a.povezaneSobe[pravac].soba = b;
            if (z)
                a.povezaneSobe[pravac].zakljucana = true;
            //Posto su nam sobe u moguca 4 pravca,
            //kada pravimo izlaz iz jedne na istok,
            //moramo drugoj da napravimo izlaz na zapadu
            //       0
            //   3  Soba   1
            //       2
            //Posto imamo 4 pravca, ako dodamo 2 na trenutni
            //dobili smo njemu suprotan. % 4 nas drzi
            //u zoni od 0 do 3, npr ako idemo na zapad (3)
            //znaci 3+2 = 5, ispadamo iz duzine niza,
            //no onda 5%4 = 1, i tacno smo gde treba da budemo
            b.povezaneSobe[(pravac + 2) % 4].soba = a;            
        }
    }
}
