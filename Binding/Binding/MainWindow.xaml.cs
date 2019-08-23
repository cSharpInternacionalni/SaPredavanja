using System;
using System.Collections.Generic;
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

namespace Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Imena mojaImena = new Imena();
        public MainWindow()
        {
            InitializeComponent();

            
            mojaImena.listaImena.Add("Neko tamo");
            this.DataContext = mojaImena;

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mojaImena.listaImena.Add(((new Random()).Next(100)).ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (lstBox.SelectedItem is string s)
            {
                int indeks = lstBox.SelectedIndex;
                mojaImena.listaImena.Remove(s);

                if (lstBox.Items.Count < 1)
                    indeks = -1;
                else if (lstBox.Items.Count == indeks)
                    indeks--;

                lstBox.SelectedIndex = indeks;
            }
        }
    }
}
