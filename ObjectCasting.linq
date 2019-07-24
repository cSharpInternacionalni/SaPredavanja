<Query Kind="Program" />

void Main()
{
	byte b = 100;
	int broj = 5;
	string s = "tekst";
	Baza bb = new Baza();
	Druga dr = new Druga();
	
	/* Posto je sve nastalo od objekta,
	   nemamo problema sa tim da kazemo da
	   nesto smatra objektom jer sve sto je nastalo od
	   objekta mora da poseduje sve sto objekat ima
	*/
	List<object> listaObj = new List<object>();
	listaObj.Add(dr);
	listaObj.Add(b);
	listaObj.Add(broj);
	listaObj.Add(s);
	listaObj.Add(bb);
	
	
	foreach (object nesto in listaObj)
	{
		Console.WriteLine(nesto.ToString());
		/*try
		{
			((Druga)nesto).bar();
		} catch (InvalidCastException e) {}*/
		
		if (nesto is int bbroj && bbroj < 10)
		{
			Console.WriteLine("Manji je!");
		} else if (nesto is Baza obj)
		{
			obj.foo();
		}
		//Ako hocemo da pristupimo metodama i stanjima
		//koje poseduju nase klase moramo da kazemo
		//kompajleru da hocemo da smatramo objekat
		//u koji gledamo nekom klasom. Ovo nosi rizik
		//sa sobom, jer ako u memoriji stvarno nije 
		//objekat klase kojom zelimo da ga smatramo
		//mozemo da dobijemo exception ili null 
		//vrednost gde je nismo ocekivali
		Druga d = nesto as Druga;
		if (!(d is null))
			d.bar();
	}
	
}

class Baza
{
	public int broj;
	public void foo()
	{
		Console.WriteLine("Ja sam baza :)");
	}
}

class Druga : Baza
{
	public int drugiBroj;
	public void bar()
	{
		Console.WriteLine("Ja sam druga :)");
	}
}