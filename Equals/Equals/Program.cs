using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equals
{
    class Program
    {
        static void Main(string[] args)
        {
            string t1 = "asd";
            string t2 = "asd";
            
            //Assert.AreEqual je ovo:
            if (t1.Equals(t2))
                Console.WriteLine("Jednaki su!");

            object oA = new object();
            object oB = new object();
            if (oA.Equals(oB))
                Console.WriteLine("Objekti su jednaki!");

            Bla a = new Bla();
            Bla b = new Bla();
            
            if (a.Equals(b))
                Console.WriteLine("Bla Jednaki su!");
            Console.ReadLine();
        }

        class Bla
        {
            string naziv = "asd";

            public override bool Equals(object obj)
            {
                if (obj is Bla b && this.naziv.Equals(b.naziv))
                    return true;
                return false;
            
            }
        }
    }
}
