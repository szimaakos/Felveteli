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
        bool isClosing = false;
        Adat newMove;
        public UjDiak(Adat move)
        {
            newMove = move;
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            newMove.OMAzonosito = txbOMAzonosito.Text;
            newMove.Nev = txbNev.Text;
            newMove.ErtesitesiCim = txbErtesiteiCim.Text;
            newMove.SzuletesiDatum = txbSzuletesiDatum.Text;
            newMove.ElerhetosegEmail = txbElerhetosegEmail.Text;
            try
            {
                newMove.MagyarPontszam = int.Parse(txbMagyarPontszam.Text);

            }
            catch (Exception)
            {
                newMove.MagyarPontszam = -1;
            }
            try
            {
                newMove.MatekPontszam = int.Parse(txbMatekPontszam.Text);

            }
            catch (Exception)
            {
                newMove.MatekPontszam = -1;
            }
            newMove.Telefon = txbTelefon.Text;
            newMove.Iskola = txbIskola.Text;
            try
            {
                newMove.Konnyites = byte.Parse(txbKonnyites.Text);

            }
            catch (Exception)
            {
                newMove.Konnyites = 0;

            }
            Close();
        }
    }
}
