using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plate
{
    class Firma
    {
        static string naziv, JIB, PIB;
        internal static decimal balans { get; private set; }

        internal static HashSet<Pozicija> pozicije = new HashSet<Pozicija>();

        //TODO TRANSAKCIJE TREBA DA BUDU OBJEKTI
        internal static void isplata(decimal svota, string firma)
        {

        }
        internal static void isplata(Radnik r)
        {

        }
        internal static void isplata(Pozicija p)
        {

        }

        internal static bool radnikPoId(long id, out Radnik radnik)
        {
            foreach (Pozicija p in Firma.pozicije)
                foreach (Radnik r in p.radnici)
                    if (r.ID == id)
                    {
                        radnik = r;
                        return true;
                    }
            radnik = null;
            return false;
        }
    }
}
