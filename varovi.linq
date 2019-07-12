<Query Kind="Statements" />

byte b = 255; //1 bajt :D
sbyte bs = -128;

short s; //int16 -- 2 bajta
ushort su;

int i; //int32
uint iu;

const int konstanta = 5;

long l; //int64
ulong lu;

float f = (float)3.4; //32 bita
double d = 5.4; //64 bita
decimal dd = (decimal)5.4; // 128 bita

char c ='a';
string nizKaraktera = "asd asd asd";

Boolean neki = true; //false

int rez = 10 % 3; //modulus, ostatak celobrojnog deljenja,
                  //ovde 1 (4 % 2 = 0)

int x = 1;
Console.WriteLine(x++); //postfix, uradi se sve pa tek onda on 
Console.WriteLine(++x); //prefiks, prvo on pa sve ostalo


int[] niz = new int[5]; //niz
int[] niz2 = {1, 2, 3};

//Kastovanje
byte bb = 128;  
int celiBroj = bb; //implicitna

int nekiBr = 128;
byte bajtic = (byte)nekiBr; //eksplicitno

int nekiBr2 = 258;
bajtic = (byte)nekiBr2;

bajtic.Dump();

double dd2 = nekiBr2;

char kzlj = (char)100; //char je, u stvari celobrojna vrednost
                      //iz ASCII tabele
kzlj.Dump();
kzlj = (char)((int)kzlj + 3); //Prvo kastamo char u int da bi mogli
                              //da ga saberemo sa 3. Posto sada
							  //imamo rezultat kao int moramo
							  //da kastamo ponovo u char :)
kzlj.Dump();

var nesto = "asd"; //Kada kazmo var, pustamo kompajler da odredi
                   //koji tip podatka pase

var artikal = (naziv:"Kafa", cena:4.5, kol:40); //tuple
                                              //set vrednosti
											  //Nije iterativan kao niz,
											  //nema indeksa i sl
											  //Nije referentan,
											  //ide po vrednosti
(int Broj, int DrugiBroj, string Nesto) tuple = (3, 4, "sdfgg");
                                          //jos jedan nacin da 
										  //definisemo tuple
Console.WriteLine(artikal.naziv);

(string, int)[] nizT = new (string, int)[5]; //niz tuplova :)



byte neki2 = 255;
checked
{
	neki2 += 8;
}
Console.WriteLine(neki2);
