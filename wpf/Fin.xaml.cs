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
    /// Logique d'interaction pour Fin.xaml
    /// </summary>
    public partial class Fin : UserControl
    {
        private Smallworld mainWindow;

        private BitmapImage gaulois = new BitmapImage(new Uri(@"Resources\peupleHumain.gif", UriKind.Relative));
        private BitmapImage nain = new BitmapImage(new Uri(@"Resources\peupleNain.gif", UriKind.Relative));
        private BitmapImage triton = new BitmapImage(new Uri(@"Resources\peupleTriton.gif", UriKind.Relative));

        public Fin()
        {
            InitializeComponent();
        }

        public void ajoutReference(Smallworld main)
        {
            mainWindow = main;
        }

        public void initialise()
        {
            if (Partie.INSTANCE.PointsJoueur1 == Partie.INSTANCE.PointsJoueur2)
                resultLabel.Text = "Egalité...";
            else if (Partie.INSTANCE.PointsJoueur1 > Partie.INSTANCE.PointsJoueur2)
            {
                resultLabel.Text = "Victoire !";
                winnerNameLabel.Text = Partie.INSTANCE.Joueur1.Nom;
                nameJ2Label.Foreground = Brushes.DarkKhaki;
                pointsJ2Label.Foreground = Brushes.DarkKhaki;
            }
            else
            {
                resultLabel.Text = "Victoire !";
                winnerNameLabel.Text = Partie.INSTANCE.Joueur2.Nom;
                nameJ1Label.Foreground = Brushes.DarkKhaki;
                pointsJ1Label.Foreground = Brushes.DarkKhaki;
            }

            nameJ1Label.Text = Partie.INSTANCE.Joueur1.Nom;
            nameJ2Label.Text = Partie.INSTANCE.Joueur2.Nom;

            imagePeuple1.Source = imagePeuple(Partie.INSTANCE.Joueur1.Peuple);
            imagePeuple2.Source = imagePeuple(Partie.INSTANCE.Joueur2.Peuple);

            pointsJ1Label.Text = Partie.INSTANCE.PointsJoueur1 + " points";
            pointsJ2Label.Text = Partie.INSTANCE.PointsJoueur2 + " points";
        }

        private BitmapImage imagePeuple(IPeuple p)
        {
            if (p is Gaulois)
                return new BitmapImage(new Uri(@"Resources\peupleHumain.gif", UriKind.Relative));
            else if (p is Nain)
                return new BitmapImage(new Uri(@"Resources\peupleNain.gif", UriKind.Relative));
            else if (p is Viking)
                return new BitmapImage(new Uri(@"Resources\peupleTriton.gif", UriKind.Relative));
            else
                return new BitmapImage(new Uri(@"Resources\aleatoire.gif", UriKind.Relative));
        }
    }
}
