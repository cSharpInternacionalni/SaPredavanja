<Query Kind="Statements" />

int x = 5, b = 8;
funkcija(); //pozivamo fju, na call stacku se pamti gde smo bili
int rez = sabiranje(4, 5); //pozivamo fju i cuvamo podatak koji nam vraca
Console.WriteLine(sabiranje(6,7));

int sabiranje(int a, int bbb)
{
	return 5 + 8;
}


(int, Boolean) tupleF()
{
	return (34, true);
}

string[] vracaNiz()
{
	string[] nesto ={"jedan", "dva"}; 
	return nesto;
}


//tip 
//povratnog podatka    //ime     //ulazni parametri
void                  funkcija    ()
{
	int broj = 45; //funkcija ima svoj mem prostor,
	              //ono sto joj nismo poslali ili deklarisali u njoj
				  //ne moze da vidi
	Console.WriteLine("Prva funkcija");
	funkcija3();
	Console.WriteLine("Kraj prve funkcije");
}


void  funkcija3()
{
	Console.WriteLine("Treca funkcija");
}

naKvad(5);
naKvad(5, 3);
void naKvad (int xqw, int stepen = 2)
{
	
}

fja(s:"sd", xbc:5);

void fja(int xbc, string s)
{
	
}

param("asd", 3);
param("asd", 3, 6, 7, 8, 9);


void param(string asd, params int[] p)
{
	
}