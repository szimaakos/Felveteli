using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace felveteli
{
    public class Transport
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
    }
}
