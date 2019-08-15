using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plate
{
    class UI
    {
        //TODO ovo ide u firmu!!!
        static void Main(string[] args)
        {
            /*
             * Rad sa falovima
             * File.WriteAllText("test.txt", "Bla bla");
            File.AppendAllText("test.txt", "Dodatno");
            

            String[] niz = { "jen", "dva", "tri" };
            File.WriteAllLines("niz.txt", niz);
            string a = File.ReadAllText("niz.txt");
            string[] b = File.ReadAllLines("niz.txt");
            Console.WriteLine(a);
            foreach (string s in File.ReadLines("niz.txt"))
                Console.WriteLine(s);
            Console.ReadKey(); */
            

            do
            {
                Firma.pozicije.Add(new Pozicija("proba", 500));
            
                new Radnik("Pera", "Peric", Firma.pozicije.Last());

                Firma.isplati(Firma.pozicije.Last(), 300);

                Firma.pozicije.Last().radnici.Clear();
                Firma.isplati(Firma.pozicije.Last(), 300);

                Meni();
                //True kod ReadKey samo znaci da nece ispisivati 
                //sta smo uneli u konzolu
                ConsoleKeyInfo dugme = Console.ReadKey(true);
                if (!(int.TryParse(dugme.KeyChar.ToString(), out int izbor)))
                    break; //inverzija, ako nije prosao onda idemo na if
                           //i ispadamo iz petlje
                           //Samo radi citljivosti je ovako
                
                switch(izbor)
                {
                    case 1:
                        if (Firma.pozicije.Count == 0)
                            break;
                        Console.WriteLine("Unesite radno mesto, ime i prezime: ");
                        string[] pozicijaImeIprezime = Console.ReadLine().Split(' ');
                        
                        foreach (Pozicija p in Firma.pozicije)
                        {
                            if (p.naziv.Equals(pozicijaImeIprezime[0]))
                            {
                                //Radnik sam po sebi idu u listu
                                //pa nam ne treba referenca ovde
                                new Radnik(pozicijaImeIprezime[1], pozicijaImeIprezime[2], p);
                                break;
                            }
                        }

                        
                        break;
                    case 2:
                        Console.WriteLine("Unesite id");
                        if (long.TryParse(Console.ReadLine(), out long id))
                        {
                            if (Firma.radnikPoId(id, out Radnik ra))
                                ra.radnoMesto.radnici.Remove(ra);
                        }
                        break;
                    case 3:
                        foreach (Pozicija p in Firma.pozicije)
                            foreach (Radnik ra in p.radnici)
                                Console.WriteLine(ra.ToString());
                        break;
                    case 4: //TODO greskaaaa
                        Console.WriteLine("Naziv radnog mesta i plata: ");
                        string[] unos = Console.ReadLine().Split(' ');
                        if (decimal.TryParse(unos[1], out decimal plata))
                        {
                            bool duplikat = false;
                            foreach (Pozicija p in Firma.pozicije)
                                if (p.naziv.Equals(unos[0]))
                                {
                                    duplikat = true;
                                    p.plata = plata;
                                    break;
                                }
                            if (!duplikat)
                                Firma.pozicije.Add(new Pozicija(unos[0], plata));
                        }
                        break;
                    case 5:
                        foreach (Pozicija p in Firma.pozicije)
                            Console.WriteLine(p.ToString());
                        break;
                    case 6: 
                        Console.WriteLine("Unesite id radnika: ");
                        if (!long.TryParse(Console.ReadLine(), out long idR))
                            break;
                       // if (Firma.radnikPoId(idR, out Radnik r))
                            //Firma.balans -= r.radnoMesto.plata;

                        break;
                    case 7:
                        Console.WriteLine("Unesite iznos: ");
                        //if (decimal.TryParse(Console.ReadLine(), out decimal novac))
                            //Firma.balans += Math.Abs(novac);
                        break;
                    case 8:
                        Console.WriteLine($"Balans: {Firma.balans}");
                        break;
                }

            } while (true);
        }

        static void Meni()
        {
            Console.WriteLine("1. Unos radnika\n" +
                              "2. Otpusti radnika\n" +
                              "3. Pregled radnika\n" +
                              "4. Unos/izmena radnog mesta\n" +
                              "5. Lista radnih mesta\n" +
                              "6. Isplata\n" +
                              "7. Uplata\n" +
                              "8. Stanje\n");
            Console.WriteLine("Izbor: ");
        }
    }
}
