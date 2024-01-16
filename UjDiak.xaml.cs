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

namespace felveteli
{
    /// <summary>
    /// Interaction logic for UjDiak.xaml
    /// </summary>
    /// 
    public partial class UjDiak : Window
    {
        public UjDiak(Transport move)
        {
            InitializeComponent();
            move.OMAzonosito = txbOMAzonosito.Text;
            move.Nev = txbNev.Text;
            move.ErtesitesiCim = txbErtesiteiCim.Text;
            move.SzuletesiDatum = txbSzuletesiDatum.Text;
            move.ElerhetosegEmail = txbElerhetosegEmail.Text;
            try
            {
                move.MagyarPontszam = int.Parse(txbMagyarPontszam.Text);

            }
            catch (Exception)
            {
                move.MagyarPontszam = -1;
            }
            try
            {
                move.MatekPontszam = int.Parse(txbMatekPontszam.Text);

            }
            catch (Exception)
            {
                move.MatekPontszam = -1;
            }
            move.Telefon = txbTelefon.Text;
            move.Iskola = txbIskola.Text;
            try
            {
                move.Konnyites = byte.Parse(txbKonnyites.Text);

            }
            catch (Exception)
            {
                move.Konnyites = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
