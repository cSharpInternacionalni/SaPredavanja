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

int broj1 = 5, broj2 = 6;

Console.WriteLine("Prvi broj je " + broj1 + " a drugi broj je " + broj2);
string fString = String.Format("Prvi broj je {0, 5} a drugi broj je {1, -5}.", broj1, broj2);
Console.WriteLine(fString);
Console.WriteLine(String.Format("Prvi broj je {0, 5} a drugi broj je {1, -5}.", broj1, broj2));
Console.WriteLine($"Prvi broj je {broj1, 5} a drugi broj je {broj2}");
