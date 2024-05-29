using Programa.Classes;
using Programa.Dades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Negoci
{
    public class Peces : IEnumerable<Peça>
    {
        // Atributs i Propietats
        public List<Peça> peces { get; set; }
        PeçaBD peçaBD = new PeçaBD();
        // Constructors
        public Peces()
        {
            peces = new List<Peça>();
        }
        public void TotesLesPeces()
        {
            peces = peçaBD.Totes();
        }
        public void InsertPeça(string nomPeça, int quantitat)
        {
            peçaBD.InsertPecesBDD(nomPeça, quantitat);
        }
        public void UpdatePeça(string nomPeça, int quantitatNou)
        {
            peçaBD.UpdatePecesBDD(nomPeça, quantitatNou);
        }
        public void DeletePeça(string nomPeça)
        {
            peçaBD.EliminarPecesBDD(nomPeça);
        }


        // Implementación de IEnumerable<Peça>
        public IEnumerator<Peça> GetEnumerator()
        {
            return peces.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return peces.GetEnumerator();
        }
    }
}