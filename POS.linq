<Query Kind="Statements" />

int[] niz = {32, 65, 76, 5, 67};
promenaVelicine(ref niz);
niz.Dump();
ukloniElement(ref niz, 1);
niz.Dump();


void promenaVelicine(ref int[] nizzz, int promena = 1)
{                                      
 	int[] drugiNiz = new int[nizzz.Length + promena < 1 ? 1 : nizzz.Length + promena];
	
	for (int indeks = 0; indeks < nizzz.Length; indeks++)
	{
		if (indeks < drugiNiz.Length)
			drugiNiz[indeks] = nizzz[indeks];
		else
			break;
	}	
	nizzz = drugiNiz;
}

void ukloniElement(ref int[] nizz, int indeks)
{
	if (nizz.Length == 1)
		return;

	int[] niz2 = new int[nizz.Length - 1];
	Boolean preskocen = false;
	for (int i = 0; i < niz2.Length; i++)
	{
		if (i == indeks)
		{
			preskocen = true;
			continue;
		}
		niz2[preskocen?i-1:i] = nizz[i];
	}
	nizz = niz2;
}