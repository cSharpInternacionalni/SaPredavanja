using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;

namespace ProgramTesting
{
    [TestClass] //Imamo atribut sa kojim oznacavamo strukture koje se koriste u svrhu testiranja
    public class MathHelperTests //po tradicji, klasa koja testira drugu klasu
                                 //za ime uzme ime klase koju testira + postfix Tests
    {
        [DataTestMethod] //Data test method je metod koji cemo da hranimo redovima podataka
        [DataRow(7, 5, 12)] //Ova metoda ce se izvrsiti onoliko puta koliko setova podataka ima
        [DataRow(-1, 5, 4)]
        [DataRow(0,0,0)]
        public void TestSabiranja(int x, int y, int rez)
        {                         //Naravno, za ulazne parametre napisemo onoliko koliko nam treba
                                  //da uzmemo red podataka
            //Arrange --Prvi korak, dovodimo sve u stanje pred situaciju koju hocemo da testiramo
            MathHelper mh = new MathHelper();

            //Act --Drugi korak, izvrsavamo radnju
            int rezultat = mh.Saberi(x, y);

            //Assert -- Treci korak, koristimo assert da bi utvrdili rezultate testa
            //Assert sam po sebi nije nista drugo do poziva metode objekta koji testiramo
            //(AreEqual bukvalno samo pozove objA.Equals(ObjB) ) + integracija u test framework
            //da bi fino mogao da nam javi je li proslo ili ne
            Assert.AreEqual(rez, rezultat);
        }

        [TestMethod] //Standarni test method ne prima podatke u redovima, sta imamo to imamo
        public void TestOduzimanja()
        {
            //-12 - -5
            int ocekujem = -7; //Pa sami pripremamo ovde ocekivani rezultat
            MathHelper mh = new MathHelper();
            int r = mh.Oduzmi(-12, -5);
            Assert.AreEqual(ocekujem, r); //Uvek, uvek, uvek expected pa actual
                                          //ili poruke koja nam daje testing framework
                                          //nece da imaju smisla
        }

        [TestMethod]
        public void ObjTest()
        {
            //Arrange
            Dobrovoljac ocekivani = new Dobrovoljac(); 
            ocekivani.naziv = ocekivani.naziv.ToUpper(); //Klasa koju testiramo ima
                                                        //bukvalno isto ovo,
                                                        //samo uzme objekat klase
                                                        //Dobrivoljac i baci ga u CAPS :)

            ObjectTest t = new ObjectTest();

            //Act
            Dobrovoljac rezultat = t.CAPS(new Dobrovoljac());

            //Assert
            //Ovaj Equals ovde moze da bude problematican. Ako mi nismo implementirali 
            //nasu verziju, pozvace se implementacija od klase objekat. Ona je izrazito
            //uska i puno manje je equals, vise je same, jer je jedini nacin da naterate
            //objA.Equals(objB), u slucaju te klase, da baci true taj da mu date da poredi 
            //ne jednake objekte nego isti objekat. objA.Equals(objB) bude tacno samo ako smo
            //izvrsili objA = objB, da oba imena pokazuju na potpuno isti objekat, sve drugo je
            //false
            //Imamo i Assert.AreSame koji radi bas to, tj true je ne ako objektov equals vrati
            //true nego samo u slucaju da i ocekivani i rezultat pokuzaju na isti,
            //jedan jedini, objekat.
            Assert.AreEqual(ocekivani, rezultat);
        }

    }
}
