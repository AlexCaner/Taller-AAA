using Programa.Classes;
using Programa.Negoci;
using Programa.Negocio;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Programa
{
    public partial class INCIDENCIAS : Window
    {
        //Creem els objectes per gestionar les dades.
        Incidencias incidencies;
        Persones persones = new Persones();
        Notificacions notificacions = new Notificacions();

        public INCIDENCIAS()
        {
            InitializeComponent();
            //Initcialitzem la llista d'incidencies.
            incidencies = new Incidencias();

            //Inserim totes les incidencies a la llista.
            incidencies.TotesLesIncidencies();

            //Enllaçem la llista amb el ItemsControl per crear la part visual dels objectes.
            IncidenciasItemsControl.ItemsSource = incidencies;
        }

        private void Accion1_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Incidencia incidencia)
            {
                //MessageBox on confirmarem l'operació
                MessageBoxResult result = MessageBox.Show(
                    "¿Estas segur que vols eliminar l'incidencia?",
                    "Confirmar realitzada.",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                //Si cliquem el botó "Yes" farem el següent:
                if (result == MessageBoxResult.Yes)
                {
                    //Creem una notificació pel usuari i generarem una factura apartir de les dades del usuari.
                    Notificacio notificacio = new Notificacio(incidencia.usuari, incidencia.matricula, incidencia.descripcio);
                    Factura factura = new Factura();
                    Cliente client;

                    //Fent servir el metode TrobarClient, haurem aconseguit les dades del usuari
                    client = persones.TrobarClient(incidencia.usuari);

                    //Inserim els detalls del client a la factura i la generem.
                    factura.GenerarFacturaXML(client.nom, client.direccio, client.telefon.ToString(), client.correu, DateTime.Now.ToString(), "numeroRandom", "199,03€");

                    //Transformem el XML a HTML fent servir el XSL
                    factura.TransformarXMLaHTML("documents/FacturaXSL.xsl", "facturaArxiu");

                    //Inserim a la Base de Dades una nova notificació
                    notificacions.InsertNoti(notificacio.llegida, notificacio.usuari, notificacio.matricula, notificacio.descripcio);

                    //Inserir BD factures

                    //Eliminem l'incidencia ja que no l'haurem de gestionar més
                    incidencies.DeleteIncidencia(incidencia.id);

                    //Actualitzem el panell d'Items
                    IncidenciasItemsControl.ItemsSource = null;
                    IncidenciasItemsControl.ItemsSource = incidencies;

                    //MessageBox confirmant el procediment.
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
            //Creem un string per generar la notificació al client.
            string estatReparacio = "";

            if (sender is FrameworkElement element && element.DataContext is Incidencia incidencia)
            {
                //Trovem el Item en el panell d'Items
                var stackPanel = element.Parent as StackPanel;
                if (stackPanel != null)
                {

                    // Trobar el ComboBox dins el StackPanel
                    var comboBox = stackPanel.Children
                        .OfType<ComboBox>()
                        .FirstOrDefault();

                    //Fem la comprovació
                    if (comboBox != null && comboBox.SelectedItem is ComboBoxItem selectedItem)
                    {
                        //Seleccionem el estat que hem posat al ComboBox
                        estatReparacio = selectedItem.Content.ToString();
                    }
                }

                // Crear una nova notificació
                Notificacio notificacio = new Notificacio(incidencia.usuari, incidencia.matricula, estatReparacio);

                // Mostrem un MessageBox confirmant la notificació
                MessageBox.Show($"La notificació s'ha creat correctament.", "Confirmació de notificació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


    }
}

