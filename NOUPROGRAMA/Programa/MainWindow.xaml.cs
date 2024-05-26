using Programa.VistesFinestres;
using Programa.VistesFinestres.FinestresMMC;
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
        public MainWindow()
        {
            InitializeComponent();
            LogIn logIn = new LogIn(this);
            logIn.Visibility = Visibility.Visible;
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Establir visibilitat del ToolTip

            if (tg_btn.IsChecked == true)
            {
                tt_notis.Visibility = Visibility.Collapsed;
                tt_historial.Visibility = Visibility.Collapsed;
                tt_factures.Visibility = Visibility.Collapsed;
                tt_logOutClient.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_notis.Visibility = Visibility.Visible;
                tt_historial.Visibility = Visibility.Visible;
                tt_factures.Visibility = Visibility.Visible;
                tt_logOutClient.Visibility = Visibility.Visible;
            }
        }
        private void ListViewItem2_MouseEnter(object sender, MouseEventArgs e)
        {
            if (tg_btn.IsChecked == true)
            {
                tt_notisMecs.Visibility = Visibility.Collapsed;
                tt_historial.Visibility = Visibility.Collapsed;
                tt_factures.Visibility = Visibility.Collapsed;
                tt_logOutMecanic.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_notisMecs.Visibility = Visibility.Visible;
                tt_historial.Visibility = Visibility.Visible;
                tt_factures.Visibility = Visibility.Visible;
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

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            // Parametre afegit que passa finestraPrincipal
            CloseWindow closeWindow = new CloseWindow(this);
            closeWindow.Show();
        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ListViewItem2_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hola");
        }

        private void btn_Notis_Client_Selected(object sender, RoutedEventArgs e)
        {
            gridHistorialClient.Visibility = Visibility.Collapsed;
            gridFacturesClient.Visibility = Visibility.Collapsed;
            gridNotisClient.Visibility = Visibility.Visible;
        }

        private void btn_historial_Client_Selected(object sender, RoutedEventArgs e)
        {
            gridNotisClient.Visibility = Visibility.Collapsed;
            gridFacturesClient.Visibility = Visibility.Collapsed;
            gridHistorialClient.Visibility = Visibility.Visible;
            
        }

        private void btn_Factures_Client_Selected(object sender, RoutedEventArgs e)
        {
            gridNotisClient.Visibility = Visibility.Collapsed;
            gridHistorialClient.Visibility = Visibility.Collapsed;
            gridFacturesClient.Visibility = Visibility.Visible;
        }
    }
}