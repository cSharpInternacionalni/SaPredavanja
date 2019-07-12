<Query Kind="Program" />

void Main()
{
	zanrovi noviEnum = zanrovi.highFi;
	noviEnum++;
	noviEnum = (zanrovi)21;
	
	noviEnum = (int)zanrovi.drama + zanrovi.sciFi;
	
	noviEnum = zanrovi.lowFi | zanrovi.komedija;
	
	Console.WriteLine(noviEnum);
}

[Flags]
enum zanrovi : byte
{
	sciFi = 1,   
	lowFi = 2,   
	highFi = 4,  
	drama = 8,
	komedija = 16,
	avantura = 32 
}
