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
            Persona persona = new Persona();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string loginU = txt_User.Text, loginC = txt_Pass.Text;
            if (persones.TrobarUsuariClient(loginU, loginC))
            {
                //Interfaz cliente | Guardamos el cliente 
                Cliente cliente = persones.TrobarClient(loginU);
                finestraPrincipal.botonsMenuUsuari.Visibility = Visibility.Visible;
                MessageBox.Show($"Iniciant Sessió...");
                Close();
                finestraPrincipal.Visibility = Visibility.Visible;
            }
            else if (persones.TrobarUsuariMecanic(loginU, loginC))
            {
                //Interfaz Mecanico | Guardamos el mecanico
                Mecanic mecanic = persones.TrobarMecanic(loginU);
                finestraPrincipal.botonsMenuMecanic.Visibility = Visibility.Visible;
                MessageBox.Show($"Iniciant Sessió...");
                Close();
                finestraPrincipal.Visibility = Visibility.Visible;
            }

        }

    }
}
