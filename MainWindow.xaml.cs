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

namespace felveteli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> betolt = new();
        ObservableCollection<Adat> transforms = new();


        private Adat transport;

        public MainWindow()
        {
            InitializeComponent();

            LoadElements("felveteli.csv");
            
            dtgFelveteli.ItemsSource = transforms;

        }

        private void btnUjDiak_Click(object sender, RoutedEventArgs e)
        {

            transport = new();
            UjDiak ujDiak = new(transport);
            ujDiak.ShowDialog();
            transforms.Add(transport);

        }

        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dtgFelveteli.Items.RemoveAt(dtgFelveteli.SelectedIndex);

            }
            catch (Exception)
            {

            }
            

        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new();
            ofd.ShowDialog();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            List<string> exportLista = new();
            SaveFileDialog sfd = new();
            sfd.ShowDialog();
            foreach (var item in transforms)
            {
                string exportString = $"{item.OMAzonosito};{item.Nev};{item.ErtesitesiCim};{item.SzuletesiDatum};{item.ElerhetosegEmail};{item.MatekPontszam};{item.MagyarPontszam};{item.MatekPontszam};{item.Telefon};{item.Iskola};{item.Konnyites}";
                exportLista.Add(exportString);
            }

        }
        public void LoadElements(string fileNev)
        {
            using (StreamReader sr = new StreamReader(fileNev))
            {
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    Adat s = new(sor);
                    transforms.Add(s);

                }
            }


        }
    }
}
