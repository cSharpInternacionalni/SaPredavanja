<Query Kind="Statements" />

string nekiString = "Neki tekst";

Console.WriteLine(nekiString[1]);

foreach (char karakter in nekiString)
{
	//Console.WriteLine(karakter);
}
nekiString = nekiString.ToUpper();
Console.WriteLine(nekiString);

char[] nizKaraktera = nekiString.ToCharArray();
nizKaraktera.Dump();
nekiString.Dump();
nizKaraktera[1] = 'G';

string[] nizS = nekiString.Split(' ');

nizS.Dump();

string sss = nekiString.Substring(0, 3);
sss.Dump();

string srch = nekiString.Replace('T', 'q');
srch.Dump();

srch = nekiString.Replace("TEKST", "qwe");
srch.Dump();

string broj = "3";
Console.WriteLine("+" + broj.Trim(' ') + "+" );


int.Parse(broj);
double.Parse(broj);




