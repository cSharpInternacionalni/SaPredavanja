<Query Kind="Statements" />

Console.WriteLine("++NAJBESKORISNIJI POS U UNIVERZUMU++\n");
while (true)
{
	(string Sifra, string Naziv, decimal Ucena,
	 decimal Icena, double MarzaP, double PorezP, uint Stanje)[] artikli = new (string Sifra, string Naziv, decimal Ucena,
	 decimal Icena, double MarzaP, double PorezP, uint Stanje)[1]; 
	stampajMeni();
	string izbor = Console.ReadLine();
	if (izbor.ToLower().Equals("q"))
	{
		Console.WriteLine("\nBye bye!");
		return;
	}

	if (!int.TryParse(izbor, out int odabir))
	{
		Console.WriteLine("Greska pri unosu!");
		continue;
	}

	switch (odabir)
	{
		case 1:
			unosArtikla(artikli);
			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			break;
		case 6:
			break;
		case 7:
			break;
		default:
			Console.WriteLine("Nepostojeca opcija!");
			break;
	}
}

void stampajMeni()
{ 
    Console.WriteLine("\n1 -- Unos artikla\n" +
	"2 -- Izmena artikla\n" +
	"3 -- Obrisi artikal\n" +
	"4 -- Unesi racun\n" +
	"5 -- Storno\n" +
	"6 -- Izlistaj artikle\n" +
	"7 -- Izlistaj racune\n" + 
	"q -- Izlaz iz programa\n" +
	"_____________________\n");
	Console.Write("Izaberite: ");
}

void unosArtikla((string Sifra, string Naziv, decimal Ucena,
	              decimal Icena, double MarzaP, double PorezP, uint Stanje)[] art)
{
	Console.WriteLine("\nUnesite sifru, naziv, ulaznu cenu, marzu i porez u procetnima: ");
	
	string[] artikal = Console.ReadLine().Split(',');
	//0 - sifra, 1 - naziv, 2-ucena, 3-icena, 4-m, 5-p, 6-s 
	int indeks = 0;
	if (!(art[0].Ucena == 0))
	{
		promenaVelicine(ref art);
		indeks = art.Length - 1;
	}
		art[indeks].Sifra = artikal[0];
		art[indeks].Naziv = artikal[1];
		if (!decimal.TryParse(artikal[2], out art[indeks].Ucena) & 
		    !double.TryParse(artikal[3], out art[indeks].MarzaP) &    
			!double.TryParse(artikal[4], out art[indeks].PorezP))
	    {
			Console.WriteLine("Greska pri unosu!");
			return;
		}
		art[indeks].Icena = (art[indeks].Ucena * ((decimal)art[indeks].MarzaP/(decimal)100.0+1)) * (decimal)(art[0].PorezP/100.0+1);
		
		Console.WriteLine($"{art[indeks].Naziv} -- {art[indeks].Ucena} -- {art[indeks].Icena}");
	
	
}

void promenaVelicine(ref (string Sifra, string Naziv, decimal Ucena,
	 decimal Icena, double MarzaP, double PorezP, uint Stanje)[] nizzz, int promena = 1)
{                                      
 	(string Sifra, string Naziv, decimal Ucena,
	 decimal Icena, double MarzaP, double PorezP, uint Stanje)[] drugiNiz = new (string Sifra, string Naziv, decimal Ucena,
	 decimal Icena, double MarzaP, double PorezP, uint Stanje)[nizzz.Length + promena < 1 ? 1 : nizzz.Length + promena];
	
	for (int indeks = 0; indeks < nizzz.Length; indeks++)
	{
		if (indeks < drugiNiz.Length)
			drugiNiz[indeks] = nizzz[indeks];
		else
			break;
	}	
	nizzz = drugiNiz;
}
