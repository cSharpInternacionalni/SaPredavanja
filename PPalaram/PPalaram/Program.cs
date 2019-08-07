using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPalaram
{
    class Program
    {
        static void Main(string[] args)
        {
            ProtivpozarniAlarm pp = new ProtivpozarniAlarm();
            pp.lokacijaAlarma = "neka";
            Civil c1 = new Civil();
            c1.adresa = "neka";
            Civil c2 = new Civil();
            c2.adresa = "drugde";
            Vatrogasac v = new Vatrogasac();
            //Kada "dodamo" funkciju u delegat on zna kako da je izvrsi. 
            //Kada pozovemo taj delegat on, u stvari, izvrsava redom metode koje su 
            //dodate u njega
            //Delegat pamti i gde je funkcija i tacno kom objektu pripada. 
            pp.pozar += c1.uSlucajuPozara;
            pp.pozar += v.posao;
            pp.pozar += c2.uSlucajuPozara;

            //Posto, po patternu za evente, metoda koja poziva delegat mora
            //da bude zasticena od eksternih faktora, pozivamo javnu metodu klase koja
            //sadrzi delegat a ta metoda onda odlucuje da li stvarno da aktivira delegat ili ne          
            //Ovo je u potpunosti logicno, ako pogledamo nas primer, naravno da alarm hoce
            //da se zastiti od spoljnih uticaja i da samo on odlucuje kada ce da zvoni, a ne
            //da mu neko peti odredi to

            pp.proveriPozar();

            Console.ReadKey();
        }
    }

    //Po patternu za evente argumenti koji su nam potrebni za neki event idu u svoju klasu
    //koja ima postfix EventArgs i nasledjuje sistemsku klasu EventArgs. Ovakva separacija je super,
    //jer ako kasnije dodajemo druge argumente, refaktoring vrsimo samo tamo gde imaju uticaja. A da ih nismo
    //izdvojili onda cim dodamo novi argument moramo da menjamo sve sto ima veze sa ovim eventom
    class AlarmEventArgs : EventArgs
    {
        //readonly mogu da se menjaju sve dok se konstruktor ne zavrsi, po zavrsetku konstruktora nema vise izmene
        private void foo()
        {   //Sledeci red ce da baca gresku, zato sto nema izmena van konstruktora. Readonly je 
            //jos restriktivnije od private set

            //this.lokacija = "asd";
        }
        public readonly string lokacija = "nesto";
        public readonly int jacinaPozara = 0;
        public AlarmEventArgs(string s, int j)
        {
            this.lokacija = s;
            this.jacinaPozara = j;
        }
    }

    class ProtivpozarniAlarm
    {
        public string lokacijaAlarma = "neka";

        //Da bi napravili delegat prvo moramo da definisemo njegov tip.
        //Sa ovim redom radimo upravo to, kazemo da zelimo da imamo delegate 
        //void povratnog tipa i sa objektom i AlarmEventArgs kao ulaznim tipovima
        //Po patternu delegat treba uvek da ima informaciju o tome ko ga salje, zato nam je 
        //objekat prvi. Takodje po patternu, delegat ima postfix EventHandler
        //da bi znali da je u tom sistemu na prvi pogled
        public delegate void AlarmEventHandler(object koZovni, AlarmEventArgs e);

        //Kada smo napravili tip delegata sada mozemo da definisemo i promenljivu tog tipa
        //event je restriktivan tip delegata. Kada kazemo da je neki delegat event, efektivno
        //blokiramo sve van klase u kojoj je napravljen da urade bilo sta sem += -= da bi "slusali"
        // i da prestanu da slusaju. Tako smo onemogucili da neki objekat stavi citav delegat na null 
        //i zabrani svima da "cuju" da se nesto dogodilo.
        public event AlarmEventHandler pozar;
        //this.pozar() isto kao ovo ispod :)

        //Po patternu, stitimo metodu koja poziva nas delegat od vanjskog sveta. Dozvoljavamo deci da je
        //prepisu, recimo mozda cemo imati neki drugi alarm sa drugim potrebama, i on moze da kontrolise ovo
        //ali neko ko nije dete ove klase ne sme da ima kontakta sa ovim metodom.
        //Po patternu, prefiks metoda koji starta event je uvek on...
        protected virtual void OnAlarm() => this.pozar?.Invoke(this, new AlarmEventArgs(this.lokacijaAlarma, 500));

        //Za sve van nase klase, imamo javni metod tako da imamo taj momenat kontrole
        //gde unutar nase klase mozemo da odlucimo da li zovemo event ili ne. Da nije tako, svako bi mogao
        //da pokrene event i potencijalno pokrene metode na ko zna koliko objekata. Ovo nam je jos
        //jedan fino nivo separacije gde je za pokretanje alarma odgovoran samo alarm i niko drugi
        public void proveriPozar()
        {
            //logika koja proverava da li je do pozara doslo
            //ili ne
            this.OnAlarm();
        }
    }

    class Civil
    {
        public string adresa = "neka";

        //Metoda koju cemo da dodamo u delegat. Tok je da se event dogodi -> alarm odluci da pokrene delegat
        //-> delegat poziva funkciju ovog objekta da se izvrsi
        //Ovde vidimo dobar razlog zasto nam alarm salje i sebe, kao objekat. Mozda je nas civil mnogo strasljiv,
        //i ova metoda u kojoj bezi je povezana na ko zna koliko evenata. Da, po patternu, nismo poslali
        //i objekat, ova klasa ne moze da zna ko je pozvao funkciju.
        //Primer kod UI-a, ako imamo dugme koje treba da odradi slicnu stvar ako neko uradi drag and drop na
        //nju i ako neko klikne na nju. Imala bi jednu metodu koja slusa dva razlicita eventa. Kada
        //se ta metoda pozove iz nekog od evenata ona ne moze da ima informaciju o tome sta se dogodilo, 
        //nego samo da se nesto dogodilo. Time sto dobije objekat koji ju je pozvao, pored argumenata,
        //moze da razazna sta je tacno uzrocni dogadjaj.
        //Primer, jos jedan, ovde bi bio da nas civil slusa tri razlicita alarma. Mogao bi da 
        //proba if (zvoni is protivPozarniAlarm a)... da napipa koji se tacno alarm oglasio
        //ili da ima 
        //switch(zvoni)
        //{
        //  case ppAlarm a:
        //      U slucaju pozara...
        //        break;
        //  case nekiDrugiAlarm a:
        //      Neki drugi slucaj...
        //        break;
        //}
        public void uSlucajuPozara(object zvoni, AlarmEventArgs e)
        {
            if (this.adresa.Equals(e.lokacija))
                Console.WriteLine("Beeeeezim!");
            else
                Console.WriteLine("Siguran sam :)");
        }
    }

    class Vatrogasac
    {
        public void posao(object alarm, AlarmEventArgs e)
        {
            Console.WriteLine($"Gasim pozar na {e.lokacija}!");
        }
    }

}
