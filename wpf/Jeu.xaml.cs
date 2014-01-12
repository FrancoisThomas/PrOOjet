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

        IUnite uniteSelectionnee;
        Coordonnees coordUniteSelectionnee;

        enum ETypeMouvement {
            IMPOSSIBLE = 0, NUL = 2, NORMALE = 4, SUPER = 6, ENNEMI = 1
        }

        public Jeu()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            partie = MonteurPartie.INSTANCE.creerPartie(Gaulois.INSTANCE, Nain.INSTANCE, new StrategiePetite());

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

                mapUnitGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(tailleRectangle, GridUnitType.Pixel) });
                mapUnitGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(tailleRectangle, GridUnitType.Pixel) });
                Grid.SetRowSpan(mapUnitGrid, carte.Taille);
                Grid.SetColumnSpan(mapUnitGrid, carte.Taille);

                movementGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(tailleRectangle, GridUnitType.Pixel) });
                movementGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(tailleRectangle, GridUnitType.Pixel) });
                Grid.SetRowSpan(movementGrid, carte.Taille);
                Grid.SetColumnSpan(movementGrid, carte.Taille);

                for (int l = 0; l < carte.Taille; l++)
                {
                    var tile = carte.getCase(c, l);
                    var element = createMapRectangle(c, l, tile);
                    mapGrid.Children.Add(element);
                }
            }

            updateUnitMapGrid();
        }

        private void updateUnitMapGrid()
        {
            mapUnitGrid.Children.Clear();
            Dictionary<Coordonnees, List<IUnite>> units = partie.recupereUnites();

            for (int i = 0; i < units.Count; i++)
            {
                Coordonnees coord = units.Keys.ElementAt(i);
                foreach (IUnite unit in units.Values.ElementAt(i))
                {
                    var element = createUnitSprite(coord.posX, coord.posY, unit);
                    mapUnitGrid.Children.Add(element);
                }
            }
        }

        private void initialiseUnitGrid()
        {
            for (int c = 0; c < 4; c++)
            {
                unitGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100, GridUnitType.Pixel) });
            }
            for (int r = 0; r < 2; r++)
            {
                unitGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100, GridUnitType.Pixel) });
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
                    if (c < 3)
                    {
                        c++;
                    }
                    else
                    {
                        c = 0;
                        r++;
                    }
                }
            }
        }

        private void updateSuggestionGrid(IUnite unit, int column, int row)
        {
            List<int> suggestionMap = partie.suggereDeplacement(unit, new Coordonnees(column, row));

            for (int r = 0; r < partie.Carte.Taille; r++)
            {
                for (int c = 0; c < partie.Carte.Taille; c++)
                {
                    if (r != row || c != column)
                    {
                        List<IUnite> unitesCase = partie.selectionneUnites(new Coordonnees(c, r));
                        Rectangle element = null;
                        element = createMovementSuggestionRectangle(c, r, (ETypeMouvement)suggestionMap.ElementAt(r * partie.Carte.Taille + c), unit.Joueur == partie.JoueurActif);
                        movementGrid.Children.Add(element);
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

        private Rectangle createMovementSuggestionRectangle(int c, int l, ETypeMouvement type, bool joueurActif)
        {
            var rectangle = new Rectangle();
            if (type == ETypeMouvement.IMPOSSIBLE)
            {
                rectangle.Fill = Brushes.Black;
                rectangle.Opacity = 0.3;
            }
            else if (type == ETypeMouvement.NUL)
            {
                rectangle.Fill = Brushes.Blue;
                rectangle.Opacity = 0.5;
            }
            else if (type == ETypeMouvement.NORMALE)
            {
                rectangle.Fill = Brushes.Green;
                rectangle.Opacity = 0.5;
            }
            else if (type == ETypeMouvement.SUPER)
            {
                rectangle.Fill = Brushes.GreenYellow;
                rectangle.Opacity = 0.5;
            }
            else
            {
                rectangle.Fill = Brushes.Red;
                rectangle.Opacity = 0.5;
            }
            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = joueurActif ? type : ETypeMouvement.IMPOSSIBLE;

            rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(moveUnit_MouseLeftButtonDown);
            rectangle.MouseRightButtonDown += new MouseButtonEventHandler(moveUnit_MouseRightButtonDown);
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

            int column = Grid.GetColumn(rectangle);
            int row = Grid.GetRow(rectangle);

            // V2 : gestion avec Binding
            // Mise à jour du rectangle selectionné => le label sera mis à jour automatiquement par Binding
            Grid.SetColumn(selectionRectangleMap, column);
            Grid.SetRow(selectionRectangleMap, row);
            selectionRectangleMap.Width = rectangle.Width;
            selectionRectangleMap.Height = rectangle.Height;
            selectionRectangleMap.Visibility = System.Windows.Visibility.Visible;

            healthLabel.Content = "";
            attackLabel.Content = "";
            defenseLabel.Content = "";
            movementLabel.Content = "";

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

            uniteSelectionnee = unit;
            coordUniteSelectionnee = new Coordonnees(column, row);

            Grid.SetColumn(selectionRectangleUnit, column);
            Grid.SetRow(selectionRectangleUnit, row);
            selectionRectangleUnit.Tag = unit;
            selectionRectangleUnit.Width = rectangle.Width;
            selectionRectangleUnit.Height = rectangle.Height;
            selectionRectangleUnit.Visibility = System.Windows.Visibility.Visible;

            healthLabel.Content = unit.PointsDeVie;
            attackLabel.Content = unit.Attaque;
            defenseLabel.Content = unit.Defense;
            movementLabel.Content = unit.PointsDeMouvement;

            // on arrête la propagation d'evt : sinon l'evt va jusqu'à la fenetre => affichage via "Window_MouseLeftButtonDown"
            e.Handled = true;
        }

        void mapUnit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            movementGrid.Children.Clear();

            var rectangle = sender as Rectangle;
            var unit = rectangle.Tag as IUnite;

            int column = Grid.GetColumn(rectangle);
            int row = Grid.GetRow(rectangle);

            Grid.SetColumn(selectionRectangleMap, column);
            Grid.SetRow(selectionRectangleMap, row);
            selectionRectangleMap.Width = rectangle.Width;
            selectionRectangleMap.Height = rectangle.Height;
            selectionRectangleMap.Visibility = System.Windows.Visibility.Visible;

            if (unit.peutBouger())
                updateSuggestionGrid(unit, column, row);

            updateUnitGrid(partie.selectionneUnites(new Coordonnees(column, row)));

            unit_MouseLeftButtonDown(sender, e);
        }

        void moveUnit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            movementGrid.Children.Clear();

            var rectangle = sender as Rectangle;

            int column = Grid.GetColumn(rectangle);
            int row = Grid.GetRow(rectangle);
            
            List<IUnite> unites = partie.selectionneUnites(new Coordonnees(column, row));
            if (unites == null)
            {
                tile_MouseLeftButtonDown(sender, e);
            }
            else
            {
                var rec = rectangle;
                rec.Tag = unites.ElementAt(0);
                mapUnit_MouseLeftButtonDown(rec, e);
            }
        }

        void moveUnit_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var rectangle = sender as Rectangle;
            ETypeMouvement type = (ETypeMouvement)rectangle.Tag;

            int column = Grid.GetColumn(rectangle);
            int row = Grid.GetRow(rectangle);

            Console.WriteLine("(" + column + ";" + row + ") : " + type);

            if (uniteSelectionnee.peutBouger() && type != ETypeMouvement.IMPOSSIBLE)
            {
                if (type == ETypeMouvement.NUL || type == ETypeMouvement.NORMALE || type == ETypeMouvement.SUPER)
                    partie.deplaceUnite(uniteSelectionnee, coordUniteSelectionnee, new Coordonnees(column, row));
                else if (type == ETypeMouvement.ENNEMI)
                    partie.attaque(uniteSelectionnee, partie.selectionneUniteDefensive(new Coordonnees(column, row)));

                updateUnitMapGrid();
                updateUnitGrid(null);
                movementGrid.Children.Clear();
            }
        }


        
        /*
        for (int r = 0; r < partie.Carte.Taille; r++)
        {
            for (int c = 0; c < partie.Carte.Taille; c++)
            {
                Console.Write(l.ElementAt(r * partie.Carte.Taille + c) + " ");
            }
            Console.WriteLine();
        }
        */     


    }
}