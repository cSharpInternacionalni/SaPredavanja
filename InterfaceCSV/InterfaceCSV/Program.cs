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
            Artikal prvi = new Artikal(50, 10, "001", "neki artikal");
            Artikal drugi = new Artikal(100, 3, "xyz", "drugi artikal");
            Artikal tri = new Artikal(90, 5, "007", "treci artikal");

            dodajUrecnik(prvi, 4);
            dodajUrecnik(drugi, 2);
            dodajUrecnik(prvi, 2);
            dodajUrecnik(tri, 3);

            Racun rac = new Racun(recnik);

            Console.WriteLine(rac.ToString());
            
            Console.ReadKey();
        }
    }

    public interface FileIO
    {
        void upisiUfajl(File f);
        void ucitajIzFajla(File f);
        string formatZaFajl { set; get; }
    }

    class Artikal : FileIO
    {
        internal int cena, stanje;
        internal string sifra, naziv;

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
