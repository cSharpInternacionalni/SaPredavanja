<Query Kind="Program" />

void Main()
{
	(string sifra, string naziv, stanja stanjeKnjige)[] knjige
	= new (string sifra, string naziv, stanja stanjeKnjige)[0];
	
	do
	{
		stampajMeni();
		string odg = Console.ReadLine();
		if (!int.TryParse(odg, out int izbor))
			continue;
		switch(izbor)
		{
			case 1:
				unos(ref knjige);
				break;
			case 2:
				promenaStanja(knjige);
				break;
			case 3:
				return;
		}
	}
	while(true);
}

void promenaStanja((string sifra, string naziv, stanja stanjeKnjige)[] knjige)
{
	Console.WriteLine("Unesite sifru: ");
	string izbor = Console.ReadLine();

	int indeks = -1;
	for (int i = 0; i < knjige.Length; i++)
	{
		if (knjige[i].sifra.Equals(izbor))
		{
			indeks = i;
			break;
		}
	}
	if (indeks != -1)
	{
		ref (string sifra, string naziv, stanja stanjeKnjige) knjiga =
		     ref knjige[indeks];
		izmenaEnuma(ref knjiga);	 
	}
}

void izmenaEnuma(ref (string sifra, string naziv, stanja stanjeKnjige) knjiga)
{
	do
	{
		Console.WriteLine("Izaberite stanja: ");
		Console.WriteLine("1 - SciFi\n2 - LowFi\n3 - HighFi\n4 - Drama\n5 - Komedija\n6 - ostecena\n7 - gotovo");
		if (!int.TryParse(Console.ReadLine(), out int izb))
			continue;
		if (izb == 7)
			break;

		if ((knjiga.stanjeKnjige & (stanja)Math.Pow(2, izb - 1)) == (stanja)Math.Pow(2, izb - 1))
			knjiga.stanjeKnjige &= ~(stanja)Math.Pow(2, izb - 1);
		else
			knjiga.stanjeKnjige |= (stanja)Math.Pow(2, izb - 1);
		Console.WriteLine(knjiga.stanjeKnjige);
	} while (true);
}
void unos(ref (string sifra, string naziv, stanja stanjeKnjige)[] knjige)
{
	Array.Resize(ref knjige, knjige.Length + 1);
	ref (string sifra, string naziv, stanja stanjeKnjige) knjiga = ref knjige[knjige.Length - 1];
	Console.WriteLine("Unesite sifru: ");
	knjiga.sifra = Console.ReadLine();
	Console.WriteLine("Unesite naziv: ");
	knjiga.naziv = Console.ReadLine();
	izmenaEnuma(ref knjiga);
	
}


void stampajMeni()
{
	Console.WriteLine("1 -- Unos knjige\n2 -- Promena stanja\n3 -- Izlaz");
}

[Flags]
enum stanja : byte
{
	SciFi = 1,   
	LowFi = 2, 
	HighFi = 4, 
	Drama = 8,  
	Komedija = 16,
	Ostecena = 32,
	Iznajmljena = 64  
}