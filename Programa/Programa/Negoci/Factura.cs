using System;
using System.Xml;
using System.Xml.Xsl;

namespace Programa.Negocio
{
    class Factura
    {
        // Atributs i Propietats
        public int idFactura {  get; set; }
        public string usuari {  get; set; }
        public byte[] FacturaArxiu { get; set; }
        public XmlDocument XmlDocument { get; set; }

        // Constructors
        public Factura()
        {
            XmlDocument = new XmlDocument();
            XmlDocument.AppendChild(XmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null));
        }

        // Metode per afegir un node a XML
        private void AddTextNode(XmlElement parentElement, string nodeName, string nodeValue)
        {
            XmlElement newNode = XmlDocument.CreateElement(nodeName);
            newNode.InnerText = nodeValue;
            parentElement.AppendChild(newNode);
        }

        // Metode per generar el fitxer XML
        public void GenerarFacturaXML(string nombreCliente, string direccionCliente, string telefonoCliente,
                                      string correoCliente, string fecha, string numero, string costReparacio)
        {
            try
            {
                // Creem el node arrel del XML
                XmlElement facturaElement = XmlDocument.CreateElement("factura");
                XmlDocument.AppendChild(facturaElement);

                // Afegim nodes de dades del Taller
                XmlElement tallerElement = XmlDocument.CreateElement("taller");
                facturaElement.AppendChild(tallerElement);
                AddTextNode(tallerElement, "nom", "Taller Mecànic XYZ");
                AddTextNode(tallerElement, "direccio", "Carrer Fictici, 43");
                AddTextNode(tallerElement, "telefon", "643424242");
                AddTextNode(tallerElement, "correu", "correutaller@gmail.com");
                AddTextNode(tallerElement, "logotip", "logo.png");

                // Afegim nodes per a les dades del client
                XmlElement clienteElement = XmlDocument.CreateElement("client");
                facturaElement.AppendChild(clienteElement);
                AddTextNode(clienteElement, "nom", nombreCliente);
                AddTextNode(clienteElement, "direccio", direccionCliente);
                AddTextNode(clienteElement, "telefon", telefonoCliente);
                AddTextNode(clienteElement, "correu", correoCliente);

                // Afegim nodes dels detalls de la factura
                XmlElement detallesFacturaElement = XmlDocument.CreateElement("detallsFactura");
                facturaElement.AppendChild(detallesFacturaElement);
                AddTextNode(detallesFacturaElement, "data", fecha);
                AddTextNode(detallesFacturaElement, "numero", numero);

                // Afegim el node del cost de la reparació
                AddTextNode(facturaElement, "costReparacio", costReparacio);

                // Emmagatzamem l'informació en un arxiu XML
                XmlDocument.Save("FacturaArxiu");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar l'arxiu XML de la factura: " + ex.Message);
            }
        }
        
        //Metode per transformar de XML a HTML
        public void TransformarXMLaHTML(string xslPath, string outputHtmlPath)
        {
            try
            {
                XslCompiledTransform xslTransform = new XslCompiledTransform();
                xslTransform.Load(xslPath);
                xslTransform.Transform("FacturaArxiu", outputHtmlPath);
                Console.WriteLine("Transformación completada. Archivo HTML generado en: " + outputHtmlPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al transformar el XML a HTML: " + ex.Message);
            }
        }
    }
}
