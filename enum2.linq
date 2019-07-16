<Query Kind="Program" />

void Main()
{
	test nesto = test.prvaStvar; //jedna vrednost
	nesto = test.drugaStvar | test.trecaStvar; //dve
	nesto |= test.cetvrtaStvar; //dodavanje
	nesto.Dump();
	nesto &= 0;
	nesto.Dump();
	
	nesto = test.prvaStvar | test.drugaStvar;
	nesto.Dump();
	if ((nesto & test.prvaStvar) == test.prvaStvar)
		Console.Write("To je to");
	
}

[Flags]
enum test
{
	prvaStvar = 1,
	drugaStvar = 2,
	trecaStvar = 4,
	cetvrtaStvar = 8
}