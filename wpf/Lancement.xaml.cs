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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf
{
    /// <summary>
    /// Logique d'interaction pour Lancement.xaml
    /// </summary>
    public partial class Lancement : UserControl
    {
        private Smallworld mainWindow;


        public Lancement()
        {
            InitializeComponent();
        }



        public void ajoutReference(Smallworld main)
        {
         mainWindow = main;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
