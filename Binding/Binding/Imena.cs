using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding
{
    class Imena
    {
        public List<string> listaImena
        {get; set;}

        string naziv;

        public Imena()
        {
            this.listaImena = new List<string>();
        }
        public string Naziv
        {
            get => 
                this.naziv;
            private set => 
                this.naziv = value;
        } 
    }
}
