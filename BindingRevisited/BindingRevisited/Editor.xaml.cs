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
using System.Windows.Shapes;

namespace BindingRevisited
{
    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        public Editor()
        {
            InitializeComponent();
            /*Binding b = new Binding();
            b.Source = this.DataContext;
            b.Path = new PropertyPath("Ime");
            b.Mode = BindingMode.TwoWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
            BindingOperations.SetBinding(txtIme, TextBox.TextProperty, b);*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtIme.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtPrezime.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.Close();
        }
    }
}
