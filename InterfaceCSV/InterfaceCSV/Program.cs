using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InterfaceCSV
{
    class Program
    {
        public static Dictionary<Artikal, int> recnik = new Dictionary<Artikal, int>();

        public static void dodajUrecnik(Artikal a, int kol)
        {
            //TODO ovo je mozda suvisno, testirati da li ce += na neinicijalizovanu vrednost
            //inicijalizovati int na 0 ili ce da izbije exception
            if (recnik.ContainsKey(a))
                recnik[a] += kol; //Ako vec imamo artikal dodajemo kolicinu na postojecu
            else
                recnik.Add(a, kol); //Ako ga nemamo,koristimo add
        }

        static void Main(string[] args)
        {
            /*Artikal prvi = new Artikal(50, 10, "001", "neki artikal");
            Artikal drugi = new Artikal(100, 3, "xyz", "drugi artikal");
            Artikal tri = new Artikal(90, 5, "007", "treci artikal");

            prvi.upisiUfajl("artikli.csv");
            drugi.upisiUfajl("artikli.csv");
            tri.upisiUfajl("artikli.csv");*/  //Upis artikala u fajl

            //HACK ovo treba popraviti
            while (Artikal.brojac < File.ReadAllLines("artikli.csv").Length) 
                new Artikal();
            Artikal.brojac = 0;
            

            foreach (Artikal a in Artikal.sviArtikli)
                Console.WriteLine(a.naziv);

            dodajUrecnik(Artikal.sviArtikli[0], 4); //Priprema kolicina i artikala za jedan racun
            dodajUrecnik(Artikal.sviArtikli[1], 2);
            dodajUrecnik(Artikal.sviArtikli[2], 2);
            dodajUrecnik(Artikal.sviArtikli[0], 3);

            Racun rac = new Racun(recnik); 
            rac.upisiUfajl("racuni.csv");
            Console.WriteLine(rac.ToString()); 

            Console.ReadKey();
        }
    }

    public interface IFileIO //U interfejsu smo napisali stvari koje zelimo da 
    {                         //da koriste i racun i artikal koji nam inace nemaju nikakvu vezu
        void upisiUfajl(string f);
        void ucitajIzFajla(string f);
        string formatZaFajl { get; } //Ne mozemo da imam promenljivu u interfejsu, no property
                                     //moze zato sto je on svakako set od dve metode,
                                     //gettera i settera a ne vrednost kao vrednost
    }

    class Artikal : IFileIO
    {
        internal int cena, stanje;
        internal string sifra, naziv;
        internal static List<Artikal> sviArtikli = new List<Artikal>();
        internal static int brojac; //brojac nam treba za citanja iz fajla
        public string formatZaFajl
        {  //Implementacija property-a je jednostavno zgodan format za upis u csv
            get => $"{this.sifra};{this.naziv};{this.stanje};{this.cena}{Environment.NewLine}";
        }

        public void upisiUfajl(string fajl)
        {   //No big deal :) kako za neki artikal pozovemo upis on svoje podatke doda u fajl
            File.AppendAllText(fajl, this.formatZaFajl);
        }
    
        public void ucitajIzFajla(string fajl)
        {
            //Ucitavamo red iz fajla, tj, ucitavamo sve redove pa uzmemo onaj koji nam 
            //treba po vrednosti staticnog brojaca i u isto vreme ga inkrementujemo
            //da drugima damo do znanja sta je njihovo
                string[] artikli = File.ReadAllLines(fajl);
                string[] artParametri = artikli[Artikal.brojac++].Split(';');
                this.sifra = artParametri[0];
                this.naziv = artParametri[1];
                this.stanje = int.Parse(artParametri[2]);
                this.cena = int.Parse(artParametri[3]);   
        }

        public Artikal()
        {
            //Ako pozovemo konstruktor bez parametara ucitavamo sledeci artikal iz
            //fajla ako takav postoji. Simpaticno, ovo je solidna metoda jer cak i ako
            //prekinemo ucitavanja iz fajla i dodamo novi artikal pozivajuci drugi konstruktor,
            //citanje iz fajla se kasnije nastavlja tacno tamo gde je stalo :)
            this.ucitajIzFajla("artikli.csv");
            Artikal.sviArtikli.Add(this);
        }

        public Artikal(int c, int s, string sifra, string n)
        {
            this.cena = c;
            this.stanje = s;
            this.sifra = sifra;
            this.naziv = n;
            Artikal.sviArtikli.Add(this);
        }
    }

    class Racun : IFileIO
    {
        //Unutar racuna imamo recnik koji za kljuc ima artikal a vrednost tog kljuca kolicinu
        //artikla na racunu
        Dictionary<Artikal, int> artikli;
        int total;
        public string formatZaFajl
        {
            get
            {
                string s = "";
                foreach (Artikal a in this.artikli.Keys)
                    s += $"{a.sifra};{this.artikli[a]};"; //Grabimo sifru iz objekta artikal
                s += $"{this.total}{Environment.NewLine}"; //i kolicinu iz recnika po tom kljucu
                return s;
            }
        }


        public Racun(Dictionary<Artikal, int> a)
        {
            this.artikli = a;
            foreach (Artikal art in this.artikli.Keys)
            {
                this.total += art.cena * this.artikli[art];
            }
        }

        
        public override string ToString()
        {
            string s = "Stavke:\n";
            foreach (Artikal a in this.artikli.Keys)
                s += $"{a.naziv} ---- {a.cena} ----- {this.artikli[a]}\n";
            s += "=======================\n";
            s += $"Total: {this.total}";
            return s;
        }

        public void ucitajIzFajla(string f)
        {
            throw new NotImplementedException();
        }

        public void upisiUfajl(string f)
        {
            File.AppendAllText(f, this.formatZaFajl);
        }
    }
}
