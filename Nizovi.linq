<Query Kind="Statements" />

int[] niz = new int[4];
int[] niz2 = {3, 4, 5};

//Prolazak kroz niz
for (int indeks = 0; indeks < niz.Length; indeks++)
{
	Console.WriteLine(niz[indeks]);
}

//Pravougaona matrica
int[,] matrica = new int[3, 2];

Console.WriteLine(matrica.Length); //broj elemenata u totalu
Console.WriteLine(matrica.GetLength(0)); //po dimenziji

for (int red = 0; red < matrica.GetLength(0); red++)
{
	for (int kol = 0; kol < matrica.GetLength(1); kol++)
	{
		Console.WriteLine(matrica[red, kol]);
		matrica[red, kol] = red * kol;
	}
}

foreach(int broj in matrica)
{
	Console.WriteLine(broj);	
}

/*
Pravilna
1 3 4 5
2 4 5 6

Jagged
1 2 3 4
1 2
3 4 5 6 7
*/

int[][] jagged = new int[3][];

//Nazubljena matrica je, u stvari, niz kome su elementi nizovi :)
jagged[0] = new int[4];
jagged[1] = new int[2];
jagged[2] = new int[5];