<Query Kind="Statements" />

int i = 34;
while (i > 1)
{
	Console.WriteLine(i);
	i = i%2 == 0 ? i/2 : i*3 + 1; 
}
Console.WriteLine(i);