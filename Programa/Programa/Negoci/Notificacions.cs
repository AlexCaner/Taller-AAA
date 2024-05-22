using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Negoci
{
    internal class Notificacions : IEnumerable<Notificacio>
    {
        //Atributs i Propietats
        List<Notificacio> notificacions { get; set; }

        //Constructors
        public Notificacions()
        {
            notificacions = new List<Notificacio>();
        }
        // Métodos para añadir, eliminar y acceder a las notificaciones
        public void Add(Notificacio notificacio)
        {
            notificacions.Add(notificacio);
        }

        public bool Remove(Notificacio notificacio)
        {
            return notificacions.Remove(notificacio);
        }

        public Notificacio this[int index]
        {
            get { return notificacions[index]; }
            set { notificacions[index] = value; }
        }
        public void RemoveAll()
        {
            this.RemoveAll();
        }
        // Implementación de IEnumerable<Notificacio>
        public IEnumerator<Notificacio> GetEnumerator()
        {
            return notificacions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return notificacions.GetEnumerator();
        }
    }
}
