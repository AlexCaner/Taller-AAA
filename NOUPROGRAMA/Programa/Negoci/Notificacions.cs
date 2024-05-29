using Programa.Dades;
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
        NotificacionsBD notificacionsBD = new NotificacionsBD();
        //Constructors
        public Notificacions()
        {
            notificacions = new List<Notificacio>();
        }

        // Metodes
        public void TotesLesNotis()
        {
            notificacions = notificacionsBD.TotesLesNoti();
        }
        public void BorrarTotesLesNotis()
        {
            notificacions = notificacionsBD.BorrarTotesLesNoti();
        }
        public void InsertNoti(int llegida, string usuari, string matricula, string descripcio)
        {
            notificacionsBD.InsertNotiBDD(llegida, usuari, matricula, descripcio);
        }
        public void UpdateNoti(int idNotificacio, int estat)
        {
            notificacionsBD.UpdateNotiBDD(idNotificacio, estat);
        }
        public void Add(Notificacio notificacio)
        {
            notificacions.Add(notificacio);
        }
        public void Remove(Notificacio n)
        {
            notificacions.Remove(n);
        }
        public void DeleteNoti(int idNotificacio)
        {
            notificacionsBD.EliminarNotiBDD(idNotificacio);
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