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
using PrOOjet;

namespace wpf
{
    /// <summary>
    /// Logique d'interaction pour Lancement.xaml
    /// </summary>
    public partial class Lancement : UserControl
    {
        private Smallworld mainWindow;
        private IStrategieTaille strat;

        private IPeuple peupleJoueur1;

        private IPeuple peupleJoueur2;

        public Lancement()
        {
            InitializeComponent();
        }



        public void ajoutReference(Smallworld main)
        {
         mainWindow = main;
        }

        private void setStratDemo(object sender, RoutedEventArgs e)
        {
            strat = new StrategieDemo();
        }

        private void setStratPetite(object sender, RoutedEventArgs e)
        {
            strat = new StrategiePetite();
        }

        private void setStratNormale(object sender, RoutedEventArgs e)
        {
            strat = new StrategieNormale();
        }

        public IStrategieTaille getStrat()
        {
            return strat;
        }

        private void setHumain1(object sender, RoutedEventArgs e)
        {
            if (Humain2.IsChecked == true)
                Humain1.IsChecked = false;
            else
                peupleJoueur1 = Gaulois.INSTANCE;
        }

        private void setNain1(object sender, RoutedEventArgs e)
        {
            if (Nain2.IsChecked == true)
                Nain1.IsChecked = false;
            else
                peupleJoueur1 = Nain.INSTANCE;
        }

        private void setTriton1(object sender, RoutedEventArgs e)
        {
            if (Triton2.IsChecked == true)
                Triton1.IsChecked = false;
            else
                peupleJoueur1 = Viking.INSTANCE;
        }

        private void setHumain2(object sender, RoutedEventArgs e)
        {
            if (Humain1.IsChecked == true)
                Humain2.IsChecked = false;
            else
                peupleJoueur2 = Gaulois.INSTANCE;
        }

        private void setNain2(object sender, RoutedEventArgs e)
        {
            if (Nain1.IsChecked == true)
                Nain2.IsChecked = false;
            else
                peupleJoueur2 = Nain.INSTANCE;
        }

        private void setTriton2(object sender, RoutedEventArgs e)
        {
            if (Triton1.IsChecked == true)
                Triton2.IsChecked = false;
            else
                peupleJoueur2 = Viking.INSTANCE;
        }


        private void jouer(object sender, RoutedEventArgs e)
        {
            string joueur1 = (nomJoueur1.Text.Length == 0 ? "Joueur 1" : nomJoueur1.Text);
            string joueur2 = (nomJoueur2.Text.Length == 0 ? "Joueur 2" : nomJoueur2.Text);
            MonteurPartie.INSTANCE.creerPartie(peupleJoueur1, peupleJoueur2, joueur1, joueur2, strat);
            Visibility = Visibility.Collapsed;
            mainWindow.EcranCarte.initialiseIHM();
            mainWindow.EcranCarte.Visibility = Visibility.Visible;
        }
    }
}
