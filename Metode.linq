<Query Kind="Program" />

void Main()
{
	Baza b = new Baza();
	Druga dr = new Druga();
	
	List<Baza> lista = new List<Baza>();
	lista.Add(b);
	lista.Add(dr);
	
	foreach (Baza bb in lista)
	{
		bb.foo();
	}
	
	
}

public class Baza
{
	//Kada kazemo virtual dozvoljavamo deci
	//da napisu svoju verziju metode
	public virtual void foo()
	{
		Console.WriteLine("Iz baze!");
	}
}

public class Druga : Baza
{
	//Kada radimo override mozemo 
	//i da pozovemo metodu roditelja preko base
	//sealed znaci da nasa deca ne smeju da
	//overrajduju ovu metodu
	public sealed override void foo()
	{
		base.foo();
		Console.WriteLine("Iz druge");
	}

}
public class Treca : Druga
{
	//Kada kazemo new rekli smo, prakticno,
	//da, da, pisemo metodu istog imena
	//kao sto je ima nas roditelj, no
	//nema veze sa njom pa je ne gazimo.
	public new void foo()
	{
		base.foo();
		Console.WriteLine("Iz trece");
	}
}