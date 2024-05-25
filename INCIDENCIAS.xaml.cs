using Programa.Negoci;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Programa
{
    public partial class INCIDENCIAS : Window
    {
        private List<Incidencia> Incidencias { get; set; }

        public INCIDENCIAS()
        {
            InitializeComponent();
            Incidencias = new List<Incidencia>(); //Agafar les files de la BD simplemente y meterlas todas (crear objetos con un bucle.
            IncidenciasItemsControl.ItemsSource = Incidencias;
        }

        private void Accion1_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Incidencia incidencia)
            {
                Incidencias.Remove(incidencia);
            }
            IncidenciasItemsControl.ItemsSource = "";
            IncidenciasItemsControl.ItemsSource = Incidencias;

        }

        private void Accion2_Click(object sender, RoutedEventArgs e) //Esto hay que mirarlo
        {
            string estatReparacio = "";
            if (sender is FrameworkElement element && element.DataContext is Incidencia incidencia)
            {
                estatReparacio =  "" + incidencia.matricula;
                Notificacio notificacio = new Notificacio(incidencia.usuari, incidencia.matricula, estatReparacio);
            }
        }
    }
}

