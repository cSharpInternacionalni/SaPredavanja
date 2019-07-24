using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avantura
{
    class Program
    {
        static Igrac pc; //igrac nam je stanje
                        //da ne bi imali potrebu
                        //da ga bacamo funkcijama unutar
                        //klase, ovako ga sve vide

        static void Main(string[] args)
        {
            //Init faza, pravimo sobe i igraca
            Soba a = new Soba("prva");
            Soba b = new Soba("druga");
            Soba c = new Soba("treca");

            Soba.poveziSobe(a, b, 1);
            Soba.poveziSobe(b, c, 0);

            pc = new Igrac(a);

            do  //Game loop
            {
                Console.WriteLine(pc.TrenutnaSoba.Opis);
                Console.Write(": ");

                /* Isto kao: 
                 * string unos = Console.ReadLine();
                    string odgovor = interpreter(unos);
                    Console.WriteLine(odgovor); */
                Console.WriteLine(interpreter(Console.ReadLine()));
                Console.ReadKey();
            } while (true);
        }

        //metoda koja cita sta korisnik hoce
        //i pokusava da to izvrsi nad igracem
        private static string interpreter(string unos)
        {
            if (int.TryParse(unos, out int indeks)
                && indeks >= 0 && indeks <= 3)
            {
                if (pc.TrenutnaSoba.prohodno(indeks, out Soba s))
                {
                    pc.TrenutnaSoba = s;
                    return "Prelazite u drugu sobu...";
                }
                else
                    return "Ne mozete u tom pravcu!";
            }
            return "ERR";
        }
    }
}