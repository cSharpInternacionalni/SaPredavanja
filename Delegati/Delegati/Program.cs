using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegati
{
    class Program
    {
        public delegate void Sablon();
        public static Sablon mojDelegat;
        
        static void Main(string[] args)
        {
            NekaKlasa k = new NekaKlasa();
            Peta p = new Peta();

            Program.mojDelegat += k.FooBar;
            Program.mojDelegat += p.Foo;
            k.blah();

            Program.mojDelegat.Invoke();
            Console.ReadKey();
        }
    }

    class NekaKlasa
    {
        int x = 5;
        public void FooBar()
        {
            Console.WriteLine("Ovo je FooBar :)");
            
        }

        public void blah()
        {
            Program.mojDelegat += this.Bar;
        }

        private void Bar()
        {
            Console.WriteLine("Druga metoda");
        }
    }

    class Peta
    {
        public void Foo()
        {
            Console.WriteLine("Jos jedna metoda");
        }
    }


}
