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
        public ObservableCollection<string> listaImena
        {get; set;}

        string naziv;

        public Imena()
        {
            this.listaImena = new ObservableCollection<string>();
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
