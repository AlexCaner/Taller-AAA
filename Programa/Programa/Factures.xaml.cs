﻿using Programa.Classes;
using Programa.Negoci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Programa
{
    /// <summary>
    /// Lógica de interacción para Factures.xaml
    /// </summary>
    public partial class Factures : Window
    {
        //Creem els objectes per gestionar les dades.
        Incidencias incidencies;
        Persones persones = new Persones();
        public Factures()
        {
            InitializeComponent();

        }
    }
}
