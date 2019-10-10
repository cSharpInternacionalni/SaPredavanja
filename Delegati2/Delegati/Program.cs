using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegati
{
    class Alarm
    {
        public delegate void Sablon(int x);
        public static event Sablon mojDelegat;
        
        static void Main(string[] args)
        {
            //NekaKlasa k = new NekaKlasa();
           // Peta p = new Peta();
            //Peta pp = new Peta();

            desioSeAlarm();

            Console.ReadKey();
        }

        static void desioSeAlarm()
        {
            
            Alarm.mojDelegat?.Invoke(5);
        }
    }

    class NekaKlasa
    {
        int x = 5;

        public NekaKlasa()
        {
            Alarm.mojDelegat += this.FooBar; 
        }
        public void FooBar(int nesto)
        {
            Console.WriteLine("Ovo je FooBar :)");   
        }

        private void Bar()
        {
            Console.WriteLine("Druga metoda");
            
        }
    }

    class Peta
    {
        public Peta()
        {
            Alarm.mojDelegat += this.Foo;
        }
        public void Foo(int xy)
        {
            Console.WriteLine("Jos jedna metoda");
            
        }
    }


}
