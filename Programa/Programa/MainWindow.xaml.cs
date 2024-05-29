using Programa.Classes;
using Programa.Negoci;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Programa
{
    public partial class MainWindow : Window
    {
        //Creem els objectes que gestionaran les llistes de notificacions: totes les notificacions (llistanotificacions) i la llista amb filtres (llistaFiltreNotificacions)
        Notificacions llistanotificacions; Notificacions llistaFiltreNotificacions;
        Persones persones;
        string loginU = "johndoe"; string loginC = "password123";
        public MainWindow()
        {
            InitializeComponent();
            //Initzialitcem les llistes
            llistanotificacions = new Notificacions();
            llistaFiltreNotificacions = new Notificacions();
            persones = new Persones();

            //Inserir en la llista notificacions totes les notificacions de la BD
            llistanotificacions.TotesLesNotis();

            //Afegir les notificacions en el GRID
            dtg_noti_1.ItemsSource = llistanotificacions;
            if(persones.TrobarUsuariClient(loginU, loginC))
            {
                //Interfaz cliente | Guardamos el cliente 
                Cliente cliente = persones.TrobarClient(loginU);
            }
            else if(persones.TrobarUsuariMecanic(loginU, loginC))
            {
                //Interfaz Mecanico | Guardamos el mecanico
                Mecanic mecanic = persones.TrobarMecanic(loginU);
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void NotiBtnLlegit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                //Creem una nottificacio apuntant al espai de memoria que ocupa en la linia del DataGrid
                var notifiacio = button.DataContext as Notificacio;

                //Si la notificacio no es null i no esta llegida
                if (notifiacio != null && notifiacio.llegida == 0)
                {
                    //Fem un Update en la taula de notificacions en la BD, marcant que s'ha llegit
                    llistanotificacions.UpdateNoti(notifiacio.idNotificacio, 1);

                    //Actualitzem el GRID en base al RadioButton que estigui pressionat (No me acaba)
                    RadioButtonsComprovar();

                    //Actualitzem el DataGrid
                    dtg_noti_1.ItemsSource = "";
                    if (rdb_noti_3.IsChecked == true)
                        dtg_noti_1.ItemsSource = llistanotificacions;
                    else dtg_noti_1.ItemsSource = llistaFiltreNotificacions;

                    //Inserim totes les notificacions altre vegada a la llista
                    llistanotificacions.TotesLesNotis();
                }
                //Si la notificació ja estava llegida, notificarem a l'usuari amb un MessageBox
                else MessageBox.Show("Notificacio ja marcada com llegida.");    
            }
        }
        private void RadioButtonsComprovar()
        {
            //Esborrem el contingut de la llista de filtre
            llistaFiltreNotificacions.BorrarTotesLesNotis();

            //Si llegides esta marcada (Filtro)
            if (rdb_noti_1.IsChecked == true)
            {
                foreach (Notificacio n in llistanotificacions)
                {
                    if (n.llegida == 0) 
                    {
                        llistaFiltreNotificacions.Add(n);
                    }
                }
            }

            //Si esta marcado no llegides (Filtro)
            else if (rdb_noti_2.IsChecked == true)
            {
                foreach (Notificacio n in llistanotificacions)
                {
                    if (n.llegida == 1)
                    {
                        llistaFiltreNotificacions.Add(n);
                    }
                }
            }

            //Si totes esta marcada (Filtre)
            else foreach (Notificacio n in llistanotificacions)
                {
                    llistaFiltreNotificacions.Add(n);
                }
        }

        private void NotiBtnNoLlegit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                //Creem una nottificacio apuntant al espai de memoria que ocupa en la linia del DataGrid
                var notifiacio = button.DataContext as Notificacio;

                //Si la notificacio no es null i no esta llegida
                if (notifiacio != null && notifiacio.llegida == 1)
                {
                    //Fem un Update en la taula de notificacions en la BD, marcant que s'ha llegit
                    llistanotificacions.UpdateNoti(notifiacio.idNotificacio, 0);

                    //Actualitzem el GRID en base al RadioButton que estigui pressionat (No me acaba)
                    RadioButtonsComprovar();

                    dtg_noti_1.ItemsSource = "";
                    if (rdb_noti_3.IsChecked == true)
                        dtg_noti_1.ItemsSource = llistanotificacions;
                    else dtg_noti_1.ItemsSource = llistaFiltreNotificacions;

                    //Inserim totes les notificacions altre vegada a la llista
                    llistanotificacions.TotesLesNotis(); //No se si se tendria que vaciar todo
                }
                //Si la notificació ja estava no llegida, notificarem a l'usuari amb un MessageBox
                else MessageBox.Show("Notificacio ja marcada com no llegida.");
            }
        }
        private void NotiBtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                //Creem una nottificacio apuntant al espai de memoria que ocupa en la linia del DataGrid
                var notificacio = button.DataContext as Notificacio;

                //Si la notificació no es vuida
                if (notificacio != null)
                {
                    //Eliminem la notificació de la BD
                    llistanotificacions.DeleteNoti(notificacio.idNotificacio);
                    llistanotificacions.Remove(notificacio);
                    dtg_noti_1.ItemsSource = "";
                    if (rdb_noti_3.IsChecked == true)
                        dtg_noti_1.ItemsSource = llistanotificacions;
                    else dtg_noti_1.ItemsSource = llistaFiltreNotificacions;
                }
                
                //Comprovem els filtres
                RadioButtonsComprovar();
            }
        }
        private void btn_noti_cercador_Click(object sender, RoutedEventArgs e)
        {
            //Esborrem totes les notificacions de la llista
            llistaFiltreNotificacions.BorrarTotesLesNotis();

            //Introduim les notificacions en un bucle en la llista de filtre
            foreach (Notificacio n in llistanotificacions)
            {
                //Si la matricula coincideix amb el text que ha introduit l'usuari, s'insereix en la llista
                if (n.matricula == txtb_noti_cercador.Text)
                {
                    llistaFiltreNotificacions.Add(n);
                }
            }

            //Actualitzem el DataGrid 
            dtg_noti_1.ItemsSource = "";
            dtg_noti_1.ItemsSource = llistaFiltreNotificacions;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            INCIDENCIAS w = new INCIDENCIAS();
            w.Show();
        }
    }
}