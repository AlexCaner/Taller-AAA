using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Classes
{
    internal class Dates
    {
        //Atributs i Propietats
        public string matricula {  get; set; }
        public DateTime dataEntrada {  get; set; }
        public DateTime dataSortida { get; set;}

        //Constructors (Hi ha d'haver un constructors amb tots els parametres)
        public Dates() { }

        //Metodes
        public DateTime TempsAlTaller() {  return dataEntrada; } //Per fer
        public DateTime DataEntradaAgafar() { return DateTime.Now; }
    }
}
