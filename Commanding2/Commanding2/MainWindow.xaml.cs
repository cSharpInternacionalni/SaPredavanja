using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var lista = this.DataContext as ListaStringova;
            lista.Lista.Add(lista.Unos);

        }
    }

    public class ListaStringova : INotifyPropertyChanged
    {
        ObservableCollection<string> lista = new ObservableCollection<string>();
        public ObservableCollection<string> Lista
        {
            get => this.lista;
            set => this.lista = value;
        } 

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
