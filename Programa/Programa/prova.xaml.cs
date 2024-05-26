using Programa.Classes;
using Programa.Negoci;
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

namespace Programa
{
    /// <summary>
    /// Lógica de interacción para prova.xaml
    /// </summary>
    public partial class prova : Window
    {
        //Creem les llistes per fer la gestió de dades
        Incidencias incidencias;
        Notificacions notificacions;
        Vehicles vehicles;

        public prova()
        {
            InitializeComponent();
            //Inicialitzem les llistes
            incidencias = new Incidencias();
            notificacions = new Notificacions();   
            vehicles = new Vehicles();
        }

        private void btn_inci_1_Click(object sender, RoutedEventArgs e)
        {
            //Agafant les dades del formulari de la pestanya, insertem aquesta a la BD i creem un objecte amb les mateixes dades.
            incidencias.InsertIncidencia(txtb_usr.Text, txtb_matricula.Text, txtb_descripcio.Text, cmbox_estat.Text);
            Incidencia incidencia = new Incidencia(txtb_usr.Text, txtb_matricula.Text, txtb_descripcio.Text, cmbox_estat.Text);

            //Fent servir les dades de la incidencia creada, farem una notificació de la incidencia que veura el client.
            notificacions.InsertNoti(0, incidencia.usuari, incidencia.matricula, incidencia.descripcio);

            //Creem dos variables, un INT per convertir el kilometratge de String a INT i un DateTime per convertir la data del any de fabricació.
            int i;
            int.TryParse(txtb_kilometratge.Text, out i);
            DateTime dataFab;
            DateTime.TryParse(txtb_anyfabricacio.Text, out dataFab);

            //Per últim inserim a la BD el vehicle creat
            vehicles.InsertVehicle(txtb_matricula.Text, txtb_marca.Text, txtb_model.Text, i, dataFab, txtb_tipusMotor.Text);

            // Mostrar un missatge confirmant la creació de la incidència i el vehicle
            MessageBox.Show($"La incidència i el vehicle s'han creat correctament.", "Confirmació de creació", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
