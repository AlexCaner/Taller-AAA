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
            Incidencias = new List<Incidencia> //Agafar les files de la BD simplemente y meterlas todas (crear objetos con un bucle.
            {
                new Incidencia("Usuario1", "1234ABC", "Descripción de la incidencia 1", "Reparacio"),
                new Incidencia("Usuario2", "5678DEF", "Descripción de la incidencia 2", "Reparacio"),
                new Incidencia("Usuario1", "1234ABC", "Descripción de la incidencia 1", "Reparacio"),
                new Incidencia("Usuario2", "5678DEF", "Descripción de la incidencia 2", "Reparacio")
            };
            IncidenciasItemsControl.ItemsSource = Incidencias;
        }

        private void Accion1_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Incidencia incidencia)
            {
                //MessageBox Preguntando si de verdad quiere hacerlo
                Incidencias.Remove(incidencia);
            }
            IncidenciasItemsControl.ItemsSource = "";
            IncidenciasItemsControl.ItemsSource = Incidencias;
            //MessageBox Confirmando
        }

        private void Accion2_Click(object sender, RoutedEventArgs e) //Esto hay que mirarlo
        {
            string estatReparacio = "";
            if (sender is FrameworkElement element && element.DataContext is Incidencia incidencia)
            {
                //Aqui hay que poner que pille lo del ComboBox
                estatReparacio =  "" + incidencia.matricula;
                Notificacio notificacio = new Notificacio(incidencia.usuari, incidencia.matricula, estatReparacio);
                //MessageBox Confirmando
            }
        }
    }
}

