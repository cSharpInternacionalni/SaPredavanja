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
            Soba d = new Soba("cetvrta");
            Soba e = new Soba("peta");
            Soba f = new Soba("sesta");
            Soba g = new Soba("sedma");

            Soba.poveziSobe(a, b, Pravci.istok);
            Soba.poveziSobe(b, c, Pravci.sever);
            Soba.poveziSobe(c, d, Pravci.zapad);
            Soba.poveziSobe(c, e, Pravci.istok);
            Soba.poveziSobe(c, f, Pravci.sever);
            Soba.poveziSobe(f, g, Pravci.sever);

            pc = new Igrac(a);

            do  //Game loop
            {
                Console.WriteLine(pc.TrenutnaSoba.Opis);
                Console.Write(": ");

                /* Isto kao: 
                 * string unos = Console.ReadLine();
                    string odgovor = interpreter(unos);
                    Console.WriteLine(odgovor); */
                Console.WriteLine(interpreter(Console.ReadKey(true)));
                Console.WriteLine();
            } while (true);
        }

        //metoda koja cita sta korisnik hoce
        //i pokusava da to izvrsi nad igracem
        private static string interpreter(ConsoleKeyInfo unos)
        {
            int pravac = -1;
            switch (unos.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    pravac = (byte)Pravci.sever;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    pravac = (byte)Pravci.istok;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    pravac = (byte)Pravci.jug;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    pravac = (byte)Pravci.zapad;
                    break;
                default:
                    break;
            }
            if (pravac >= 0)
            {
                if (pc.TrenutnaSoba.prohodno(pravac, out Soba s))
                {
                    pc.TrenutnaSoba = s;
                    return "Prelazite u drugu sobu...";
                }
                else
                    return "Ne mozete u tom pravcu!";
            } else
            {
                //TODO druge komande
                return "Nemamo jos nista ovde :( ";
            }

        }
    }
}