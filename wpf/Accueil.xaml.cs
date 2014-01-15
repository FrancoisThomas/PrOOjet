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
using System.Windows.Forms;
using PrOOjet;

namespace wpf
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : System.Windows.Controls.UserControl
    {
        private Smallworld mainWindow;


        public Accueil()
        {
            InitializeComponent();
        }



        public void ajoutReference(Smallworld main)
        {
         mainWindow = main;
        }

        public void nouvellePartie(object sender, RoutedEventArgs e) 
        {
            Visibility = Visibility.Collapsed;
            mainWindow.EcranLancement.Visibility = Visibility.Visible;
        }

        public void chargePartie(object sender, RoutedEventArgs e)
        {
            OpenFileDialog finder = new OpenFileDialog();
            finder.Filter = "Fichier smallworld(*.sw)|*.sw";
            if (finder.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("Chargement");
                Partie.charger(finder.FileName);
                Console.WriteLine(Partie.INSTANCE.Joueur1.Nom);
                mainWindow.EcranCarte.initialiseIHM();
                Visibility = Visibility.Collapsed;
                mainWindow.EcranCarte.Visibility = Visibility.Visible;
            }
        }

        /*
        public void aPropos(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        */

        public void quitterJeu(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
