using MySql.Data.MySqlClient;
using Programa.Classes;
using Programa.Dades;
using Programa.Negoci;
using Programa.Negocio;
using Programa.VistesFinestres;
using Programa.VistesFinestres.FinestresMMC;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Programa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Crear Objectes per gestionar notificacions
        private Notificacions llistanotificacions; Notificacions llistaFiltreNotificacions;
        // Crear  els objectes per a gestionar les incidencies
        private Incidencias incidencies;
        private Persones persones = new Persones();
        private Notificacions notificacions = new Notificacions();
        //Crear els objectes per a gestionar les peces.
        private Peces peces2;
        private ICollectionView pecesView;
        // Crear els objectes per a gestionar l'historial
        private Incidencias incidencies2;
        private ICollectionView incidenciesView;
        private Vehicles vehicles;

        public MainWindow()
        {
           
            LogIn logIn = new LogIn(this);
            logIn.Visibility = Visibility.Visible;
            InitializeComponent();

            // Notificacions
            llistanotificacions = new Notificacions();
            llistaFiltreNotificacions = new Notificacions();

            //Inserir en la llista notificacions totes les notificacions de la BD
            llistanotificacions.TotesLesNotis();

            //Afegir les notificacions en el GRID
            dtg_noti_1.ItemsSource = llistanotificacions;

            // Final inicialitzar notificacions

            // Incidencies
            //Initcialitzem la llista d'incidencies.
            incidencies = new Incidencias();

            //Inserim totes les incidencies a la llista.
            incidencies.TotesLesIncidencies();

            //Enllaçem la llista amb el ItemsControl per crear la part visual dels objectes.
            IncidenciasItemsControl.ItemsSource = incidencies;
            // Final Inicialitzar Incidencies

            // Inicialitzar Peces
            peces2 = new Peces();
            peces2.TotesLesPeces();
            pecesView = CollectionViewSource.GetDefaultView(peces2);
            dgPeçes.ItemsSource = pecesView;
            // Finalitzar inicialitzar peces

            // Historial
            incidencies2 = new Incidencias();
            incidencies2 = incidencies2.TotesIncidenciesClient(persones.ConsultarUsuariTemporal());
            dgHistorial.ItemsSource = incidencies2;
            incidenciesView = CollectionViewSource.GetDefaultView(incidencies2);
            dgHistorial.ItemsSource = incidenciesView;

            // Inicialitzar vehicles
            vehicles = new Vehicles();
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Establir visibilitat del ToolTip

            if (tg_btn.IsChecked == true)
            {
                tt_notis.Visibility = Visibility.Collapsed;
                tt_historial.Visibility = Visibility.Collapsed;
                tt_logOutClient.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_notis.Visibility = Visibility.Visible;
                tt_historial.Visibility = Visibility.Visible;
                tt_logOutClient.Visibility = Visibility.Visible;
            }
        }
        private void ListViewItem2_MouseEnter(object sender, MouseEventArgs e)
        {
            if (tg_btn.IsChecked == true)
            {
                tt_historial.Visibility = Visibility.Collapsed;
                tt_logOutMecanic.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_historial.Visibility = Visibility.Visible;
                tt_logOutMecanic.Visibility = Visibility.Visible;
            }
        }

        private void tg_btn_Checked(object sender, RoutedEventArgs e)
        {
            gridMostrar.Opacity = 0.3;
        }

        private void tg_btn_Unchecked(object sender, RoutedEventArgs e)
        {
            gridMostrar.Opacity = 1;
        }

        private void gridMostrar_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tg_btn.IsChecked = false;
        }
        

        // GESTIO MOVIMENTS GRID CLIENT
        private void btn_Notis_Client_Selected(object sender, RoutedEventArgs e)
        {

            gridHistorialClient.Visibility = Visibility.Collapsed;
            gridNotisClient.Visibility = Visibility.Collapsed;
        }
        private void btn_historial_Client_Selected(object sender, RoutedEventArgs e)
        {
            incidencies2 = incidencies2.TotesIncidenciesClient(persones.ConsultarUsuariTemporal());
            dgHistorial.ItemsSource = incidencies2;
            incidenciesView = CollectionViewSource.GetDefaultView(incidencies2);
            dgHistorial.ItemsSource = incidenciesView;
            gridNotisClient.Visibility = Visibility.Collapsed;
            gridHistorialClient.Visibility = Visibility.Visible;
        }
        private void btn_Factures_Client_Selected(object sender, RoutedEventArgs e)
        {
            gridNotisClient.Visibility = Visibility.Collapsed;
            gridHistorialClient.Visibility = Visibility.Collapsed;

        }

        // FINAL GESTIO MOVIMENTS GRID CLIENT

        // GESTIO MOVIMENTS GRID MECANICS

        private void btn_Incidencies_Meca_Selected(object sender, RoutedEventArgs e)
        {
            gridNovaIncidencia.Visibility = Visibility.Collapsed;
            gridPecesMeca.Visibility = Visibility.Collapsed;
            gridIncidenciesMeca.Visibility = Visibility.Visible;
        }
        private void btn_NovaIncidencia_Meca_Selected(object sender, RoutedEventArgs e)
        {

            gridPecesMeca.Visibility = Visibility.Collapsed;
            gridIncidenciesMeca.Visibility = Visibility.Collapsed;
            gridNovaIncidencia.Visibility = Visibility.Visible;
        }
        private void btn_peces_Meca_Selected(object sender, RoutedEventArgs e)
        {
            gridIncidenciesMeca.Visibility = Visibility.Collapsed;
            gridNovaIncidencia.Visibility = Visibility.Collapsed;
            gridPecesMeca.Visibility = Visibility.Visible;
        }

        // FINAL GESTIO MOVIMENTS GRID MECANIS

        // INICI METODES NOTIFICACIONS

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
                        llistaFiltreNotificacions.InsertNoti(n.llegida, n.usuari, n.matricula, n.descripcio);
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
                        llistaFiltreNotificacions.InsertNoti(n.llegida, n.usuari, n.matricula, n.descripcio);
                    }
                }
            }

            //Si totes esta marcada (Filtre)
            else foreach (Notificacio n in llistanotificacions)
                {
                    llistaFiltreNotificacions.InsertNoti(n.llegida, n.usuari, n.matricula, n.descripcio);
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
                    llistaFiltreNotificacions.InsertNoti(n.llegida, n.usuari, n.matricula, n.descripcio);
                }
            }

            //Actualitzem el DataGrid
            dtg_noti_1.ItemsSource = "";
            dtg_noti_1.ItemsSource = llistaFiltreNotificacions;
        }

        // FINAL METODES NOTIFICACIONS

        // INICI INCIDENCIES METODES

        private void Accion1_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Incidencia incidencia)
            {
                //MessageBox on confirmarem l'operació
                MessageBoxResult result = MessageBox.Show(
                    "¿Estas segur que vols eliminar l'incidencia?",
                    "Confirmar realitzada.",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                //Si cliquem el botó "Yes" farem el següent:
                if (result == MessageBoxResult.Yes)
                {
                    //Creem una notificació pel usuari i generarem una factura apartir de les dades del usuari.
                    Notificacio notificacio = new Notificacio(incidencia.usuari, incidencia.matricula, incidencia.descripcio);
                    Factura factura = new Factura();
                    Cliente client;

                    //Fent servir el metode TrobarClient, haurem aconseguit les dades del usuari
                    client = persones.TrobarClient(incidencia.usuari);

                    //Inserim els detalls del client a la factura i la generem.
                    factura.GenerarFacturaXML(client.nom, client.direccio, client.telefon.ToString(), client.correu, DateTime.Now.ToString(), "numeroRandom", "199,03€");

                    //Transformem el XML a HTML fent servir el XSL
                    factura.TransformarXMLaHTML("documents/FacturaXSL.xsl", "facturaArxiu");

                    //Inserim a la Base de Dades una nova notificació
                    notificacions.InsertNoti(notificacio.llegida, notificacio.usuari, notificacio.matricula, notificacio.descripcio);

                    //Inserir BD factures

                    //Eliminem l'incidencia ja que no l'haurem de gestionar més
                    incidencies.DeleteIncidencia(incidencia.id);

                    //Actualitzem el panell d'Items
                    IncidenciasItemsControl.ItemsSource = null;
                    IncidenciasItemsControl.ItemsSource = incidencies;

                    //MessageBox confirmant el procediment.
                    MessageBox.Show(
                        "La incidencia ha sigut eliminada correctament.",
                        "Eliminació completada",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
        }

        private void Accion2_Click(object sender, RoutedEventArgs e)
        {
            //Creem un string per generar la notificació al client.
            string estatReparacio = "";

            if (sender is FrameworkElement element && element.DataContext is Incidencia incidencia)
            {
                //Trovem el Item en el panell d'Items
                var stackPanel = element.Parent as StackPanel;
                if (stackPanel != null)
                {

                    // Trobar el ComboBox dins el StackPanel
                    var comboBox = stackPanel.Children
                        .OfType<ComboBox>()
                        .FirstOrDefault();

                    //Fem la comprovació
                    if (comboBox != null && comboBox.SelectedItem is ComboBoxItem selectedItem)
                    {
                        //Seleccionem el estat que hem posat al ComboBox
                        estatReparacio = selectedItem.Content.ToString();
                    }
                }

                // Crear una nova notificació
                Notificacio notificacio = new Notificacio(incidencia.usuari, incidencia.matricula, estatReparacio);

                // Mostrem un MessageBox confirmant la notificació
                MessageBox.Show($"La notificació s'ha creat correctament.", "Confirmació de notificació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        // FINAL INCIDENCIES METODES
        // INICI PECES METODES

        private void btn_AfegirPeça_Click(object sender, RoutedEventArgs e)
        {
            string nomPeça = txt_NomPeça.Text;
            if (int.TryParse(txt_Quantitat.Text, out int quantitat))  // Comprova si es un int
            {
                Peça peça = new Peça(nomPeça, quantitat);
                Peça peçaExistente = peces2.peces.Find(p => p.nomPeça == nomPeça);

                if (peçaExistente != null)
                {
                    peçaExistente.quantitat += quantitat;
                }
                else
                {
                    peces2.InsertPeça(peça.nomPeça, peça.quantitat);
                }

                txt_NomPeça.Text = string.Empty;
                txt_Quantitat.Text = string.Empty;

                peces2.TotesLesPeces();
                pecesView.Refresh();
            }
            else
            {
                MessageBox.Show("Insereix una quantitat valida.");
            }
        }

        private void btn_Filtrar_Click(object sender, RoutedEventArgs e)
        {
            string filtro = txt_Filtrar.Text;
            if (!string.IsNullOrEmpty(filtro))
            {
                pecesView.Filter = item =>
                {
                    Peça peça = item as Peça;
                    return peça.nomPeça.Contains(filtro, StringComparison.OrdinalIgnoreCase);
                };
            }
            else
            {
                pecesView.Filter = null;
            }
        }

        private void btn_AfegirPeça_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            string nom = txt_NomPeça_Eliminar.Text;

            if (int.TryParse(txt_Quantitat_Eliminar.Text, out int quantitat))
            {
                Peça peçaExistente = peces2.peces.Find(peça => peça.nomPeça == nom);
                if (peçaExistente != null)
                {
                    if (quantitat > 0)
                    {
                        peçaExistente.quantitat -= quantitat;
                        if (peçaExistente.quantitat <= 0)
                        {
                            peces2.DeletePeça(peçaExistente.nomPeça);
                        }
                        else
                        {
                            peces2.UpdatePeça(peçaExistente.nomPeça, peçaExistente.quantitat);
                        }
                    }
                    else
                    {
                        peces2.DeletePeça(peçaExistente.nomPeça);
                    }
                    peces2.TotesLesPeces();
                    pecesView.Refresh();
                }
                else
                {
                    MessageBox.Show("La peça no existeix.");
                }
            }
            else
            {
                MessageBox.Show("Insereix una quantitat valida.");
            }

            txt_NomPeça_Eliminar.Text = string.Empty;
            txt_Quantitat_Eliminar.Text = string.Empty;
        }
        // FINAL PECES METODES

        // INICI HISTORIAL METODES

        private void btn_Filtrar_Click_historial(object sender, RoutedEventArgs e)
        {
            string matricula = txt_Filtrar_Matricula.Text;

            if (!string.IsNullOrEmpty(matricula))
            {
                incidenciesView.Filter = item =>
                {
                    Incidencia incidencia = item as Incidencia;
                    return incidencia.matricula.Contains(matricula, StringComparison.OrdinalIgnoreCase);
                };
            }
            else
            {
                incidenciesView.Filter = null;
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            string estadoSeleccionado = ((RadioButton)sender).Content.ToString();

            switch (estadoSeleccionado)
            {
                case "Aberiat":
                    incidenciesView.Filter = item =>
                    {
                        Incidencia incidencia = item as Incidencia;
                        return incidencia.estat == "Aberiat";
                    };
                    break;
                case "Reparacio":
                    incidenciesView.Filter = item =>
                    {
                        Incidencia incidencia = item as Incidencia;
                        return incidencia.estat == "Reparacio";
                    };
                    break;
                case "Acabat":
                    incidenciesView.Filter = item =>
                    {
                        Incidencia incidencia = item as Incidencia;
                        return incidencia.estat == "Acabat";
                    };
                    break;
                case "Todos":
                    incidenciesView.Filter = null;
                    break;
            }
        }

        // FINAL HISTORIAL METODES

        // INICI INCIDENCIES METODES

        private void btn_inci_1_Click(object sender, RoutedEventArgs e)
        {
            //Agafant les dades del formulari de la pestanya, insertem aquesta a la BD i creem un objecte amb les mateixes dades.
            incidencies.InsertIncidencia(txtb_usr.Text, txtb_matricula.Text, txtb_descripcio.Text, cmbox_estat.Text);
            Incidencia incidencia = new Incidencia(txtb_usr.Text, txtb_matricula.Text, txtb_descripcio.Text, cmbox_estat.Text);

            //Fent servir les dades de la incidencia creada, farem una notificació de la incidencia que veura el client.
            notificacions.InsertNoti(0, incidencia.usuari, incidencia.matricula, incidencia.descripcio);

            //Creem dos variables, un INT per convertir el kilometratge de String a INT i un DateTime per convertir la data del any de fabricació.
            int i;
            int.TryParse(txtb_kilometratge.Text, out i);
            DateTime dataFab;
            DateTime.TryParse(txtb_anyfabricacio.Text, out dataFab);

            //Per últim inserim a la BD el vehicle creat
            vehicles.InsertVehicle(txtb_matricula.Text, txtb_marca.Text, txtb_model.Text, i, dataFab, txtb_tipusMotor.Text);

            // Mostrar un missatge confirmant la creació de la incidència i el vehicle
            MessageBox.Show($"La incidència i el vehicle s'han creat correctament.", "Confirmació de creació", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btn_LogOut_Selected(object sender, RoutedEventArgs e)
        {
            Close();
        }
        // FINAL INCIDENCIES METODES
    }
}