using Programa.Dades;
using Programa.Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Negoci
{
    class Factures:IEnumerable<Factura>
    {
        // Atributs i Propietats
        public List<Factura> factures { get; set; }
        FacturesBD facturesBD = new FacturesBD();
        //Constructors
        public Factures() { }
        public void TotesLesFactures()
        {

        }
        // Implementació de l'interficie IEnumerable
        public IEnumerator<Factura> GetEnumerator()
        {
            return factures.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return factures.GetEnumerator();
        }
    }
}
