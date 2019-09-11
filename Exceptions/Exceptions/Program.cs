using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            new B(5);
            Console.WriteLine("Unesite broj 10: ");
            int broj = int.Parse(Console.ReadLine());
            if (broj != 10)
                try
                {
                    throw new Nije10Exception(broj);
                }
                catch (Nije10Exception ex)
                {
                    Console.WriteLine($"Poruka je {ex.Message}");
                }
            Console.ReadKey();
        }
    }

    public class Nije10Exception : Exception
    {
        public Nije10Exception(int broj) : base("Hocu konstruktor sa strignom") 
        {
            this.Data.Add("Broj", broj);
        }
        public override string Message => $"Doslo je do greske," +
            $"{this.Data["Broj"]} nije broj 10 ";
    }

    class A
    {
        int x;
        public A() { }
        public A(int broj)
        {
            this.x = broj;
        }
        public A(string x) { }
    }

    class B : A
    {
        int i;
        public B(int a) 
        {
            Console.WriteLine("Konstruktor od B");
            this.i = a;
        }
    }
}
