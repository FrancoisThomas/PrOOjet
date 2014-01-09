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
    public partial class Jeu : UserControl
    {

        ICarte carte;
        IPartie partie;

        public Jeu()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            partie = MonteurPartie.INSTANCE.creerPartie(Gaulois.INSTANCE, Viking.INSTANCE, new StrategieNormale());

            // on initialise la Grid (mapGrid défini dans le xaml) à partir de la map du modèle (engine)
            carte = partie.Carte;
            initialiseMapGrid();
            initialiseUnitGrid();

        }

        private void initialiseMapGrid()
        {
            int tailleRectangle = 600 / carte.Taille;
            for (int c = 0; c < carte.Taille; c++)
            {
                mapGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(tailleRectangle, GridUnitType.Pixel) });
                mapGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(tailleRectangle, GridUnitType.Pixel) });
                for (int l = 0; l < carte.Taille; l++)
                {
                    var tile = carte.getCase(c, l);
                    var element = createMapRectangle(c, l, tile);
                    mapGrid.Children.Add(element);
                }
            }

            Dictionary<Coordonnees, List<IUnite>> units = partie.recupereUnites();

            for (int i = 0; i < units.Count; i++)
            {
                Coordonnees coord = units.Keys.ElementAt(i);
                foreach (IUnite unit in units.Values.ElementAt(i))
                {
                    var element = createUnitSprite(coord.posX, coord.posY, unit);
                    mapGrid.Children.Add(element);
                }
            }
        }

        private void initialiseUnitGrid()
        {
            for (int c = 0; c < 5; c++)
            {
                unitGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Pixel) });
            }
            for (int r = 0; r < 2; r++)
            {
                unitGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50, GridUnitType.Pixel) });
            }
        }

        private void updateUnitGrid(List<IUnite> list)
        {
            unitGrid.Children.Clear();
            selectionRectangleUnit.Visibility = System.Windows.Visibility.Collapsed;

            if (list != null)
            {
                int c = 0;
                int r = 0;

                foreach (IUnite unit in list)
                {
                    var element = createUnitRectangle(c, r, unit);
                    unitGrid.Children.Add(element);
                    if (c < 5)
                        c++;
                    else
                    {
                        r++;
                        c = 0;
                    }
                }
            }
        }

        private Rectangle createMapRectangle(int c, int l, ICase tile)
        {
            var rectangle = new Rectangle();
            ImageBrush imageBrush = new ImageBrush();
            if (tile is ICaseDesert)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(@"Resources\desert.png", UriKind.Relative));
                rectangle.Fill = imageBrush;
            }
            if (tile is ICaseForet)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(@"Resources\foret.png", UriKind.Relative));
                rectangle.Fill = imageBrush;
            }
            if (tile is ICaseEau)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(@"Resources\eau.png", UriKind.Relative));
                rectangle.Fill = imageBrush;
            }
            if (tile is ICasePlaine)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(@"Resources\plaine.png", UriKind.Relative));
                rectangle.Fill = imageBrush;
            }
            if (tile is ICaseMontagne)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(@"Resources\montagne.png", UriKind.Relative));
                rectangle.Fill = imageBrush;
            }
            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = tile; // Tag : ref par defaut sur la tuile logique

            rectangle.Stroke = Brushes.Azure;
            rectangle.StrokeThickness = 1;
            // enregistrement d'un écouteur d'evt sur le rectangle : 
            // source = rectangle / evt = MouseLeftButtonDown / délégué = rectangle_MouseLeftButtonDown
            rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(tile_MouseLeftButtonDown);
            return rectangle;
        }

        private Rectangle createUnitRectangle(int c, int l, IUnite unit)
        {
            var rectangle = new Rectangle();
            ImageBrush imageBrush = new ImageBrush();
            if (unit is IUniteGaulois)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(@"Resources\icone_gaulois.png", UriKind.Relative));
                rectangle.Fill = imageBrush;
            }
            if (unit is IUniteNain)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(@"Resources\icone_nain.png", UriKind.Relative));
                rectangle.Fill = imageBrush;
            }
            if (unit is IUniteViking)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(@"Resources\icone_viking.png", UriKind.Relative));
                rectangle.Fill = imageBrush;
            }
            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = unit;

            rectangle.Stroke = Brushes.Azure;
            rectangle.StrokeThickness = 1;
            // enregistrement d'un écouteur d'evt sur le rectangle : 
            // source = rectangle / evt = MouseLeftButtonDown / délégué = rectangle_MouseLeftButtonDown
            rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(unit_MouseLeftButtonDown); // TODO chnager
            return rectangle;
        }

        private Rectangle createUnitSprite(int c, int l, IUnite unit)
        {
            var rectangle = new Rectangle();
            ImageBrush imageBrush = new ImageBrush();
            if (unit is IUniteGaulois)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(@"Resources\icone_gaulois.png", UriKind.Relative));
                rectangle.Fill = imageBrush;
            }
            if (unit is IUniteNain)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(@"Resources\icone_nain.png", UriKind.Relative));
                rectangle.Fill = imageBrush;
            }
            if (unit is IUniteViking)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(@"Resources\icone_viking.png", UriKind.Relative));
                rectangle.Fill = imageBrush;
            }
            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = unit;

            // enregistrement d'un écouteur d'evt sur le rectangle : 
            // source = rectangle / evt = MouseLeftButtonDown / délégué = rectangle_MouseLeftButtonDown
            rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(mapUnit_MouseLeftButtonDown);
            return rectangle;
        }

        /// <summary>
        /// Délégué : réponse à l'evt click gauche sur le rectangle, affichage des informations de la tuile
        /// </summary>
        /// <param name="sender"> le rectangle (la source) </param>
        /// <param name="e"> l'evt </param>
        void tile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var rectangle = sender as Rectangle;
            var tile = rectangle.Tag as ICase;

            int column = Grid.GetColumn(rectangle);
            int row = Grid.GetRow(rectangle);

            // V2 : gestion avec Binding
            // Mise à jour du rectangle selectionné => le label sera mis à jour automatiquement par Binding
            Grid.SetColumn(selectionRectangleMap, column);
            Grid.SetRow(selectionRectangleMap, row);
            selectionRectangleMap.Tag = tile;
            selectionRectangleMap.Width = rectangle.Width;
            selectionRectangleMap.Height = rectangle.Height;
            selectionRectangleMap.Visibility = System.Windows.Visibility.Visible;

            Console.WriteLine(column);
            Console.WriteLine(row);
            Console.WriteLine(selectionRectangleMap.ActualWidth);
            Console.WriteLine(selectionRectangleMap.ActualHeight);
            Console.WriteLine(selectionRectangleMap.Tag);
            Console.WriteLine(selectionRectangleMap.Visibility);

            healthLabel.Content = "";
            attackLabel.Content = "";
            defenseLabel.Content = "";
            movementLabel.Content = "";

            tileImage.Fill = rectangle.Fill;

            updateUnitGrid(partie.selectionneUnites(new Coordonnees(column, row)));

            // on arrête la propagation d'evt : sinon l'evt va jusqu'à la fenetre => affichage via "Window_MouseLeftButtonDown"
            e.Handled = true;
        }


        void unit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var rectangle = sender as Rectangle;
            var unit = rectangle.Tag as IUnite;

            int column = Grid.GetColumn(rectangle);
            int row = Grid.GetRow(rectangle);

            Grid.SetColumn(selectionRectangleUnit, column);
            Grid.SetRow(selectionRectangleUnit, row);
            selectionRectangleUnit.Tag = unit;
            selectionRectangleUnit.Width = rectangle.Width;
            selectionRectangleUnit.Height = rectangle.Height;
            selectionRectangleUnit.Visibility = System.Windows.Visibility.Visible;

            Console.WriteLine(column);
            Console.WriteLine(row);
            Console.WriteLine(selectionRectangleUnit.ActualWidth);
            Console.WriteLine(selectionRectangleUnit.ActualHeight);
            Console.WriteLine(selectionRectangleUnit.Tag);
            Console.WriteLine(selectionRectangleUnit.Visibility);
            Console.WriteLine(selectionRectangleUnit.IsVisible);

            healthLabel.Content = unit.PointsDeVie;
            attackLabel.Content = unit.Attaque;
            defenseLabel.Content = unit.Defense;
            movementLabel.Content = unit.PointsDeMouvement;

            // on arrête la propagation d'evt : sinon l'evt va jusqu'à la fenetre => affichage via "Window_MouseLeftButtonDown"
            e.Handled = true;
        }

        void mapUnit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // TODO
            var rectangle = sender as Rectangle;
            var unit = rectangle.Tag as IUnite;

            int column = Grid.GetColumn(rectangle);
            int row = Grid.GetRow(rectangle);

            List<int> map = partie.suggereDeplacement(unit, new Coordonnees(column, row));

            for (int i = 0; i < partie.Carte.Taille; i++)
            {
                for (int j = 0; j < partie.Carte.Taille; j++)
                {
                    Console.Write(map.ElementAt(i * partie.Carte.Taille + j) + " ");
                }
                Console.WriteLine("");
            }

            // on arrête la propagation d'evt : sinon l'evt va jusqu'à la fenetre => affichage via "Window_MouseLeftButtonDown"
            e.Handled = true;
        }

    }
}
