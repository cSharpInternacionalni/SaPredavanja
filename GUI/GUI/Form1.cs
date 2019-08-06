using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Osoba.sveOsobe.AllowNew = false;
            Osoba.sveOsobe.AllowEdit = false;
            InitializeComponent();
            this.dgvOsobe.DataSource = Osoba.sveOsobe;
            Binding veza = new Binding("Text", Osoba.sveOsobe, "ime");
            tbUnos.DataBindings.Add(veza);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            new Osoba(tbUnos.Text, tbUnos2.Text);
            tbUnos.Text = "";
            tbUnos2.Text = "";
            
            this.lblNesto.Text = "Neki tekst";
            //this.dgvOsobe.DataSource = null;
            //this.dgvOsobe.DataSource = Osoba.sveOsobe;

        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            Console.WriteLine("asd");
            Console.ReadLine();
            Debug.WriteLine(e.ToString());
            this.btnUnos.Text = sender.ToString();
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            this.btnUnos.Text = "Neki tekst";

        }

        private void LblNesto_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            foreach (Osoba o in Osoba.sveOsobe)
            {
                Debug.WriteLine(o.ToString());
            }
        }
    }
}
