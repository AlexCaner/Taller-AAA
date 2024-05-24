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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Notificacions llistanotificacions; Notificacions llistaFiltreNotificacions;
        public MainWindow()
        {
            InitializeComponent();
            llistanotificacions = new Notificacions(); //
            llistaFiltreNotificacions = new Notificacions();
            for(int i = 0; i < 6; i++)
            {
                Notificacio n = new Notificacio("Estat de reparació: :)");
                llistanotificacions.Add(n);
            }
            for(int i = 0; i < llistanotificacions.Count();i++)
            dtg_noti_1.ItemsSource = llistanotificacions;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void NotiBtnLlegit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var notifiacio = button.DataContext as Notificacio;
                if (notifiacio != null && notifiacio.llegida == false)
                {
                    notifiacio.llegida = true;
                    //No se si se tendria que actualizar la base de datos aqui
                    RadioButtonsComprovar();
                    dtg_noti_1.ItemsSource = "";
                    dtg_noti_1.ItemsSource = llistaFiltreNotificacions;
                }
                else MessageBox.Show("Notificacio ja marcada com llegida.");
                //Refrescar el data grid (Creo que habria que hacer un metodo para esto solo)
    
            }
        }
        private void RadioButtonsComprovar()
        {
            llistaFiltreNotificacions.RemoveAll();
            //Si llegides esta marcada (Filtro)
            if (rdb_noti_1.IsChecked == true)
            {
                foreach (Notificacio n in llistanotificacions)
                {
                    if (!n.llegida) //No se si habria que quitar el nollegida de atributo, no tiene mucho sentido
                    {
                        llistaFiltreNotificacions.Add(n);
                    }
                }
            }
            else if(rdb_noti_2.IsChecked == true)//Si esta marcado no llegides (Filtro)
            {
                foreach (Notificacio n in llistanotificacions)
                {
                    if (n.llegida) //No se si habria que quitar el nollegida de atributo, no tiene mucho sentido
                    {
                        llistaFiltreNotificacions.Add(n);
                    }
                }
            }
            else foreach(Notificacio n in llistanotificacions)
                {
                    llistaFiltreNotificacions.Add(n);
                }
        }
        private void NotiBtnNoLlegit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var notifiacio = button.DataContext as Notificacio;
                if (notifiacio != null && notifiacio.llegida == true)
                {
                    notifiacio.llegida = false;
                    //No se si se tendria que actualizar la base de datos aqui
                    RadioButtonsComprovar();
                    dtg_noti_1.ItemsSource = "";
                    if (rdb_noti_3.IsChecked == true)
                        dtg_noti_1.ItemsSource = llistanotificacions;
                    else dtg_noti_1.ItemsSource = llistaFiltreNotificacions;
                }
                else MessageBox.Show("Notificacio ja marcada com no llegida.");
                //Refrescar el data grid (Creo que habria que hacer un metodo para esto solo)
            }
        }
        private void NotiBtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var notifiacio = button.DataContext as Notificacio;
                if (notifiacio != null)
                {
                    llistanotificacions.Remove(notifiacio); //Tengo que mirar si esto se tiene que hacer en base a si es igual con un metodo aparte
                    //No se si se tendria que actualizar la base de datos aqui
                }
                RadioButtonsComprovar();
                dtg_noti_1.ItemsSource = "";

                if (rdb_noti_3.IsChecked == true)
                    dtg_noti_1.ItemsSource = llistanotificacions;
                else dtg_noti_1.ItemsSource = llistaFiltreNotificacions;
                //Refrescar el data grid (Creo que habria que hacer un metodo para esto solo)

            }
        }
        //private void InserirNotificacions(Notificacions notificacions) //Creo que estos metodos hay que meterlos en una clase | Cogiendo las filas, habria que crear una notificacion nueva con un bucle y meterla dentro de la lista.
        //{
        //    //Depeniendo del usuario, meter los datos, hay que mirar como se hacia
        //    DataRow data = new DataRow(); //Esto hay que hacerlo en el modelo de Dades
        //    foreach (var data in DataRow)
        //    {
        //        Notificacio notificacio = new Notificacio(); //Se coge el string y los dos bools en la base de datos
        //        llistanotificacions.Add(notificacio);
        //    }
        //    //Al final del programa habria que actualizar la base de datos con los datos de las listas
        //}

        private void btn_noti_cercador_Click(object sender, RoutedEventArgs e)
        {
            llistaFiltreNotificacions.RemoveAll();
            foreach (Notificacio n in llistanotificacions)
            {
                if (n.matricula == txtb_noti_cercador.Text)
                {
                    llistaFiltreNotificacions.Add(n);
                }
            }
            //Refrescar el data grid (Creo que habria que hacer un metodo para esto solo)
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