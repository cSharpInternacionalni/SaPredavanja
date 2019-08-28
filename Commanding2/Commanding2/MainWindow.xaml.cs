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

    public class DodajString : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            Debug.WriteLine("Test");
            var lista = parameter as ListaStringova;
            if ((lista != null) && !string.IsNullOrEmpty(lista.Unos))
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            var lista = parameter as ListaStringova;
            lista.Lista.Add(lista.Unos);
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

        //ObservableCollection<string> lista = new ObservableCollection<string>();
        public ObservableCollection<string> Lista
        {
            get; //=> this.lista;
            set; //=> this.lista = value;
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
                this.Izmena();
            }
            get => this.unos;
        }

        public void Izmena()
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs("Unos"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
