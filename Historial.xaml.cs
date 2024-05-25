using Programa.Negoci;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class Historial : Window
    {
        private Incidencias incidencies2;
        private ICollectionView incidenciesView;

        public Historial()
        {
            InitializeComponent();
            incidencies2 = new Incidencias();
            incidencies2.TotesLesIncidencies();
            dgHistorial.ItemsSource = incidencies2;
            incidenciesView = CollectionViewSource.GetDefaultView(incidencies2);
            dgHistorial.ItemsSource = incidenciesView;
        }

        private void btn_Filtrar_Click(object sender, RoutedEventArgs e)
        {
            string matricula = txt_Filtrar_Matricula.Text;
            if (!string.IsNullOrEmpty(matricula))
            {
                incidenciesView.Filter = item =>
                {
                    Incidencia incidencia = item as Incidencia;
                    return incidencia.matricula.Contains(matricula, StringComparison.OrdinalIgnoreCase);
                };
            }
            else
            {
                incidenciesView.Filter = null;
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            string estadoSeleccionado = ((RadioButton)sender).Content.ToString();

            switch (estadoSeleccionado)
            {
                case "Aberiat":
                    incidenciesView.Filter = item =>
                    {
                        Incidencia incidencia = item as Incidencia;
                        return incidencia.estat == "Aberiat";
                    };
                    break;
                case "Reparacio":
                    incidenciesView.Filter = item =>
                    {
                        Incidencia incidencia = item as Incidencia;
                        return incidencia.estat == "Reparacio";
                    };
                    break;
                case "Acabat":
                    incidenciesView.Filter = item =>
                    {
                        Incidencia incidencia = item as Incidencia;
                        return incidencia.estat == "Acabat";
                    };
                    break;
                case "Todos":
                    incidenciesView.Filter = null;
                    break;
            }
        }
    }
}
