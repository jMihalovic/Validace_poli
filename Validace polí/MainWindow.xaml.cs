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

namespace Validace_polí
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int vek = 0;
            int plat = 0;
            try
            {
                vek = Convert.ToInt32(DatumBox.Text);
                plat = Convert.ToInt32(PlatBox.Text);
                Zamestnanec zam = new Zamestnanec(JmenoBox.Text, PrijmeniBox.Text, vek, VzdelaniBox.Text, PoziceBox.Text, plat);
                Info.Text = $@"Jméno : {zam.Jmeno}
Příjmení : {zam.Prijmeni}
Rok : {zam.DatumNarozeni}
Vzdělání : {zam.Vzdelani}
Pracovní pozice : {zam.Pozice}
Plat : {zam.Plat}";
            }
            catch
            {
                Info.Text = "Plat nebo Datum nebylo číslo";
            }

        }
    }

    public class Osoba
    {
        public Osoba(string jmeno, string prijmeni, int datum)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            DatumNarozeni = datum;
        }
        public string Jmeno
        {
            get;
            private set;
        }
        public string Prijmeni
        {
            get;
            private set;
        }
        public int DatumNarozeni
        {
            get;
            private set;
        }
    }
        public class Zamestnanec : Osoba
        {
        public Zamestnanec(string jmeno, string prijmeni, int datum, string vzdelani, string pozice, int plat) : base(jmeno,prijmeni,datum)
            {
            Vzdelani = vzdelani;
            Pozice = pozice;
            Plat = plat;
            }
        public string Vzdelani
        {
            get;
            set; 
        }
        public string Pozice
        {
            get;
            set;
        }
        public int Plat
        {
            get;
            set;
        }
    }
}
