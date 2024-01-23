using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace felveteli
{
    public class Adat
    {
        private string oMAzonosito;
        private string nev;
        private string ertesitesiCim;
        private string szuletesiDatum;
        private string elerhetosegEmail;
        private int matekPontszam;
        private int magyarPontszam;
        private string telefon;
        private string iskola;
        private byte konnyites;

        public Adat() { }

        public Adat(string sor)
        {
            List<string> elemek = sor.Split(';').ToList();
            this.oMAzonosito = elemek[0];
            this.nev = elemek[1];
            this.ertesitesiCim = elemek[2];
            this.szuletesiDatum = elemek[3];
            this.elerhetosegEmail = elemek[4];
            try
            {
            this.matekPontszam = int.Parse(elemek[5]);

            }
            catch (Exception)
            {

                this.matekPontszam = -1;
            }
            try
            {
                this.magyarPontszam = int.Parse((elemek[6]));
            }
            catch (Exception)
            {

                this.magyarPontszam = -1;
            }
            this.telefon = elemek[7];
            this.iskola = elemek[8];
            try
            {
                this.konnyites = byte.Parse(elemek[9]);

            }
            catch (Exception)
            {

                this.konnyites = 0;
            }
        }
        
        public string OMAzonosito { get => oMAzonosito; set => oMAzonosito = value; }
        public string Nev { get => nev; set => nev = value; }
        public string ErtesitesiCim { get => ertesitesiCim; set => ertesitesiCim = value; }
        public string SzuletesiDatum { get => szuletesiDatum; set => szuletesiDatum = value; }
        public string ElerhetosegEmail { get => elerhetosegEmail; set => elerhetosegEmail = value; }
        public int MatekPontszam { get => matekPontszam; set => matekPontszam = value; }
        public int MagyarPontszam { get => magyarPontszam; set => magyarPontszam = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Iskola { get => iskola; set => iskola = value; }
        public byte Konnyites { get => konnyites; set => konnyites = value; }

        /*
        public string OM_Azonosito { get => oMAzonosito; set => oMAzonosito = value; }
        public string Neve { get => nev; set => nev = value; }
        public string ErtesitesiCime { get => ertesitesiCim; set => ertesitesiCim = value; }
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Matematika { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Magyar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime IFelvetelizo.SzuletesiDatum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string CSVSortAdVissza()
        {
            throw new NotImplementedException();
        }

        public void ModositCSVSorral(string csvString)
        {
            throw new NotImplementedException();
        }*/
    }
}
