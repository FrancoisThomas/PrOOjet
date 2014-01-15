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

        private BitmapImage gaulois = new BitmapImage(new Uri(@"Resources\peupleHumain.gif", UriKind.Relative));
        private BitmapImage nain = new BitmapImage(new Uri(@"Resources\peupleNain.gif", UriKind.Relative));
        private BitmapImage triton = new BitmapImage(new Uri(@"Resources\peupleTriton.gif", UriKind.Relative));
        private BitmapImage aleatoire = new BitmapImage(new Uri(@"Resources\aleatoire.gif", UriKind.Relative));

        private IPeuple peupleJoueur1 = null;

        private IPeuple peupleJoueur2 = null;

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
            {
                Humain1.IsChecked = false;
                aleatoire1(sender, e);
            }
            else
            {
                peupleJoueur1 = Gaulois.INSTANCE;
                imagePeuple1.Source = gaulois;
            }
        }

        private void setNain1(object sender, RoutedEventArgs e)
        {
            if (Nain2.IsChecked == true)
            {
                Nain1.IsChecked = false;
                aleatoire1(sender, e);
            }
            else
            {
                peupleJoueur1 = Nain.INSTANCE;
                imagePeuple1.Source = nain;
            }
        }

        private void setTriton1(object sender, RoutedEventArgs e)
        {
            if (Triton2.IsChecked == true)
            {
                Triton1.IsChecked = false;
                aleatoire1(sender, e);
            }
            else
            {
                peupleJoueur1 = Viking.INSTANCE;
                imagePeuple1.Source = triton;
            }
        }

        private void aleatoire1(object sender, RoutedEventArgs e)
        {
            Aleatoire1.IsChecked = true;
            imagePeuple1.Source = aleatoire;
            peupleJoueur1 = null;
        }


        private void setHumain2(object sender, RoutedEventArgs e)
        {
            if (Humain1.IsChecked == true)
            {
                Humain2.IsChecked = false;
                aleatoire2(sender, e);
            }
            else
            {
                peupleJoueur2 = Gaulois.INSTANCE;
                imagePeuple2.Source = gaulois;
            }
        }

        private void setNain2(object sender, RoutedEventArgs e)
        {
            if (Nain1.IsChecked == true)
            {
                Nain2.IsChecked = false;
                aleatoire2(sender, e);
            }
            else
            {
                peupleJoueur2 = Nain.INSTANCE;
                imagePeuple2.Source = nain;
            }
        }

        private void setTriton2(object sender, RoutedEventArgs e)
        {
            if (Triton1.IsChecked == true)
            {
                Triton2.IsChecked = false;
                aleatoire2(sender, e);
            }
            else
            {
                peupleJoueur2 = Viking.INSTANCE;
                imagePeuple2.Source = triton;
            }
        }

        private void aleatoire2(object sender, RoutedEventArgs e)
        {
            Aleatoire2.IsChecked = true;
            imagePeuple2.Source = aleatoire;
            peupleJoueur2 = null;
        }


        private void jouer(object sender, RoutedEventArgs e)
        {
            string joueur1 = (nomJoueur1.Text.Length == 0 ? "Joueur 1" : nomJoueur1.Text);
            string joueur2 = (nomJoueur2.Text.Length == 0 ? "Joueur 2" : nomJoueur2.Text);

            if (peupleJoueur1 == null)
            {
                if (peupleJoueur2 == Gaulois.INSTANCE)
                    peupleJoueur1 = Nain.INSTANCE;
                else
                    peupleJoueur1 = Gaulois.INSTANCE;
            }

            if (peupleJoueur2 == null)
            {
                if (peupleJoueur1 == Nain.INSTANCE)
                    peupleJoueur2 = Viking.INSTANCE;
                else
                    peupleJoueur2 = Nain.INSTANCE;
            }

            MonteurPartie.INSTANCE.creerPartie(peupleJoueur1, peupleJoueur2, joueur1, joueur2, strat);
            Visibility = Visibility.Collapsed;
            mainWindow.EcranCarte.initialiseIHM();
            mainWindow.EcranCarte.Visibility = Visibility.Visible;
        }
    }
}
