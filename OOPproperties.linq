<Query Kind="Program" />

void Main()
{
	Artikal.brojac++; //staticne clanove
	Artikal.test();  //pozivamo koristeci ime klase
	 //oni nisu vezani za objekat i pripadaju samoj klasi
	Artikal a = new Artikal(100, 25, "naziv");
	
	//lista je struktura koja u pozadini ima niz
	//i sama ga siri po potrebi
	List<Artikal> artikli = new List<Artikal>();

	for (int i = 0; i < 10; i++)
	{
		artikli.Add(new Artikal(12, 12, "asd"));
		Console.WriteLine($"Stanje brojaca {artikli[artikli.Count -1].Naziv}: {Artikal.brojac}");
	}
	Console.WriteLine($"{a.uCenu}--{a.Marza}%--{a.IzlaznaCena}");
	a.Marza = 1;

	Console.WriteLine($"{a.ToString()} --- {a.uCenu}--{a.Marza}%--{a.IzlaznaCena}");
	a.Marza = 17;
	Console.WriteLine($"{a.uCenu}--{a.Marza}%--{a.IzlaznaCena}");

	//Dekonstruktor u akciji
	//Dekonstruktor ne unistava objekat!!!!
	(int x, string abc) = a;
	/*  Ovo nije tupl :)
		potpuno isto kao:
		int x = a.nesto;
		string abc = a.nestoDrugo;
	*/
}

class Artikal
{
	public decimal uCenu;
	int marza; 
	public static int brojac; 
	public string Naziv
	{get;private set;} //automatksi getteri i setteri
	
	public static void test()
	{
		Console.WriteLine("Test");
	}
	
	public int Marza
	{   //Notacija sa => radi jedino kada imamo 
	    //jedan izraz i nista vise
		set => this.marza = value < 5 ? 5 : value;
		get => this.marza;
	}
	//property
	
	public decimal IzlaznaCena //getter
	{
		get => this.uCenu * ((decimal)this.marza/100 + 1);
		/*Isto kao
		get
		{
			return this.iCena;	
		}*/

		set
		{
			this.marza = (int)((value / this.uCenu - 1) * 100);
		}
	}

	public Artikal(decimal c, int m, string n)
	{
		this.uCenu = c;
		this.marza = m;
		this.Naziv = n;
		Artikal.brojac++; //staticko stanje
		                  //postoji za sve
	}
	
	public void Deconstruct(out int a, out string b)
	{ //dekonstruktor objasnjava 
	  //kako da rasklopimo objekat na promenljive
		a = 5;
		b = "Zdravo!";
	}
}