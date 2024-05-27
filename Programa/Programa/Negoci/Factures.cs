using Programa.Classes;
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
    internal class Factures : IEnumerable<Factura>
    {
        // Attributes and Properties
        public List<Factura> factures { get; private set; } // Marking as private set for encapsulation
        private readonly FacturesBD facturesBD; // Marking as readonly

        // Constructors
        public Factures()
        {
            factures = new List<Factura>();
            facturesBD = new FacturesBD();
        }

        // Method to fetch all invoices (implementation needed)
        public void TotesLesFactures()
        {
            // Implementation needed
        }

        // Implementation of IEnumerable interface
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
