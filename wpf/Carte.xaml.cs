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
    /// Logique d'interaction pour Carte.xaml
    /// </summary>
    public partial class Carte : UserControl
    {

        ICarte carte;
        IPartie partie;

        public Carte()
        {
            InitializeComponent();
            partie = new Partie();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            // on initialise la Grid (mapGrid défini dans le xaml) à partir de la map du modèle (engine)
            carte = partie.getCarte();
            int tailleRectangle = 600 / carte.getTaille();
            for (int c = 0; c < carte.getTaille(); c++)
            {
                mapGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(tailleRectangle, GridUnitType.Pixel) });
                mapGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(tailleRectangle, GridUnitType.Pixel) });
                for (int l = 0; l < carte.getTaille(); l++)
                {
                    var tile = carte.getCase(c, l);
                    var element = creeRectangle(c, l, tile);
                    mapGrid.Children.Add(element);
                }
            }
        }

        private Rectangle creeRectangle(int c, int l, ICase tile)
        {
            var rectangle = new Rectangle();
            if (tile is ICaseDesert)
                rectangle.Fill = Brushes.Brown;
            if (tile is ICaseForet)
                rectangle.Fill = Brushes.DarkGreen;
            if (tile is ICaseEau)
                rectangle.Fill = Brushes.SlateBlue;
            if (tile is ICasePlaine)
                rectangle.Fill = Brushes.LightGreen;
            if (tile is ICaseMontagne)
                rectangle.Fill = Brushes.Gray;
            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = tile; // Tag : ref par defaut sur la tuile logique

            rectangle.Stroke = Brushes.Azure;
            rectangle.StrokeThickness = 1;
            // enregistrement d'un écouteur d'evt sur le rectangle : 
            // source = rectangle / evt = MouseLeftButtonDown / délégué = rectangle_MouseLeftButtonDown
            //rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
            return rectangle;
        }

    }
}
