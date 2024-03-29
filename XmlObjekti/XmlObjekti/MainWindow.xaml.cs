﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;
using System.Xml.Serialization;

namespace XmlObjekti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Osoba> lista 
            = new ObservableCollection<Osoba>();

        public MainWindow()
        {
            InitializeComponent();
            lista.Add(new Osoba(1, "Pera", "Peric"));
            lista.Add(new Osoba(2, "Neko", "Nekic"));
            dg.ItemsSource = lista;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer xml = 
                new XmlSerializer(typeof(ObservableCollection<Osoba>));
            using (FileStream fs = 
                new FileStream("textXML.txt", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, this.lista);
            }
            /*using (StreamWriter sw
                        = new StreamWriter
                             (File.OpenWrite("test.txt")))
                foreach (Osoba o in this.lista)
                    sw.WriteLine($"{o.Id};{o.Ime};{o.Prezime}");*/
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (File.Exists("testXML.txt"))
            {
                using (FileStream fs =
                        new FileStream("testXML.txt", FileMode.Open))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<Osoba>));

                    this.lista = (ObservableCollection<Osoba>)
                                             xml.Deserialize(fs);
                }
                /*using (StreamReader sr =
                            new StreamReader(File.OpenRead("test.txt")))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] obj = sr.ReadLine().Split(';');
                        //Id, ime, prezime
                        this.lista.Add(new Osoba(int.Parse(obj[0]),
                                                  obj[1],
                                                  obj[2]));
                    }

                }*/
            }
        }
    }

    public class Osoba
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public Osoba() { }
        public Osoba(int i, string ime, string pre)
        {
            this.Id = i;
            this.Ime = ime;
            this.Prezime = pre;
        }
    }
}
