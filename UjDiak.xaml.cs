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
            if (move.OM_Azonosito == null)
            {
                uresE = true;
            }
            newMove = move;
            InitializeComponent();
            if (!uresE)
            {
                txbOMAzonosito.Text = newMove.OM_Azonosito;
                txbOMAzonosito.IsReadOnly = true;

            }
            txbNev.Text = newMove.Neve;
            txbErtesiteiCim.Text = newMove.ErtesitesiCime;
            txbSzuletesiDatum.Text = newMove.SzuletesiDatum.ToString();
            txbElerhetosegEmail.Text = newMove.Email;
            if (!uresE)
            {
                txbMagyarPontszam.Text = newMove.Magyar.ToString();

            }
            if (!uresE)
            {
                txbMatekPontszam.Text = newMove.Matematika.ToString();

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
            bool canSave = true;

            if (txbNev.Text.Split(' ').Count() - 1 == 0 )
            {
                canSave = false;
            }
            if (txbElerhetosegEmail.Text.Split('@').Length - 1 != 1)
            {

            }
            if (txbOMAzonosito.Text.Length != 11)
            {

            }
            if (txbErtesiteiCim.Text.Length == 0)
            {

            }
            if (txbElerhetosegEmail.Text.Length == 0)
            {

            }
            if (txbTelefon.Text.Length == 0)
            {

            }
            if (txbIskola.Text.Length == 0)
            {

            }

                string neve = "";
                var nevElemek = txbNev.Text.Split(' ');
                for (int i = 0; i < nevElemek.Length; i++)
                {
                    neve += (char.ToUpper(nevElemek[i][0]) + nevElemek[0].Substring(1));
                    neve += " ";
                }
                txbNev.Text = neve.Trim();
            

            if (canSave)
            {

                newMove.OM_Azonosito = txbOMAzonosito.Text;

                newMove.Neve = txbNev.Text;
                newMove.ErtesitesiCime = txbErtesiteiCim.Text;
                newMove.SzuletesiDatum = DateTime.Parse(txbSzuletesiDatum.Text);
                newMove.Email = txbElerhetosegEmail.Text;
                try
                {
                    newMove.Magyar = int.Parse(txbMagyarPontszam.Text);

                }
                catch (Exception)
                {
                    newMove.Magyar = -1;
                }
                try
                {
                    newMove.Matematika = int.Parse(txbMatekPontszam.Text);

                }
                catch (Exception)
                {
                    newMove.Matematika = -1;
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
            else
            {
                MessageBox.Show("Hibás Formátum!");
            }
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
