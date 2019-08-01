using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plate
{
    class UI
    {
        //TODO ovo ide u firmu!!!
        static HashSet<Pozicija> pozicije = new HashSet<Pozicija>();
        static List<Radnik> radnici = new List<Radnik>();
        static void Main(string[] args)
        {
            do
            {
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
                        Console.WriteLine("Unesite radno mesto, ime i prezime: ");
                        string[] pozicijaImeIprezime = Console.ReadLine().Split(' ');
                        
                        foreach (Pozicija p in UI.pozicije)
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
                            //TODO ovo ce da se menja!!
                            foreach (Radnik r in radnici)
                                if (r.ID == id)
                                {
                                        radnici.Remove(r);
                                        break;
                                }
                        }
                        break;
                    case 3:
                        foreach (Radnik r in radnici)
                            Console.WriteLine(r.ToString());
                        break;
                    case 4: //TODO greskaaaa
                        Console.WriteLine("Naziv radnog mesta i plata: ");
                        string[] unos = Console.ReadLine().Split(' ');
                        if (decimal.TryParse(unos[1], out decimal plata))
                        {
                            //UI.pozicije.Contains()
                            UI.pozicije.Add(new Pozicija(unos[0], plata));
                        }
                        break;
                    case 5:
                        foreach (Pozicija p in UI.pozicije)
                            Console.WriteLine(p.ToString());
                        break;
                }

            } while (true);
        }

        static void Meni()
        {
            Console.WriteLine("1. Unos radnika\n" +
                              "2. Otpusti radnika\n" +
                              "3. Pregled radnika\n" +
                              "4. Unos radnog mesta\n" +
                              "5. Lista radnih mesta\n");
            Console.WriteLine("karakter - Izlaz iz programa");
            Console.WriteLine("Izbor: ");
        }
    }
}
