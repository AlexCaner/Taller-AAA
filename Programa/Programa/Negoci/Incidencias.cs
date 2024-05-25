﻿using Programa.Classes;
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
    internal class Incidencias : IEnumerable<Incidencia>
    {
        // Atributs i Propietats
        public List<Incidencia> incidencias { get; set; }
        IncidenciasBD IncidenciasBD = new IncidenciasBD();
        // Constructors
       public Incidencias()
        {
            incidencias = new List<Incidencia>();
        }

        // Metodes
        public void TotesLesIncidencies()
        {
            incidencias = IncidenciasBD.TotesIncidencies();
        }
        public void InsertIncidencia(int idIncidencia, string usuari, string matricula, string descripcio, string estat)
        {
            IncidenciasBD.InsertIncidenciaBDD(idIncidencia, usuari, matricula, descripcio, estat);
        }
        public void UpdateIncidencia(int idIncidencia, string usuari, string matricula, string descripcio, string estat)
        {
            IncidenciasBD.UpdateIncidenciaBDD(idIncidencia, usuari, matricula, descripcio, estat);
        }
        public void DeleteIncidencia(int idIncidencia)
        {
            IncidenciasBD.EliminarIncidenciaBDD(idIncidencia);
        }

        // Implementación de IEnumerable<Peça>
        public IEnumerator<Incidencia> GetEnumerator()
        {
            return incidencias.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return incidencias.GetEnumerator();
        }
    }
}