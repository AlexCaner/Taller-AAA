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
        public prova()
        {
            InitializeComponent();
        }

        private void btn_inci_1_Click(object sender, RoutedEventArgs e)
        {
            Incidencia incidencia = new Incidencia(txtb_usr.Text, txtb_matricula.Text, txtb_descripcio.Text, cmbox_estat.Text);
            int i; 
            int.TryParse(txtb_kilometratge.Text, out i);
            DateTime dataFab;
            DateTime.TryParse(txtb_anyfabricacio.Text, out dataFab);
            Vehicle vehicle = new Vehicle(txtb_matricula.Text, txtb_marca.Text, txtb_model.Text, i, dataFab, txtb_tipusMotor.Text);
            //Incidencia se añade a la tabla incidencias de la BD
            //Vehicle se añade a la tabla vehicles de la BD
            //MessageBox Confirmando
        }
    }
}
