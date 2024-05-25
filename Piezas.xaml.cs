using Programa.Negoci;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace Programa.Vista
{
    public partial class Piezas : Window
    {
        private Peces peces2;
        private ICollectionView pecesView;

        public Piezas()
        {
            InitializeComponent();
            peces2 = new Peces();
            peces2.TotesLesPeces();
            pecesView = CollectionViewSource.GetDefaultView(peces2);
            dgPeçes.ItemsSource = pecesView;
        }

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
    }
}
