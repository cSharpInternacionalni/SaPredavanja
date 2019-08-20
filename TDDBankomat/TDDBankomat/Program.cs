using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            Bankomat b = new Bankomat();
            b.Depozit(0);
            Console.ReadKey();
        }
    }

    public class Bankomat
    {
        private int stanje;
        // _ kod broja je samo za nasu citljivost,
        //mozemo da razdvajamo cifre tako
        private int dozvoljeniMinus = 10_000; 

        public void Depozit(uint s)
        {
            if (s == 0)
                throw new ArgumentException("0 nije validan depozit!");
        }
        public void Isplata(uint s) { }
        public int Stanje { get => stanje; set => this.stanje = value; }
    }
}
