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
                MessageBoxResult result = MessageBox.Show(
                    "¿Estas segur que vols eliminar l'incidencia?",
                    "Confirmar realitzada.",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Notificacio notificacio = new Notificacio(incidencia.usuari, incidencia.matricula, incidencia.descripcio);
                    //Inserir BD notificacions
                    Incidencias.Remove(incidencia);
                    //Borrar en la BD
                    IncidenciasItemsControl.ItemsSource = null;
                    IncidenciasItemsControl.ItemsSource = Incidencias;
                    MessageBox.Show(
                        "La incidencia ha sigut eliminada correctament.",
                        "Eliminació completada",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
        }

        private void Accion2_Click(object sender, RoutedEventArgs e)
        {
            string estatReparacio = "";
            if (sender is FrameworkElement element && element.DataContext is Incidencia incidencia)
            {
                var stackPanel = element.Parent as StackPanel;
                if (stackPanel != null)
                {
                    // Trobar el ComboBox dins el StackPanel
                    var comboBox = stackPanel.Children
                        .OfType<ComboBox>()
                        .FirstOrDefault();
                    if (comboBox != null && comboBox.SelectedItem is ComboBoxItem selectedItem)
                    {
                        estatReparacio = selectedItem.Content.ToString();
                    }
                }

                // Crear una nova notificació
                Notificacio notificacio = new Notificacio(incidencia.usuari, incidencia.matricula, estatReparacio);

                // Mostra un quadre de missatge confirmant la notificació
                MessageBox.Show($"La notificació s'ha creat correctament.", "Confirmació de notificació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


    }
}

