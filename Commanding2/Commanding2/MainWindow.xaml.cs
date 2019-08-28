using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Commanding2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ListaStringova();   
        }        
    }

    public class IzmeniString : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            var lst = parameter as ListaStringova;
            if ((lst != null) && lst.Selektovano >= 0 && !string.IsNullOrEmpty(lst.Unos)
                                && !string.IsNullOrWhiteSpace(lst.Unos) && !lst.Lista.Contains(lst.Unos))
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            var lst = parameter as ListaStringova;
            lst.Lista[lst.Selektovano] = lst.Unos;
        }
    }

    public class UkloniString : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            var lst = parameter as ListaStringova;
            if ((lst != null) && lst.Selektovano >= 0)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            var lst = parameter as ListaStringova;
            int stariIndeks = lst.Selektovano;
            lst.Lista.RemoveAt(lst.Selektovano);
            if (lst.Lista.Count < 1)
                lst.Unos = "";
            else if (stariIndeks < lst.Lista.Count)
                lst.Selektovano = stariIndeks;
            else
                lst.Selektovano = --stariIndeks;
            
        }
    }

    public class DodajString : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            var lista = parameter as ListaStringova;
            if ((lista != null) && !string.IsNullOrEmpty(lista.Unos)
                                && !string.IsNullOrWhiteSpace(lista.Unos) && !lista.Lista.Contains(lista.Unos))
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            var lista = parameter as ListaStringova;
            lista.Lista.Add(lista.Unos.Trim());
            lista.Unos = "";
        }
    }

    public class ListaStringova : INotifyPropertyChanged
    {
        //public DodajString dodajKomanda = new DodajString();
        public DodajString DodajKomanda
        {
            get;// => this.dodajKomanda;
            set;// => this.dodajKomanda = value;
        } = new DodajString();

        public UkloniString UkloniKomanda
        {
            get;
            set;
        } = new UkloniString();

        public IzmeniString IzmeniKomanda
        {
            get;
            set;
        } = new IzmeniString();

        //ObservableCollection<string> lista = new ObservableCollection<string>();
        public ObservableCollection<string> Lista
        {
            get; //=> this.lista;
            set; //=> this.lista;
        } = new ObservableCollection<string>();

        string unos;
        public string Unos
        {
            set
            {
                //REFACTOR: Treba da se osiguramo da
                //ne trigerujemo event ako nam je
                //nova vrednost ista kao stara
                this.unos = value;
                this.Izmena("Unos");
            }
            get => this.unos;
        }

        int selektovano = -1;
        public int Selektovano
        {
            set
            {
                this.selektovano = value;
                if (value >= 0)
                    this.Unos = this.Lista[value];
                this.Izmena("Selektovano");
            }

            get => this.selektovano;
        }

        public void Izmena(string prop)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
