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
using System.IO;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace felveteli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Adat> felvetelizok = new();

        int selectedItemIndex;


        private Adat transport;

        public MainWindow()
        {
            InitializeComponent();



            dtgFelveteli.ItemsSource = felvetelizok;

            LoadElements("felveteli.csv");


        }

        private void btnUjDiak_Click(object sender, RoutedEventArgs e)
        {

            transport = new();
            UjDiak ujDiak = new(transport);
            ujDiak.ShowDialog();
            if (transport.Nev != null)
            {
                felvetelizok.Add(transport);
            }

        }

        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                felvetelizok.RemoveAt(dtgFelveteli.SelectedIndex);
            }
            catch (Exception)
            {

            }


        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new();
            ofd.Filter = "Comma Separated Lines (*.csv)|*.csv";
            ofd.DefaultExt = "csv";
            ofd.AddExtension = true;
            if (ofd.ShowDialog() == true)
            {
                if (MessageBox.Show("Felülíja a meglévő adatokat?", "Felülírás", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    felvetelizok.Clear();
                    LoadElements(ofd.FileName);
                }
                else
                {

                    LoadElements(ofd.FileName);
                }

            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

            List<string> exportLista = new();
            SaveFileDialog sfd = new();
            sfd.Filter = "Comma Separated Lines (*.csv)|*.csv|JavaScript Object Notation (*.json)|*.json";
            sfd.DefaultExt = "csv";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == true)
            {

                if (System.IO.Path.GetExtension(sfd.FileName).Trim() == ".csv")
                {

                    foreach (var item in felvetelizok)
                    {
                        string exportString = $"{item.OMAzonosito};{item.Nev};{item.ErtesitesiCim};{item.SzuletesiDatum};{item.ElerhetosegEmail};{item.MatekPontszam};{item.MagyarPontszam};{item.MatekPontszam};{item.Telefon};{item.Iskola};{item.Konnyites}";
                        exportLista.Add(exportString);

                    }
                    File.WriteAllLines(sfd.FileName, exportLista);
                }
                else if (System.IO.Path.GetExtension(sfd.FileName).Trim() == ".json")
                {

                    var opciok = new JsonSerializerOptions();
                    opciok.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                    opciok.WriteIndented = true;

                    string adatokSorai = JsonSerializer.Serialize(felvetelizok, opciok);

                    var lista = new List<String>();
                    lista.Add(adatokSorai);
                    File.WriteAllLines(sfd.FileName, lista);
                }

            }


        }
        public void LoadElements(string fileNev)
        {

            using (StreamReader sr = new StreamReader(fileNev))
            {
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    if (sor.Split(';').Length > 8 && sor.Split(';')[1] != "")
                    {
                        Adat s = new(sor);
                        felvetelizok.Add(s);
                    }

                }
            }


        }

        private void btnModosit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = dtgFelveteli.SelectedIndex;
                transport = felvetelizok[index];
                UjDiak ujDiak = new(transport);
                ujDiak.ShowDialog();
                felvetelizok.RemoveAt(index);
                
            }
            catch { }
        }
    }
}
