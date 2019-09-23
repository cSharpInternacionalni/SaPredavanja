using System;
using System.Collections.Generic;
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
        Osoba nn = new Osoba("Pera", "Peric");
        public MainWindow()
        {
           
            InitializeComponent();
            this.DataContext = nn;
            Binding b = new Binding();
            b.Source = nn;          
            b.Path = new PropertyPath("Ime");
            b.Mode = BindingMode.TwoWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
            BindingOperations.SetBinding(txtBox, TextBox.TextProperty, b);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nn.Ime = "Nesto";
            System.Diagnostics.Debug.WriteLine($"Vrednost je: {this.nn.Ime}");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }

    public class Osoba : INotifyPropertyChanged
    {
        string ime;
        public string Ime
        {
            get => this.ime;
            set
            {
                this.ime = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ime"));
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
            }
        }
        public Osoba(string i, string p)
        {
            this.Ime = i;
            this.Prezime = p;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
