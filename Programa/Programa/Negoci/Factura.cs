using System;
using System.Xml;

namespace Programa.Negocio
{
    class Factura
    {
        // Propiedades
        public string FacturaArxiu { get; set; }
        public XmlDocument XmlDocument { get; set; }

        // Constructor
        public Factura(string facturaArxiu)
        {
            FacturaArxiu = facturaArxiu;
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
        public void GenerarFacturaXML(string nombreTaller, string direccionTaller, string telefonoTaller, string correoTaller,
                                      string logoTaller, string nombreCliente, string direccionCliente, string telefonoCliente,
                                      string correoCliente, string fecha, string numero, string[][] items, string total)
        {
            try
            {
                // Crear el nodo raíz <factura>
                XmlElement facturaElement = XmlDocument.CreateElement("factura");
                XmlDocument.AppendChild(facturaElement);

                // Agregar nodos para los datos del taller mecánico
                XmlElement tallerElement = XmlDocument.CreateElement("taller");
                facturaElement.AppendChild(tallerElement);
                AddTextNode(tallerElement, "nombre", nombreTaller);
                AddTextNode(tallerElement, "direccion", direccionTaller);
                AddTextNode(tallerElement, "telefon", telefonoTaller);
                AddTextNode(tallerElement, "correu", correoTaller);
                AddTextNode(tallerElement, "logotip", logoTaller);

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

                // Agregar nodos para los items de la factura
                XmlElement itemsElement = XmlDocument.CreateElement("items");
                facturaElement.AppendChild(itemsElement);
                foreach (string[] item in items)
                {
                    AddItemNode(itemsElement, item[0], item[1], item[2], item[3]);
                }

                // Agregar el nodo para el total
                AddTextNode(facturaElement, "total", total);

                // Guardar el documento XML en un archivo
                XmlDocument.Save(FacturaArxiu);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar el archivo XML de la factura: " + ex.Message);
            }
        }

        // Método para agregar un nodo de item a los elementos de item
        private void AddItemNode(XmlElement parentElement, string descripcion, string cantidad, string precioUnitario, string total)
        {
            XmlElement itemElement = XmlDocument.CreateElement("item");
            parentElement.AppendChild(itemElement);
            AddTextNode(itemElement, "descripcio", descripcion);
            AddTextNode(itemElement, "quantitat", cantidad);
            AddTextNode(itemElement, "preuUnitari", precioUnitario);
            AddTextNode(itemElement, "total", total);
        }
    }
}
