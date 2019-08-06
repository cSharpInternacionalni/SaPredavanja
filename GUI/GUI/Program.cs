using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region Paljenje
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            #endregion
        }
    }

    class Osoba
    {
        internal static BindingList<Osoba> sveOsobe = new BindingList<Osoba>();

        public uint indeks { private set; get; }
        public string ime { get; set; }
        public string prezime { get; set; }
        
        static Random rand = new Random();
        
        public Osoba(string ime, string p)
        {
            this.ime = ime;
            this.prezime = p;
            this.indeks = (uint)rand.Next(1000);
            Osoba.sveOsobe.Add(this);
        }

        public override string ToString() =>  $"{this.indeks} -- {this.ime} {this.prezime}";
        
    }
}
