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

            Object o = nekiObjekat as Object; //Po polimorfizmu, znamo da instancu svake klase
                                              //mozemo smatrati objektom, no to nas sprecava da
                                              //koristimo sve sto je kod nase klase razlicito od
                                              //objekta (van override-a naravno :))
            NekaKlasa nk = nekiObjekat as NekaKlasa; //Takodje mozemo da smatramo instancu neke klase
                                                     //njenom nadklasom. Opet, gubimo sve specificnosti i,
                                                     //naravno, mozemo se koristiti samo stvarima koje smo
                                                     //implementirali u nadklasi (opet, override je specifican :))
            Test t = nekiObjekat as Test; //Pored svega, mozemo klasu posmatrati kao interfejs koji smo u njoj
                                          //implementirali. Dokle god je tako posmatramo, mozemo se koristiti
                                          //samo implementiranim interfejsom. Sve sto impementiramo iz interfejsa,
                                          //inace, je sealed, pa ako hocemo da mozemo override u podklasama moramo
                                          //da naznacimo u klasi da je virtual
                

        }
    }

    class NekaKlasa
    {
        int blabla;
    }

    class A : NekaKlasa, Test, Test2 //klasa moze da implementira vise od jednog interfejsa
    {
        void Test.f(int a) //Ako imamo dva interfejsa sa istom metodom, 
        {                  //to resavamo tako sto stavimo ime interfejsa, da bi bilo jasno
                           //koji tacno implementiramo u ovom trenutku

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
