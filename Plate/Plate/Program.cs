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
                        Console.WriteLine("Unesite ime i prezime: ");
                        string[] imeIprezime = Console.ReadLine().Split(' ');
                        UI.radnici.Add(new Radnik(imeIprezime[0], imeIprezime[1]));
                        break;
                    case 3:
                        foreach (Radnik r in radnici)
                            Console.WriteLine(r.ToString());
                        break;
                }

            } while (true);
        }

        static void Meni()
        {
            Console.WriteLine("1. Unos radnika\n" +
                              "2. Otpusti radnika\n" +
                              "3. Pregled radnika\n");
            Console.WriteLine("karakter - Izlaz iz programa");
            Console.WriteLine("Izbor: ");
        }
    }
}
