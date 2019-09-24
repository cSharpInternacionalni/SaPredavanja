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

namespace BindingRevisited
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Osoba> nn = new ObservableCollection<Osoba>();
        public MainWindow()
        {
            nn.Add(new Osoba("Pera", "Peric", "pperic@nesto.com"));
            nn.Add(new Osoba("Neko", "Nekic", "neko@negde.nesto"));
            InitializeComponent();
            dg.ItemsSource = nn;
            this.DataContext = nn;
                  }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Editor noviProzor = new Editor();
            noviProzor.Visibility = Visibility.Visible;
        }
    }

    public class Osoba : INotifyPropertyChanged
    {
        public string ImeIPrezime { get => $"{this.ime} {this.prezime}"; }
        public string ime;
        public string Ime
        {
            get => this.ime;
            set
            {
                this.ime = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ime"));
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImeIPrezime"));
            }
        }

        string prezime;
        public string Prezime
        {
            get => this.prezime;
            set
            {
                this.prezime = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Prezime"));
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImeIPrezime"));
            }
        }

        string mail;
        public string Mail
        {
            get => mail;
            set
            {
                this.mail = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Mail"));
            }
        }

        Boolean platio;
        public Boolean Platio
        {
            get => platio;
            set
            {
                this.platio = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Platio"));
            }
        }
        public Osoba(string i, string p, string m)
        {
            this.Ime = i;
            this.Prezime = p;
            this.Mail = m;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public override string ToString()
        {
            return $"{this.Ime} {this.Prezime}";
        }
    }
}
