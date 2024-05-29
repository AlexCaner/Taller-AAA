using Programa.Classes;
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

namespace Programa.VistesFinestres
{
    /// <summary>
    /// Lógica de interacción para LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private int cont, intents;
        private string usuari1, contrasenya1, usuari2, contrasenya2;
        private MainWindow finestraPrincipal;
        Persones persones;

        

        public LogIn(MainWindow f)
        {
            finestraPrincipal = f;
            InitializeComponent();
            persones = new Persones();
        }
        public bool LogInOk { get; private set; } = false;


        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string loginU = txt_User.Text, loginC = txt_Pass.Password;
            if (persones.TrobarUsuariClient(loginU, loginC))
            {
                //Interfaz cliente | Guardamos el cliente 
                persones.TreureUsuariTemporal();
                Cliente cliente = persones.TrobarClient(loginU);
                
                persones.InserirUsuariTemporal(loginU);

                finestraPrincipal.botonsMenuUsuari.Visibility = Visibility.Visible;
                Close();
                finestraPrincipal.Visibility = Visibility.Visible;
            }
            else if (persones.TrobarUsuariMecanic(loginU, loginC))
            {
                //Interfaz Mecanico | Guardamos el mecanico
                Mecanic mecanic = persones.TrobarMecanic(loginU);
                finestraPrincipal.botonsMenuMecanic.Visibility = Visibility.Visible;
                Close();
                finestraPrincipal.Visibility = Visibility.Visible;
            }
        }
        private void btn_compte_Click(object sender, RoutedEventArgs e)
        {
            gridLogIn.Visibility = Visibility.Collapsed;
            gridSignIn.Visibility = Visibility.Visible;
        }

        private void btn_compteNew_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Compte creat correctament");
            gridSignIn.Visibility = Visibility.Collapsed;
            gridLogIn.Visibility = Visibility.Visible;
        }
    }
}
