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
            else
            {
                txbKonnyites.Text = "0";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool canSave = true;



            if (txbNev.Text.Split(' ').Count() - 1 == 0)
            {
                canSave = false;
                txbNev.Background = Brushes.Red;
            }
            else
            {
                string neve = "";
                var nevElemek = txbNev.Text.Split(' ');
                for (int i = 0; i < nevElemek.Length; i++)
                {
                    neve += (char.ToUpper(nevElemek[i][0]) + nevElemek[i].Substring(1));
                    neve += " ";
                }
                txbNev.Text = neve.Trim();
            }

            if (txbElerhetosegEmail.Text.Split('@').Length - 1 != 1 || txbElerhetosegEmail.Text.Length == 0 || txbElerhetosegEmail.Text.Split(' ').Length - 1 != 0)
            {
                canSave = false;
                txbElerhetosegEmail.Background = Brushes.Red;
            }

            if (txbOMAzonosito.Text.Length != 11)
            {
                canSave = false;
                txbOMAzonosito.Background = Brushes.Red;
            }

            if (txbErtesiteiCim.Text.Length == 0)
            {
                canSave = false;
                txbErtesiteiCim.Background = Brushes.Red;
            }

            if (txbTelefon.Text.Length == 0)
            {
                canSave = false;
                txbTelefon.Background = Brushes.Red;
            }

            if (txbIskola.Text.Length == 0)
            {
                canSave = false;
                txbIskola.Background = Brushes.Red;
            }
            try
            {
                if (int.Parse(txbMatekPontszam.Text) >= 50 || int.Parse(txbMatekPontszam.Text) < -2)
                {
                    canSave = false;
                    txbMatekPontszam.Background = Brushes.Red;
                }
                if (int.Parse(txbMagyarPontszam.Text) >= 50 || int.Parse(txbMagyarPontszam.Text) < -2)
                {
                    canSave = false;
                    txbMagyarPontszam.Background = Brushes.Red;
                }
            }
            catch {
                canSave = false;
                txbMagyarPontszam.Background = Brushes.Red;
                txbMatekPontszam.Background = Brushes.Red;

            }




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
                SetBackgroundColors();
            }
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }

        private void SetBackgroundColors()
        {

            txbOMAzonosito.Background = Brushes.White;
            txbNev.Background = Brushes.White;
            txbErtesiteiCim.Background = Brushes.White;
            txbElerhetosegEmail.Background = Brushes.White;
            txbMatekPontszam.Background = Brushes.White;
            txbMagyarPontszam.Background = Brushes.White;
            txbTelefon.Background = Brushes.White;
            txbIskola.Background = Brushes.White;
            txbKonnyites.Background = Brushes.White;

            txbSzuletesiDatum.Background = Brushes.White;
        }
    }
}
