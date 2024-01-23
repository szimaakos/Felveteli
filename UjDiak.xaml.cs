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
            bool uresE = false;
            if (move.Nev == null)
            {
                uresE = true;
            }
            newMove = move;
            InitializeComponent();
            txbOMAzonosito.Text = newMove.OMAzonosito;
            txbNev.Text = newMove.Nev;
            txbErtesiteiCim.Text = newMove.ErtesitesiCim;
            txbSzuletesiDatum.Text = newMove.SzuletesiDatum;
            txbElerhetosegEmail.Text = newMove.ElerhetosegEmail;
            if (!uresE)
            {
                txbMagyarPontszam.Text = newMove.MagyarPontszam.ToString();

            }
            if (!uresE)
            {
                txbMatekPontszam.Text = newMove.MatekPontszam.ToString();

            }
            txbTelefon.Text = newMove.Telefon;
            txbIskola.Text = newMove.Iskola;
            if (!uresE)
            {
                txbKonnyites.Text = newMove.Konnyites.ToString();

            }
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

        private void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }
        /*
        public override void OnClosing(object sender)
        {
            e.Cancel = true;
            base.OnClosing(sender, e);
        }*/
    }
}
