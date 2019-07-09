<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

int rezultat = zbir(5, 6, out Boolean veci); //out parametar je parametar
                                            //koji se salje po referenci i 
											//ocekuvano je da ce fja da pise u njega
zbir(10, 20, out _); //ignorisemo out parametar
Console.WriteLine(veci);


int zbir(int z, int c, out Boolean veciOd)
{
	int zz = z + c;
	veciOd = zz > 0; //bool skladistimo u out
	return zz; //integer vracamo
}


int nesto = 5;
poRefInt(ref nesto); //saljemo int po referenci, tj. njegovu adresu
                     //a ne vrednost pa funkcija utice na bas ovaj int

void poRefInt (ref int broj)
{
	broj++;
}

int aa = 5;
ref int bb = ref aa; //vezujemo int aa za bb po referenci
                    //posto u memoriiji nemamo dve vrednosti
					//nego jedno vrednost na koju pokazujemo
					//sa obe promenljive (npr, nasa vrendnost 5 se u
					//memoriji nalazi na adresi FFBA. I aa i bb, posto su
					//po referenci ne sadrze broj 5 nego podatak o adresi, 
					//FFBA.
bb++; //Samim tim, oba ova inkrement uvecavaju istu vrednost
aa++;

int[] niz1 = {5};    //Nizovi su po prirodi referentni tipovi
int[] niz2 = niz1;
niz2[0]++;



int x = 5;
poVrednosti(x); //Primitivni tipovi su po prirodi vrednosni,
                //pa ovako fja ne utice na original nego pravi svoj
Console.WriteLine("Van funkcije:" + x);
int[] niz = {5};
poReferenci(niz);
Console.WriteLine("Van ref funkcije:" + niz[0]);

void poReferenci(int[] nizzz)
{
	nizzz[0]++;
	Console.WriteLine("Unutar ref funkcije:" + nizzz[0]);
}
void poVrednosti(int a)
{
	a++;
	Console.WriteLine("Unutar funkcije:" + a);
}