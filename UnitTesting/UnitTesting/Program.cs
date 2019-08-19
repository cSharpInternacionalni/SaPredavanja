using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class MathHelper
    {
        public int Saberi(int x, int y) =>
            x + y;
        public int Oduzmi(int x, int y) =>
            x - y;
    }

    public class ObjectTest
    {
        public Dobrovoljac CAPS(Dobrovoljac d)
        {
            d.naziv = d.naziv.ToUpper();
            return d;
        }
            
    }

    public class Dobrovoljac
    {
        //Ako imamo klasu koju zelimo da poredimo niko nam tu nece pomoci
        //Mi smo duzni da napisemo override za Equals i objasnimo koje uslove
        //dva objekta moraju da ispunjavaju da bi ih smatrali jednakima.
        //Imamo svu slobodu ovde tako da je mogu da napisem metodu koja kaze
        //da je moj objekat jednak iskljucivno stringu "MasterJEDNAKO" i to ce tako 
        //da bude :D vise ni objA.Equals(objA), sto bi bilo tacno za object klasu
        //nece da bude istinito, slobodni smo skroz.
        public override bool Equals(object obj)
        /*{//Imajmo u vidu da Equals, kako ga je object definisao uzima object za argument
            //pa smo prvo duzni da se uverimo da je objekat koji smo dobili za poredjenje
            //klase sa kojom zelimo da ga poredimo. A posto nam is daje objekat koji
            //odmah mozemo da konzumiramo a samo jednu proveru imamo to smo povezali sa && ovde.
            //Posto je && short-circuit, tj. cim vidi da nece moci da izadje na true odmah
            //staje i ne proverava dalje, to nas spasi u ovom momentu jer, ako
            //obj nije tipa Dobrovoljac ono ce da vrati false, kompajler je svestan
            //da je false && bilo sta false pa samim tim nece ni da pokusa drugi uslov.
            //Da koristimo samo &, ono proverava sve uslove, pa bi, samim tim, 
            //u slucaju da obj nije Dobrovoljac ipak pokusao da evaluira i drugi korak 
            //i izazvao exception
            if (obj is Dobrovoljac d && d.naziv.Equals(this.naziv))
                return true;
            return false;
            //CHALLENGE ovo moze da stane u jedan fin red, sve sa => :) moze li ko? 
        }*/

        //Zgodno je imati fin override na ToString jer ce se on cesto pozvati nad objektom
        //kada komplajer ili neko tamo :D, pokusava da nam saopsti nesto o istom, pa ako
        //imamo smislen ToString() bude koristan i ako ga mi licno ne koristimo. 
        //Videli smo da testing framework poziva ovu metodu kada hoce da nam objasni
        //na koji objekat misli
        public override string ToString() =>
            $"Dobrovoljac {this.naziv} ovde :)";
        public string naziv = "malimslovima";
    }

}
