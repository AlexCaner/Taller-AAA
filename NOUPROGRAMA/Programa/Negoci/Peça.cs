using Programa.Dades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Negoci
{
    public class Peça
    {
        // Propietats i Atrivuts
        public string nomPeça { get; set; }
        public int quantitat { get; set; }
        public PeçaBD peçaBD { get; set; }

        // Constructor
        public Peça()
        {
            nomPeça = "";
            quantitat = 0;
        }
        public Peça(string nomPeça, int quantitat)
        {
            this.nomPeça = nomPeça;
            this.quantitat = quantitat;
        }

    }
}