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
using System.ComponentModel;

namespace Validace_polí
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
     public class Osoba
    {
        public Osoba(string jmeno, string prijmeni, string datum)
    {
        Jmeno = jmeno;
        Prijmeni = prijmeni;
        DatumNarozeni = datum;
    }
    public string Jmeno
    {
        get;
        set;
    }
    public string Prijmeni
    {
        get;
        set;
    }
    public string DatumNarozeni
    {
        get;
        set;
    }
}
public class Zamestnanec : Osoba
{
    public Zamestnanec(string jmeno, string prijmeni, string datum, string vzdelani, string pozice, string plat) : base(jmeno, prijmeni, datum)
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
    public string Plat
    {
        get;
        set;
    }
}
public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Zamestnanec zam;
        public MainWindow()
        {
            InitializeComponent();
            zam = new Zamestnanec("Name", "Surname", "Date", "Education", "Position", "Payment");
            this.DataContext = zam;
            ErrorLabelName.DataContext = this;
            ErrorLabelSurname.DataContext = this;
            ErrorLabelDate.DataContext = this;
            ErrorLabelPosition.DataContext = this;
            ErrorLabelPayment.DataContext = this;
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckNameOK();
        }

        private string _NameError = "Jméno je povinná položka.";
        public string NameError { get { return _NameError; } }
        private bool CheckNameOK()
        {
            if (zam.Jmeno.Length > 0)
            {
                NameErrorVisible = Visibility.Hidden;
                return true;
            }

            else
            {
                NameErrorVisible = Visibility.Visible;
                return false;
            }
        }

        private Visibility _NameErrorVisible;
        public Visibility NameErrorVisible
        {
            get { return _NameErrorVisible; }
            set
            {
                _NameErrorVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("NameErrorVisible"));
            }
        }

        private void Surname_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckSurnameOK();
        }

        private string _SurnameError = "Příjmení je povinná položka";
        public string SurnameError
        {
            get { return _SurnameError; }
            set
            {
                if (zam.Prijmeni.Length < 2)
                    _SurnameError = "Jméno nemůže být kratší než 2 znaky.";
                else if (zam.Prijmeni.Length > 20)
                    _SurnameError = "Jméno nemůže být delší než 20 znaků.";
                else
                    _SurnameError = "";
                PropertyChanged(this, new PropertyChangedEventArgs("SurnameError"));
            }
        }

        private bool CheckSurnameOK()
        {
            if (zam.Prijmeni.Length > 1 && zam.Prijmeni.Length < 30)
            {
                SurnameErrorVisible = Visibility.Hidden;
                return true;
            }

            else
            {
                SurnameErrorVisible = Visibility.Visible;
                SurnameError = "";
                return false;
            }
        }

        private Visibility _SurnameErrorVisible;
        public Visibility SurnameErrorVisible
        {
            get { return _SurnameErrorVisible; }
            set
            {
                _SurnameErrorVisible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SurnameErrorVisible"));
            }
        }

        private void Date_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Convert.ToDateTime(zam.DatumNarozeni);
                DateErrorVisible = Visibility.Hidden;
            }
            catch
            {
                DateErrorVisible = Visibility.Visible;
            }
        }

        private Visibility _DateErrorVisible;
        public Visibility DateErrorVisible
        {
            get { return _DateErrorVisible; }
            set
            {
                _DateErrorVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("DateErrorVisible"));
            }
        }

        private void Position_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (zam.Pozice.Length > 0)
            {
                PositionErrorVisible = Visibility.Hidden;
            }

            else
            {
                PositionErrorVisible = Visibility.Visible;
            }
        }

        private Visibility _PositionErrorVisible;
        public Visibility PositionErrorVisible
        {
            get { return _PositionErrorVisible; }
            set
            {
                _PositionErrorVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("PositionErrorVisible"));
            }
        }

        private void Payment_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Convert.ToInt32(zam.Plat);
                PaymentErrorVisible = Visibility.Hidden;
            }
            catch
            {
                PaymentErrorVisible = Visibility.Visible;
            }
        }

        private Visibility _PaymentErrorVisible;
        public Visibility PaymentErrorVisible
        {
            get { return _PaymentErrorVisible; }
            set
            {
                _PaymentErrorVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("PaymentErrorVisible"));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                Info.Text = $@"Jméno : {zam.Jmeno}
Příjmení : {zam.Prijmeni}
Rok : {zam.DatumNarozeni}
Vzdělání : {zam.Vzdelani}
Pracovní pozice : {zam.Pozice}
Plat : {zam.Plat}";
        }
    }
}
