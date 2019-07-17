<Query Kind="Program" />

void Main()
{
	Console.Write("Unesite broj polja \n");
	int brojPolja=int.Parse(Console.ReadLine());
	Console.Write($"Unesite broj mina veci od 0 a manji od{brojPolja*brojPolja} \n");
	int brojMina=int.Parse(Console.ReadLine());
	uint[,] tabla=new uint[brojPolja,brojPolja];
	postaviTablu(tabla,brojPolja,brojMina);
	
	prikazi(tabla,brojPolja);
}

void postaviMine(int x,int y,uint [,]tabla,int brojPolja)
{
	for (int i = x - 1; i <= x + 1; i++)
	{
		for (int j = y - 1; j <= y + 1; j++)
		{
             if(i>=0 && i<brojPolja && j>=0 && j<brojPolja)
			 {
			 	if(i==x && j==y)
				   tabla[i,j]=9;
				else if(tabla[i,j]!=9)
				   tabla[i,j]++;
			 }

		}
	}
}
void postaviTablu(uint[,] tabla,int brojPolja,int  brojMina)
{
	Random rnd=new Random();
	for(int i=0;i<brojMina;i++)
	{
		int x=rnd.Next(0,brojPolja);
		int y=rnd.Next(0,brojPolja);
		postaviMine(x,y,tabla,brojPolja);
	}
}
void prikazi(uint [,]tabla,int brojPolja)
{
	for (int i = 0; i < tabla.GetLength(0); i++)
	{
		for (int j = 0; j < tabla.GetLength(1); j++)
		{
			Console.Write(tabla[i, j] == 9 ? "*" : tabla[i, j] + " ");

		}
		Console.Write("\n");
	}
	
	
}
// Define other methods and classes here
