<Query Kind="Statements" />

for (int brojac = 0; brojac <= 500; brojac++)
{
	Console.Write(brojac);
	if (brojac == 0)
	{
		Console.WriteLine();
		continue;
	}
		
	if (brojac % 3 == 0 && brojac % 5 == 0)
		Console.Write("--FizzBuzz");
	else if (brojac % 5 == 0)
		Console.Write("--Buzz");
	else if (brojac % 3 == 0)
		Console.Write("--Fizz");
	
	Console.WriteLine();	
}