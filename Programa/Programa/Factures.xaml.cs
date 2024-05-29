using Programa.Classes;
using Programa.Negoci;
using Programa.Negocio;
using System;
using System.Collections;
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
    /// Lógica de interacción para Factures.xaml
    /// </summary>
    public partial class Factures : Window
    {
        //Creem els objectes per gestionar les dades.
        Persones persones = new Persones();
        Factures factures = new Factures();
        public Factures()
        {
            InitializeComponent();
            FacturesItemsControl.ItemsSource = (IEnumerable)factures;


        }
        private void Accion1_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Factura factura)
            {
                // Generar el archivo XML de la factura
                factura.GenerarFacturaXML(
                    "Juan Pérez",
                    "Avenida Siempre Viva 742, Ciudad, País",
                    "0987654321",
                    "juanperez@example.com",
                    "22 de Mayo de 2024",
                    "00123",
                    "170.00"
                );

                // Transformar el XML a HTML usando XSLT
                factura.TransformarXMLaHTML("factura.xsl", "factura.html");
            }
        }
    }
}
