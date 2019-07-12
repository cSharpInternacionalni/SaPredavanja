<Query Kind="Statements" />

int broj = 0;
while (true)
{
	Console.WriteLine("Unesite broj: ");
	try
	{
		broj = int.Parse(Console.ReadLine());
		break;
	} catch
	{   
		Console.WriteLine("To nije broj!!");
	} finally
	{
		Console.WriteLine("Ovo se uvek izvrsi!");
	}
}

Console.WriteLine("Zbir je: " + (broj + 5) );


broj = 0;
while (true)
{
	Console.WriteLine("Unesite broj: ");
	
	if (int.TryParse(Console.ReadLine(), out broj))
		break;
}
Console.WriteLine("Zbir je: " + (broj + 5) );