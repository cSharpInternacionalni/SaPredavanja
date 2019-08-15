using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            A nekiObjekat = new A();

            Object o = nekiObjekat as Object;
            NekaKlasa nk = nekiObjekat as NekaKlasa;
            Test t = nekiObjekat as Test; //Sve pravilno :)
                

        }
    }

    class NekaKlasa
    {
        int blabla;
    }

    class A : NekaKlasa, Test, Test2
    {
        void Test.f(int a)
        {

        }

        void Test2.f(int a)
        {

        }
        public int broj { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void bar()
        {
            throw new NotImplementedException();
        }

        public void foo(int b)
        {
            throw new NotImplementedException();
        }

        public int fooBar()
        {
            throw new NotImplementedException();
        }
    }

    public interface Test2
    {
        int fooBar();
        void f(int a);
    }

    public interface Test
    {
        void f(int a);
        int broj { get; set; }

        void foo(int b);
        void bar();
    }
}
