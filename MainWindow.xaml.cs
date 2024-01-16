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

namespace felveteli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> betolt = new();
        List<Transform> transforms = new();
        
            
        private Transport transport ;

        public MainWindow()
        {
            InitializeComponent();

            using(StreamReader sr = new StreamReader("felveteli.csv"))
            {

            }



        }

        private void btnUjDiak_Click(object sender, RoutedEventArgs e)
        {

            transport =new Transport();
            UjDiak ujDiak = new UjDiak(transport);
            ujDiak.ShowDialog();

        }

        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {
            if (dtgFelveteli.SelectedItem != null)
            {
                dtgFelveteli.Items.Remove(dtgFelveteli.SelectedItem);
            }

        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

        }
        public void LoadElements()
        {

            foreach (var item in betolt)
            {
                
            }
        }
    }
}
