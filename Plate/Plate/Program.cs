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
                        if (UI.pozicije.Count == 0)
                            break;
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
                            foreach (Pozicija p in UI.pozicije)
                            {
                                bool otpusten = false;  
                                foreach (Radnik r in p.radnici)
                                    if (r.ID == id)
                                    {
                                        p.radnici.Remove(r);
                                        otpusten = true;
                                        break;
                                    }
                                if (otpusten)
                                    break;
                            }
                        }
                        break;
                    case 3:
                        foreach (Pozicija p in UI.pozicije)
                            foreach (Radnik r in p.radnici)
                                Console.WriteLine(r.ToString());
                        break;
                    case 4: //TODO greskaaaa
                        Console.WriteLine("Naziv radnog mesta i plata: ");
                        string[] unos = Console.ReadLine().Split(' ');
                        if (decimal.TryParse(unos[1], out decimal plata))
                        {
                            bool duplikat = false;
                            foreach (Pozicija p in UI.pozicije)
                                if (p.naziv.Equals(unos[0]))
                                {
                                    duplikat = true;
                                    p.plata = plata;
                                    break;
                                }
                            if (!duplikat)
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
                              "4. Unos/izmena radnog mesta\n" +
                              "5. Lista radnih mesta\n");
            Console.WriteLine("Izbor: ");
        }
    }
}
