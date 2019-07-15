<Query Kind="Statements" />

Console.WriteLine("++NAJBESKORISNIJI POS U UNIVERZUMU++\n");
(string Sifra, string Naziv, decimal Ucena,
	 decimal Icena, double MarzaP, double PorezP, uint Stanje)[] artikli = new(string Sifra, string Naziv, decimal Ucena,
	 decimal Icena, double MarzaP, double PorezP, uint Stanje)[0];
while (true)
{ 
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
			unosArtikla(ref artikli);
			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			izdajRacun(artikli);
			break;
		case 5:
			break;
		case 6:
			izlistajArtikle(artikli);
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

void izdajRacun((string Sifra, string Naziv, decimal Ucena,
				  decimal Icena, double MarzaP, double PorezP, uint Stanje)[] art)
{
	(int indeks, string Naziv, int Kol, decimal Cena)[] rac = new (int indeks, string Sifra, int Kol, decimal Cena)[0];
	int brojac = 0;
	while (true)
	{
		Console.WriteLine("Unesite sifru artikla: ");
		string sifra = Console.ReadLine();
		
		int indeks = -1;
		for (int i = 0; i < art.Length; i++)
		{
			if (art[i].Sifra.Equals(sifra))
			{
				indeks = i;
				break;
			}
		}
		if (indeks == -1)
			continue;
		Console.WriteLine("Unesite kolicinu: ");
		if (!int.TryParse(Console.ReadLine(), out int kol))
			continue;
		if (kol > art[indeks].Stanje)
			continue;
		
		brojac++;
		Array.Resize(ref rac, brojac);
		rac[brojac-1].indeks = indeks;
		rac[brojac-1].Naziv =  art[indeks].Naziv;
		rac[brojac-1].Kol = kol;
		rac[brojac-1].Cena = art[indeks].Icena;
		Console.WriteLine("Unosite jos artikala(d/n)? ");
		if (!Console.ReadLine().Equals("d"))
			break;
	}
	
	foreach (var a in rac)
	{
		artikli[a.indeks].Stanje -= (uint)a.Kol;
		Console.WriteLine($"\n{a.Naziv} -- {a.Kol} -- {a.Cena * a.Kol}");
	}
	
}

void izlistajArtikle((string Sifra, string Naziv, decimal Ucena,
				  decimal Icena, double MarzaP, double PorezP, uint Stanje)[] art)
{
	foreach (var artikal in art)
	{
		if (artikal.Ucena == 0)
			continue;
		Console.WriteLine($"{artikal.Sifra} --- {artikal.Naziv} -- {artikal.Ucena} -- {artikal.MarzaP}% -- {artikal.PorezP}% -- {artikal.Icena}");
	}
}

void unosArtikla(ref (string Sifra, string Naziv, decimal Ucena,
	              decimal Icena, double MarzaP, double PorezP, uint Stanje)[] art)
{
	Console.WriteLine("\nUnesite sifru, naziv, ulaznu cenu, marzu i porez u procetnima: ");
	
	string[] artikal = Console.ReadLine().Split(',');
	//0 - sifra, 1 - naziv, 2-ucena, 3-icena, 4-m, 5-p, 6-s 
	promenaVelicine(ref art);
	int	indeks = art.Length - 1;
	art[indeks].Sifra = artikal[0];
	art[indeks].Naziv = artikal[1];
	if (!decimal.TryParse(artikal[2], out art[indeks].Ucena) & 
		!double.TryParse(artikal[3], out art[indeks].MarzaP) &    
	    !double.TryParse(artikal[4], out art[indeks].PorezP) &
	    !uint.TryParse(artikal[5], out art[indeks].Stanje))
	    {
			Console.WriteLine("Greska pri unosu!");
			return;
		}
	art[indeks].Icena = racunajIzlaznu(art[indeks].Ucena, art[indeks].MarzaP, art[indeks].PorezP);
	Console.WriteLine($"{art[indeks].Naziv} -- {art[indeks].Ucena} -- {art[indeks].Icena} -- {art[indeks].Stanje}");
	
	
}

decimal racunajIzlaznu(decimal ulazna, double mP, double pP)
{
	return (ulazna * ((decimal)mP/(decimal)100.0+1)) * (decimal)(pP/100.0+1);
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