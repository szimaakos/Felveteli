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
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

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
            if (transport.Neve != null)
            {
                felvetelizok.Add(transport);
            }

        }

        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItems = dtgFelveteli.SelectedItems;
                if (selectedItems.Count > 0)
                {
                    List<Object> itemsToRemove = new List<Object>();

                    foreach (var item in selectedItems)
                    {
                        itemsToRemove.Add(item);
                    }

                    foreach (var item in itemsToRemove)
                    {
                        felvetelizok.Remove(item as Adat);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hiba a törlés során!");
            }
        }


        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new();
            ofd.Filter = "Comma Separated Lines (*.csv)|*.csv|JavaScript Object Notation (*.json)|*.json";
            ofd.DefaultExt = "csv";
            ofd.AddExtension = true;
            if (ofd.ShowDialog() == true)
            {
                if (System.IO.Path.GetExtension(ofd.FileName).Trim() == ".csv")
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
                else if (System.IO.Path.GetExtension(ofd.FileName).Trim() == ".json")
                {
                    if (MessageBox.Show("Felülíja a meglévő adatokat?", "Felülírás", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        felvetelizok.Clear();
                        LoadJson(ofd.FileName);
                    }
                    else
                    {
                        LoadJson(ofd.FileName);

                    }

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
                        exportLista.Add(item.CSVSortAdVissza());

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
            try
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
            catch(Exception ex)
            {
                MessageBox.Show($"Hiba történt a CSV fájl betöltésekor: {ex.Message}");
            }


        }
        private void LoadJson(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<Adat> importData = JsonSerializer.Deserialize<List<Adat>>(jsonString, options);

                if (importData != null)
                {
                    foreach (var adat in importData)
                    {
                        felvetelizok.Add(adat);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a JSON fájl betöltésekor: {ex.Message}");
            }
        }


        public void LoadDatabase()
        {

            string adatbazisFelhasznalo = "root";
            string adatbazisJelszo = "";
            string adatbazisNev = "adatbazisnev";
            string adatbazisIP = "localhost";
            int adatbazisPort = 3306;

            string connectionString = $"Server={adatbazisIP},{adatbazisPort};Database={adatbazisNev};User Id={adatbazisFelhasznalo};Password={adatbazisJelszo};";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {adatbazisNev}";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string sor = reader.GetString(0);
                            if (sor.Split(';').Length > 8 && sor.Split(';')[1] != "")
                            {
                                Adat s = new Adat(sor);
                                felvetelizok.Add(s);
                            }
                        }
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
                felvetelizok.Insert(index, transport);

            }
            catch { }
        }
    }
}