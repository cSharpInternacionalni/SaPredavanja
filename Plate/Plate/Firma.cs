using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plate
{
    class Firma
    {
        public class PlateEventArgs : EventArgs
        {
            public readonly decimal plata;

            public PlateEventArgs(decimal p)
            {
                this.plata = p;
            }
        }

        public delegate void PlateEventHandler(object sender, PlateEventArgs e);
        public static event PlateEventHandler IsplataPlata;

        protected static void onIsplataPlata(object o, PlateEventArgs e) =>
            Firma.IsplataPlata?.Invoke(o, e);

        public static void isplati(object o, decimal iznos)
        {
            switch(o)
            {
                // isto kao kada napisemo if (o is Pozicija p)
                case Pozicija _:
                case Radnik _: 
                    onIsplataPlata(o, new PlateEventArgs(iznos));
                    break;
            }
        }

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
