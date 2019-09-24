using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
            nn.Add(new Osoba("Pera", "Peric", "pperic@nesto.com", 83));
            nn.Add(new Osoba("Neko", "Nekic", "neko@negde.nesto", 67));
            nn[1].Platio = true;
            InitializeComponent();
            dg.ItemsSource = nn;
            this.DataContext = nn;
                  }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Editor noviProzor = new Editor();
            noviProzor.DataContext = dg.SelectedItem;
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

        public Boolean platio;
        public Boolean Platio
        {
            get => platio;
            set
            {
                this.platio = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Platio"));
            }
        }

        int godine;
        public int Godine
        {
            get => this.godine;
            set
            {
                this.godine = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Godine"));
            }
        }
        public Osoba(string i, string p, string m, int g)
        {
            this.Ime = i;
            this.Prezime = p;
            this.Mail = m;
            this.Godine = g;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public override string ToString()
        {
            return $"{this.Ime} {this.Prezime}";
        }
    }

    public class BooleanToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Boolean b)
                return b ? Brushes.Green: Brushes.Red;
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
