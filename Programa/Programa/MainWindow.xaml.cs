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
            for(int i = 0; i < 5; i++)
            {
                Notificacio n = new Notificacio("hola");
                llistanotificacions.Add(n);
            }

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
                if (notifiacio != null)
                {
                    notifiacio.llegida = true;
                    //No se si se tendria que actualizar la base de datos aqui
                }
                //Si llegides esta marcada (Filtro)
                if (rdb_noti_1.IsChecked == true)
                {
                    foreach (Notificacio n in llistanotificacions)
                    {
                        if (n.llegida == false) //No se si habria que quitar el nollegida de atributo, no tiene mucho sentido
                        {
                            llistaFiltreNotificacions.Add(n);
                        }
                    }
                }
                else //Si esta marcado no llegides (Filtro)
                {
                    foreach (Notificacio n in llistanotificacions)
                    {
                        if (n.llegida == true) //No se si habria que quitar el nollegida de atributo, no tiene mucho sentido
                        {
                            llistaFiltreNotificacions.Add(n);
                        }
                    }
                }
                //Refrescar el data grid (Creo que habria que hacer un metodo para esto solo)
                dtg_noti_1.ItemsSource = "";
                dtg_noti_1.ItemsSource = llistaFiltreNotificacions;

            }
        }

        private void NotiBtnNoLlegit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var notifiacio = button.DataContext as Notificacio;
                if (notifiacio != null)
                {
                    notifiacio.llegida = false;
                    //No se si se tendria que actualizar la base de datos aqui
                }
                //Si llegides esta marcada (Filtro)
                if (rdb_noti_1.IsChecked == true)
                {
                    foreach (Notificacio n in llistanotificacions)
                    {
                        if (n.llegida == false)
                        {
                            llistaFiltreNotificacions.Add(n);
                        }
                    }
                }
                else //Si esta marcado no llegides (Filtro)
                {
                    foreach (Notificacio n in llistanotificacions)
                    {
                        if (n.llegida == true)
                        {
                            llistaFiltreNotificacions.Add(n);
                        }
                    }
                }
                //Refrescar el data grid (Creo que habria que hacer un metodo para esto solo)
                dtg_noti_1.ItemsSource = "";
                dtg_noti_1.ItemsSource = llistaFiltreNotificacions;

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
                //Si llegides esta marcada (Filtro)
                if (rdb_noti_1.IsChecked == true)
                {
                    foreach (Notificacio n in llistanotificacions)
                    {
                        if (n.llegida == false)
                        {
                            llistaFiltreNotificacions.Add(n);
                        }
                    }
                }
                else //Si esta marcado no llegides (Filtro)
                {
                    foreach (Notificacio n in llistanotificacions)
                    {
                        if (n.llegida == true)
                        {
                            llistaFiltreNotificacions.Add(n);
                        }
                    }
                }
                //Refrescar el data grid (Creo que habria que hacer un metodo para esto solo)
                dtg_noti_1.ItemsSource = "";
                dtg_noti_1.ItemsSource = llistaFiltreNotificacions;

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