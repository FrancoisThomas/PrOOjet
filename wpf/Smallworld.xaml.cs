using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpf
{
    /// <summary>
    /// Logique d'interaction pour Smallworld.xaml
    /// </summary>
    public partial class Smallworld : Window
    {
        public Smallworld()
        {
            InitializeComponent();
            EcranAccueil.ajoutReference(this);
            EcranLancement.ajoutReference(this);
            EcranCarte.ajoutReference(this);
            EcranFin.ajoutReference(this);
        }
    }
}
