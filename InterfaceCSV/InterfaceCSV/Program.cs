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
            if (recnik.ContainsKey(a))
                recnik[a] += kol;
            else
                recnik.Add(a, kol);
        }

        static void Main(string[] args)
        {
            /*Artikal prvi = new Artikal(50, 10, "001", "neki artikal");
            Artikal drugi = new Artikal(100, 3, "xyz", "drugi artikal");
            Artikal tri = new Artikal(90, 5, "007", "treci artikal");

            prvi.upisiUfajl("artikli.csv");
            drugi.upisiUfajl("artikli.csv");
            tri.upisiUfajl("artikli.csv");*/

            Artikal.ucitajIzFajla("artikli.csv");

            foreach (Artikal a in Artikal.sviArtikli)
                Console.WriteLine(a.naziv);

            /*dodajUrecnik(prvi, 4);
            dodajUrecnik(drugi, 2);
            dodajUrecnik(prvi, 2);
            dodajUrecnik(tri, 3);

            Racun rac = new Racun(recnik);

            Console.WriteLine(rac.ToString()); */

            Console.ReadKey();
        }
    }

    public interface IFileIO
    {
        void upisiUfajl(string f);
        
        string formatZaFajl { get; }
    }

    class Artikal : IFileIO
    {
        internal int cena, stanje;
        internal string sifra, naziv;
        internal static List<Artikal> sviArtikli = new List<Artikal>();
        public string formatZaFajl
        {
            get => $"{this.sifra};{this.naziv};{this.stanje};{this.cena}{Environment.NewLine}";
        }

        public void upisiUfajl(string fajl)
        {
            File.AppendAllText(fajl, this.formatZaFajl);
        }
    
        public static void ucitajIzFajla(string fajl)
        {
            Artikal.sviArtikli.Clear();

            foreach(String art in File.ReadAllLines(fajl))
            {
                string[] artParametri = art.Split(';');
                string sifra = artParametri[0];
                string naziv = artParametri[1];
                int kolicina = int.Parse(artParametri[2]);
                int cena = int.Parse(artParametri[3]);

                Artikal.sviArtikli.Add(new Artikal(kolicina, cena, sifra, naziv));
            }
        }

        public Artikal()
        { }

        public Artikal(int c, int s, string sifra, string n)
        {
            this.cena = c;
            this.stanje = s;
            this.sifra = sifra;
            this.naziv = n;
        }
    }

    class Racun
    {
        Dictionary<Artikal, int> artikli;
        int total;

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
    }
}
