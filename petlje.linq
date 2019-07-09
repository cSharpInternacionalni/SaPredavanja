<Query Kind="Statements" />

int nekiBroj = -5;

while (nekiBroj < 15)
{
	nekiBroj++;
}

nekiBroj = -5;

do
{
	nekiBroj--;
}while (nekiBroj > 0);
     //init       //uslov  //operacija
for (int x = 0;   x < 10;    x++)
{
	//Console.WriteLine(x);
}

int y = 5;
for (;;)
{
	y++;
	if (y == 10)
		continue;
	if (y == 15)
		break;
}


int[] niz = {1, 2, 3, 4, 5, 6, 7, 8, 9};
//niz.Dump();
for (int indeks = 0; indeks < niz.Length; indeks++)
{
	niz[indeks] *= 2;
	//Console.WriteLine(niz[indeks]);
}

foreach (int broj in niz)
{
	Console.WriteLine(broj);	
}