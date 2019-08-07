using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventi
{
    class Program
    {
        static void Main(string[] args)
        {
            Subscriber s = new Subscriber();
            Subscriber s2 = new Subscriber();
            Subscriber2 drugiS = new Subscriber2();

            Publisher p = new Publisher();
            //p.komeJaviti.Add(s);

            //Metodu navodimo bez zagrada
            p.mojDelegat = new Publisher.nekiDelegat(s.reakcija);
            p.mojDelegat += drugiS.nekaDrugaReakcija;
            p.mojDelegat += s2.reakcija;
            p.mojDelegat(5);
            //Console.WriteLine(x);
            Console.ReadKey();
        }
    }

    class Publisher
    {
        //Ovo je tip podatka
        public delegate void nekiDelegat(int x);
        public nekiDelegat mojDelegat;

        //public List<Subscriber> komeJaviti = new List<Subscriber>();

      /*  public void dogadjaj()
        {
            foreach (Subscriber s in this.komeJaviti)
                s.reakcija();
        }*/
    }

    class Subscriber
    {
        public void reakcija(int x)
        {
            Console.WriteLine("Radim nesto");
        }
    }

    class Subscriber2
    {
        public void nekaDrugaReakcija(int x)
        {
            Console.WriteLine("I ja radim nesto");
        }

        public void nekaDrugaReakcija()
        {
            Console.WriteLine("Bez param");
        }
    }

}
