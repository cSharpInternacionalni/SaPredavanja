<Query Kind="Statements" />

string rec = "Jabuka";
bool[] otkrivenaSlova = new bool[rec.Length];
byte brojPokusaja = 0;

while (true)
{
	ispisiRec(rec, otkrivenaSlova);
	Console.WriteLine("Unesite slovo ili celu rec: ");
	string unos = Console.ReadLine();
	brojPokusaja++;
	
	if (unos.Length == 1)
	{
		for (int i = 0; i < rec.Length; i++)
		{
			if (rec.ToLower()[i] == unos.ToLower()[0])
			{
				otkrivenaSlova[i] = true;
			}
		}
		if (proveriPobedu(otkrivenaSlova))
		{
			Console.WriteLine($"Uspeli ste u {brojPokusaja} pokusaja");
			break;
		}
	}
	else
	{
		if (unos.ToLower().Equals(rec.ToLower()))
		{
			Console.WriteLine($"Uspeli ste u {brojPokusaja} pokusaja");
			break;
		}
	}
}

bool proveriPobedu(bool[] otkrivenaSlovaa)
{
	foreach (bool b in otkrivenaSlovaa)
	{
		if (!b)
			return false;
	}
	return true;
}

void ispisiRec(string recc, bool[] otkrivenaSlovaa)
{
	for (int i = 0; i < recc.Length; i++)
	{
		if (otkrivenaSlovaa[i])
			Console.Write(recc[i] + " ");
		else
			Console.Write("_ ");
			
	}
	Console.WriteLine();
}

