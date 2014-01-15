#include "api.h"

/// <summary>
/// Constructeur d'api.
/// </summary>
Api * Api_new(){ return new Api(); }

/// <summary>
/// Destructeur d'api.
/// </summary>
void Api_delete(Api* api){ delete api; }

/// <summary>
/// Generateur de la carte.
/// <param name="taille"> La taille de la carte a generer. </param>
/// <returns> La carte contenu dans un tableau a une dimension. </returns>
/// </summary>
int * Api::genereTableauCarte(int taille)
{
	Carte * c = new Carte(taille);
	c->genereTableauCarte2();
	return c->getData();
}

/// <summary>
/// Calculateur de points pour un score de case et un nombre d'ennemi donne.
/// <param name="pointsCarte"> Le score de la case, provenant de l'enum pointsCase </param>
/// <param name="nombreEnnemis"> Le nombre d'ennemi sur la case, permettant de ponderer la valeur de la case </param>
/// <returns> La valeur de la case, selon son score et le nombre d'ennemi. </returns>
/// </summary>
int Api::pointsCase(int pointsCarte, int nombreEnnemis)
{
	int res;
	if(pointsCarte == DEPLACEMENT_IMPOSSIBLE)
		res = DEPLACEMENT_IMPOSSIBLE;

	// Une case avec plus d'un ennemi ne peut etre prise, elle est donc ininteressante.
	else if(nombreEnnemis > 1)
		res = NUL + ENNEMI;
	else if(nombreEnnemis == 1)
		res = pointsCarte + ENNEMI;
	else 
		res = pointsCarte;
	return res;
}

/// <summary>
/// Generateur d'une carte dont toutes les cases sont ponderees par leur apport en points pour le peuple Viking. 
/// <param name="tailleCarte"> La taille de la carte. </param>
/// <param name="carte"> La matrice representant la carte. </param>
/// <returns> La matrice representant la carte ponderee pour les Vikings. </returns>
/// </summary>
int ** Api::cartePondereePointsViking(int tailleCarte, int ** carte)
{
	int ** res = new int *[tailleCarte];
	for(int i = 0; i < tailleCarte; i++)
		res[i] = new int[tailleCarte];

	for(int i = 0; i < tailleCarte; i++)
	{
		for(int j = 0; j < tailleCarte; j++)
		{
			if(carte[i][j] == DESERT) 
				res[i][j] = NUL;
			else if(carte[i][j] == EAU)
			{
				if(i > 0 && carte[i-1][j] != DESERT )
					res[i-1][j] = SUPER;
				if(j > 0 && carte[i][j-1] != DESERT)
					res[i][j-1] = SUPER;
				if(i < (tailleCarte - 1) && carte[i+1][j] != DESERT)
					res[i+1][j] = SUPER;
				if(j < (tailleCarte - 1) && carte[i][j+1] != DESERT)
					res[i][j+1] = SUPER;
			}
			if (res[i][j] < 0)
				res[i][j] = NORMAL;
		}
	}
	return res;
}

/// <summary>
/// Generateur d'une carte referencant les deplacements possibles pour une unite Viking, et leurs gains en points.
/// <param name="posUnite"> La position de l'unite. </param>
/// <param name="carte"> La matrice representant la carte. </param>
/// <param name="tailleCarte"> La taille de la carte. </param>
/// <param name="posEnnemis"> La matrice representant la position des ennemis. </param>
/// <returns> La matrice representant la carte des deplacements possibles pour l'unite Viking. </returns>
/// </summary>
int * Api::deplacementsPossiblesViking(int posUnite, int ** carte, int tailleCarte, int ** posEnnemis)
{
	int * resultat = new int[tailleCarte*tailleCarte];

	int x_unit = posUnite % tailleCarte;
	int y_unit = (int)(posUnite/tailleCarte);

	// On recupere la carte ponderee par la valeur en points des cases
	int ** points = cartePondereePointsViking(tailleCarte, carte);
	
	for (int i = 0; i < tailleCarte; i++)
		for (int j = 0; j < tailleCarte; j++)
			resultat[i*tailleCarte+j] = points[i][j];
	
	for (int i = 0; i < tailleCarte; i++)
	{
		for (int j = 0; j < tailleCarte; j++)
		{
			
			// Si la case n'est pas adjacente a la case de l'unite, alors le deplacement est impossible
			if(std::abs(x_unit-i) + std::abs(y_unit-j) > 1) 
				resultat[i*tailleCarte+j] = DEPLACEMENT_IMPOSSIBLE;

			// Sinon le deplacement est possible, et on examine les differents cas
			else
			{
				// Une case ou sont present plusieurs ennemis ne peut pas etre prise en un combat, 
				// donc elle est ininteressante pour le gain de points
				if (posEnnemis[i][j] > 1) 
					resultat[i*tailleCarte+j] = NUL + ENNEMI;

				// Sinon le score de la case est la somme du nombre de points octroyes par cette case, 
				// ponderee par la presence eventuelle d'ennemis
				else 
					resultat[i*tailleCarte+j] = points[i][j] + (posEnnemis[i][j] == 0 ? RAS : ENNEMI);
			}
		}
	}
	return resultat;
}



/// <summary>
/// Generateur d'une carte referencant les deplacements possibles pour une unite Gauloise, et leurs gains en points.
/// <param name="posUnite"> La position de l'unite. </param>
/// <param name="carte"> La matrice representant la carte. </param>
/// <param name="tailleCarte"> La taille de la carte. </param>
/// <param name="posEnnemis"> La matrice representant la position des ennemis. </param>
/// <returns> La matrice representant la carte des deplacements possibles pour l'unite Gauloise. </returns>
/// </summary>
int * Api::deplacementsPossiblesGaulois(int posUnite, int ** carte, int tailleCarte, int ** posEnnemis)
{
	int ponderationGaulois[5] = {NORMAL, DEPLACEMENT_IMPOSSIBLE, NUL, NORMAL, SUPER};

	int * resultat = new int[tailleCarte*tailleCarte];

	int x_unit = posUnite % tailleCarte;
	int y_unit = (int)(posUnite/tailleCarte);

	int ** res = new int *[tailleCarte];
	
	for (int i = 0; i < tailleCarte; i++)
		res[i] = new int[tailleCarte];

	for (int i = 0; i < tailleCarte; i++)
		for (int j = 0; j < tailleCarte; j++)
			res[i][j] = -1;

	for (int i = 0; i < tailleCarte; i++)
	{
		for (int j = 0; j < tailleCarte; j++)
		{
			// Si la case est eloignee de plus de deux cases de la case de l'unite, alors le deplacement est impossible
			if(std::abs(x_unit-i) + std::abs(y_unit-j) > 2) 
				res[i][j] = DEPLACEMENT_IMPOSSIBLE;

			// Dans le cas ou la case est adjacente et est une plaine
			else if(std::abs(x_unit-i) + std::abs(y_unit-j) < 2 && carte[i][j] == PLAINE) 
			{
				if(i > 0 && posEnnemis[i][j] == 0)
					res[i-1][j] = pointsCase(ponderationGaulois[carte[i-1][j]], posEnnemis[i-1][j]);

				if(j > 0 && posEnnemis[i][j] == 0)
					res[i][j-1] = pointsCase(ponderationGaulois[carte[i][j-1]], posEnnemis[i][j-1]);

				if(i < (tailleCarte - 1) && posEnnemis[i][j] == 0)
					res[i+1][j] = pointsCase(ponderationGaulois[carte[i+1][j]], posEnnemis[i+1][j]);

				if(j < (tailleCarte - 1) && posEnnemis[i][j] == 0)
					res[i][j+1] = pointsCase(ponderationGaulois[carte[i][j+1]], posEnnemis[i][j+1]);

				res[i][j] = pointsCase(ponderationGaulois[carte[i][j]], posEnnemis[i][j]);;
			}
			else if ((std::abs(x_unit-i) + std::abs(y_unit-j) > 1) && res[i][j] < 0)
				res[i][j] = DEPLACEMENT_IMPOSSIBLE;
			else
				res[i][j] = pointsCase(ponderationGaulois[carte[i][j]], posEnnemis[i][j]);
		}
	}

	for (int i = 0; i < tailleCarte; i++)
		for (int j = 0; j < tailleCarte; j++)
			resultat[i*tailleCarte+j] = res[i][j];
	return resultat;
}

/// <summary>
/// Generateur d'une carte referencant les deplacements possibles pour une unite Naine, et leurs gains en points.
/// <param name="posUnite"> La position de l'unite. </param>
/// <param name="carte"> La matrice representant la carte. </param>
/// <param name="tailleCarte"> La taille de la carte. </param>
/// <param name="posEnnemis"> La matrice representant la position des ennemis. </param>
/// <returns> La matrice representant la carte des deplacements possibles pour l'unite Naine. </returns>
/// </summary>
int * Api::deplacementsPossiblesNain(int posUnite, int ** carte, int tailleCarte, int ** posEnnemis)
{
	int ponderationNain[5] = {NORMAL, DEPLACEMENT_IMPOSSIBLE, NORMAL, SUPER, NUL};
	
	int x_unit = posUnite % tailleCarte;
	int y_unit = (int)(posUnite/tailleCarte);

	int * resultat = new int[tailleCarte*tailleCarte];

	for (int i = 0; i < tailleCarte; i++)
	{
		for (int j = 0; j < tailleCarte; j++)
		{
			// Si la case n'est pas adjacente a la case de l'unite, il y a deux cas
			if(std::abs(x_unit-i) + std::abs(y_unit-j) > 1) 
			{ 
				// La case n'est pas une montagne, dans ce cas le deplacement est impossible
				if(carte[x_unit][y_unit] != MONTAGNE || carte[i][j] != MONTAGNE)
					resultat[i*tailleCarte+j] = DEPLACEMENT_IMPOSSIBLE;
				// La case est une montagne on peut s'y deplacer s'il n'y a pas d'ennemi
				else 
					resultat[i*tailleCarte+j] = (posEnnemis[i][j] == 0 ? ponderationNain[MONTAGNE] : DEPLACEMENT_IMPOSSIBLE);
			}
			// Cas des cases adjacentes
			else 
				resultat[i*tailleCarte+j] = pointsCase(ponderationNain[carte[i][j]],posEnnemis[i][j]);
		}
	}	
	return resultat;
}

/// <summary>
/// Permet de calculer le gain en points sur un tour d'un joueur Viking.
/// <param name="carte"> La matrice representant la carte. </param>
/// <param name="tailleCarte"> La taille de la carte. </param>
/// <param name="posUnites"> La matrice representant la position des unites du joueur. </param>
/// <returns> Le nombre de points gagnes sur le tour par le joueur. </returns>
/// </summary>
int Api::calculePointsTourViking(int ** carte, int tailleCarte, int ** posUnites)
{
	int res = 0;
	// On recupere la carte ponderee par la valeur en points des cases
	int ** points = cartePondereePointsViking(tailleCarte, carte);
	for(int i = 0; i < tailleCarte; i++)
		for(int j = 0; j < tailleCarte; j++)
			if(posUnites[i][j] > 0)
				res += (points[i][j]-2)/2;
	return res;
}


/// <summary>
/// Permet de calculer le gain en points sur un tour d'un joueur Gaulois.
/// <param name="carte"> La matrice representant la carte. </param>
/// <param name="tailleCarte"> La taille de la carte. </param>
/// <param name="posUnites"> La matrice representant la position des unites du joueur. </param>
/// <returns> Le nombre de points gagnes sur le tour par le joueur. </returns>
/// </summary>
int Api::calculePointsTourGaulois(int ** carte, int tailleCarte, int ** posUnites)
{
	int res = 0;

	// On recupere la ponderation en points par rapport au type de case
	int ponderationGaulois[5] = {NORMAL, DEPLACEMENT_IMPOSSIBLE, NUL, NORMAL, SUPER};
	for(int i = 0; i < tailleCarte; i++)
		for(int j = 0; j < tailleCarte; j++)
			if(posUnites[i][j] > 0)
				res += (ponderationGaulois[carte[i][j]]-2)/2;
	return res;
}


/// <summary>
/// Permet de calculer le gain en points sur un tour d'un joueur Nain.
/// <param name="carte"> La matrice representant la carte. </param>
/// <param name="tailleCarte"> La taille de la carte. </param>
/// <param name="posUnites"> La matrice representant la position des unites du joueur. </param>
/// <returns> Le nombre de points gagnes sur le tour par le joueur. </returns>
/// </summary>
int Api::calculePointsTourNain(int ** carte, int tailleCarte, int ** posUnites)
{
	int res = 0;

	// On recupere la ponderation en points par rapport au type de case
	int ponderationNain[5] = {NORMAL, DEPLACEMENT_IMPOSSIBLE, NORMAL, SUPER, NUL};
	for(int i = 0; i < tailleCarte; i++)
		for(int j = 0; j < tailleCarte; j++)
			if(posUnites[i][j] > 0)
				res += (ponderationNain[carte[i][j]]-2)/2;
	return res;
}



/// <summary>
/// Permet d'effectuer un combat entre deux unites.
/// <param name="pdvAtt"> Les points de vie de l'attaquant. </param>
/// <param name="pdvAttMax"> Les points de vie max de l'attaquant. </param>
/// <param name="pdvDef"> Les points de vie du defenseur. </param>
/// <param name="pdvDefMax"> Les points de vie max du defenseur. </param>
/// <param name="ptsAtt"> Les points d'attaque de l'attaquant </param>
/// <param name="ptsDef"> Les points de defense du defenseur </param>
/// </summary>
void Api::combat(int pdvAtt, int pdvAttMax, int pdvDef, int pdvDefMax, int ptsAtt, int ptsDef)
{
	// On cree le combat
	Combat * cbt = new Combat(pdvAtt, pdvAttMax, pdvDef, pdvDefMax, ptsAtt, ptsDef);

	// On effectue le combat
	cbt->combattre();
	

	// On recupere la vie de l'attaquant et du defenseur
	this->pdv_attaquant_fin = cbt->getPointsDeVieAttaquant();
	this->pdv_defenseur_fin = cbt->getPointsDeVieDefenseur();
}

