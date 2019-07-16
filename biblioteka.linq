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
				//promenaStanja(knjige);
				break;
			case 4:
				return;
		}
	}
	while(true);
}

void unos(ref (string sifra, string naziv, stanja stanjeKnjige)[] knjige)
{
	Array.Resize(ref knjige, knjige.Length + 1);
	Console.WriteLine("Unesite sifru: ");
	knjige[knjige.Length - 1].sifra = Console.ReadLine();
	Console.WriteLine("Unesite naziv: ");
	knjige[knjige.Length - 1].naziv = Console.ReadLine();
}


void stampajMeni()
{
	Console.WriteLine("1 -- Unos knjige\n2 -- Promena stanja\n3 -- Izlaz");
}

[Flags]
enum stanja
{
	SciFi = 1,   
	LowFi = 2, 
	HighFi = 4, 
	Drama = 8,  
	Komedija = 16,
	Iznajmljena = 32,
	Ostecena = 64  
}
