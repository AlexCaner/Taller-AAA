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
        public LogIn(MainWindow f)
        {
            finestraPrincipal = f;
            InitializeComponent();
            cont = 150;
            intents = 5;
            usuari1 = "c001";
            contrasenya1 = "1234";
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            bool passwordCorrecte = false;

            string usuari = txt_User.Text;


            if (usuari.Substring(0,1) != "c" && usuari.Substring(0, 1) != "m")
            {
                for (int i = 3; i >= 0; i--)
                {
                    MessageBox.Show("No hi ha cap usuari amb aquest nom");
                    Thread.Sleep(1000);
                }
            }
            // Comprovar usuari Client
            else if (usuari.Substring(0, 1) == "c" && usuari == usuari1)
            {
                // Comprovar contrasenya
                if (txt_Pass.Text == contrasenya1)
                {
                    finestraPrincipal.botonsMenuUsuari.Visibility = Visibility.Visible;
                    MessageBox.Show($"Iniciant Sessió...");
                    Close();
                    passwordCorrecte = true;
                    finestraPrincipal.Visibility = Visibility.Visible;
                }
                else
                {
                    intents -= 1;
                    MessageBox.Show($"La contrasneya no es correcte.");

                }
            }
        }
    }
}
