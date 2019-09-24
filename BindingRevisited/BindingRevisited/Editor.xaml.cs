using System;
using System.Collections.Generic;
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
            BindingExpression b = txtGodine.GetBindingExpression(TextBox.TextProperty);
            b.ValidateWithoutUpdate();
            if (b.HasValidationError)
                txtGodine.Text = b.ValidationError.ErrorContent.ToString();
            else
                b.UpdateSource();
            this.Close();
        }
    }

    public class Godine : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse((string)value, out int i) && i < 120)
                return new ValidationResult(true, null);
            return new ValidationResult(false, "Vrednost nije validna");
        }
    }
}
