using System;
using System.Xml;
using System.Xml.Xsl;

namespace Programa.Negocio
{
    class Factura
    {
        // Propiedades
        public int idFactura {  get; set; }
        public string usuari {  get; set; }
        public byte[] FacturaArxiu { get; set; }
        public XmlDocument XmlDocument { get; set; }

        // Constructor
        public Factura()
        {
            XmlDocument = new XmlDocument();
            XmlDocument.AppendChild(XmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null));
        }

        // Método para agregar un nodo de texto a un elemento XML
        private void AddTextNode(XmlElement parentElement, string nodeName, string nodeValue)
        {
            XmlElement newNode = XmlDocument.CreateElement(nodeName);
            newNode.InnerText = nodeValue;
            parentElement.AppendChild(newNode);
        }

        // Método para generar el archivo XML de la factura
        public void GenerarFacturaXML(string nombreCliente, string direccionCliente, string telefonoCliente,
                                      string correoCliente, string fecha, string numero, string costReparacio)
        {
            try
            {
                // Crear el nodo raíz <factura>
                XmlElement facturaElement = XmlDocument.CreateElement("factura");
                XmlDocument.AppendChild(facturaElement);

                // Agregar nodos para los datos del taller mecánico
                XmlElement tallerElement = XmlDocument.CreateElement("taller");
                facturaElement.AppendChild(tallerElement);
                AddTextNode(tallerElement, "nom", "Taller Mecànic XYZ");
                AddTextNode(tallerElement, "direccio", "Carrer Fictici, 43");
                AddTextNode(tallerElement, "telefon", "643424242");
                AddTextNode(tallerElement, "correu", "correutaller@gmail.com");
                AddTextNode(tallerElement, "logotip", "logo.png");

                // Agregar nodos para los datos del cliente
                XmlElement clienteElement = XmlDocument.CreateElement("client");
                facturaElement.AppendChild(clienteElement);
                AddTextNode(clienteElement, "nom", nombreCliente);
                AddTextNode(clienteElement, "direccio", direccionCliente);
                AddTextNode(clienteElement, "telefon", telefonoCliente);
                AddTextNode(clienteElement, "correu", correoCliente);

                // Agregar nodos para los detalles de la factura
                XmlElement detallesFacturaElement = XmlDocument.CreateElement("detallsFactura");
                facturaElement.AppendChild(detallesFacturaElement);
                AddTextNode(detallesFacturaElement, "data", fecha);
                AddTextNode(detallesFacturaElement, "numero", numero);

                // Agregar el nodo para el coste de reparación
                AddTextNode(facturaElement, "costReparacio", costReparacio);

                // Guardar el documento XML en un archivo
                XmlDocument.Save(FacturaArxiu);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar el archivo XML de la factura: " + ex.Message);
            }
        }
        public void TransformarXMLaHTML(string xslPath, string outputHtmlPath)
        {
            try
            {
                XslCompiledTransform xslTransform = new XslCompiledTransform();
                xslTransform.Load(xslPath);
                xslTransform.Transform(FacturaArxiu, outputHtmlPath);
                Console.WriteLine("Transformación completada. Archivo HTML generado en: " + outputHtmlPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al transformar el XML a HTML: " + ex.Message);
            }
        }
    }
}
