#include "carte.h"

/// <summary>
/// Generateur de la carte.
/// <param name="taille"> La taille de la carte a construire. </param>
/// </summary>
Carte::Carte(int t) : taille(t)
{
	if(t > 0)
	{
		mat = new int[t*t];
	}
	else mat = NULL;
}

/// <summary>
/// Destructeur de carte.
/// </summary>
Carte::~Carte()
{
	if(mat!=NULL) delete[] mat;
}

/// <summary>
/// Accesseur a la carte.
/// <return> La matrice representant la carte. </return>
/// </summary>
int * Carte::getData()
{
	return mat;
}

/// <summary>
/// Une premiere version du generateur de carte, totalement deterministe.
/// </summary>
void Carte::genereTableauCarte()
{
	for(int i=0; i<taille*taille; i++)
	mat[i] = i % 5;
}


/// <summary>
/// Une seconde version du generateur de carte, aleatoire, mais qui permet de ne pas creer une carte "bloquee".
/// </summary>
void Carte::genereTableauCarte2()
{
	
	srand((unsigned int)time(NULL));
	for(int i=0; i<taille*taille; i++)
			mat[i] = rand() % 5;
	validationCarte();
}

/// <summary>
/// Permet de verifier si la carte est valide, c'st a dire que les deux joueurs ne commencent pas sur une case d'eau, 
/// et qu'ils peuvent se rejoindre s'ils le desirent. Modifie la carte dans le cas contraire.
/// </summary>
void Carte::validationCarte()
{
	srand((unsigned int)time(NULL));

	estPasse = new bool[taille*taille];
	for (int i = 0; i < taille*taille; i++)
		estPasse[i] = false;
	

	// Si une des case de depart est de l'eau, on l'echange, en prenant garde a ne pas 
	// l'echanger contre la case de depart de l'autre joueur
	if(mat[0] == EAU)
	{
		echangeCase(0);
		estPasse[0] = true;
	}
	if(mat[taille*taille-1] == EAU)
		echangeCase(taille*taille - 1);

	enum Direction {
		BAS = 0, DROITE
	};

	int i = 0;

	while (i < taille*taille)
	{
		estPasse[i] = true;

		// Si on est tout en bas de la carte, on doit forcement aller a droite
		if(i >= taille*(taille - 1))
		{
			i ++;
			if(mat[i] == EAU)
				echangeCase(i);
		}

		// Si on est tout a droite de la carte, on doit forcement descendre
		else if(i % taille == taille - 1)
		{
			i += taille;
			if(mat[i] == EAU)
				echangeCase(i);
		}

		// Sinon, on tire au sort la direction
		else
		{
			int dir = rand() % 2;

			// Cas ou la direction tiree est BAS
			if(dir == BAS)
			{
				// Si la case en bas est de l'eau, on essaye de la contourner par la droite
				if(mat[i+taille] == EAU)
				{

					// Si la case a droite est aussi de l'eau, alors on force le passage en bas, en
					// echangeant la case d'eau avec une autre case differente, qui n'appartient pas au chemin
					if (mat[i+1] == EAU)
					{
						i += taille; 
						echangeCase(i);
					}

					// Sinon, on peut contourner par la droite
					else
						i++;
				}

				// Sinon, on peut passer par le bas
				else
					i += taille;
			}
			else if(dir == DROITE)
			{
				// Si la case a droite est de l'eau, on essaye de la contourner par le bas
				if(mat[i+1] == EAU)
				{
					// Si la case en bas est aussi de l'eau, alors on force le passage a droite, en
					// echangeant la case d'eau avec une autre case differente, qui n'appartient pas au chemin
					if (mat[i+taille] == EAU)
					{
						i++; 
						echangeCase(i);
					}
					// Sinon, on peut contourner par le bas
					else
						i += taille;
				}
				// Sinon, on passe a droite
				else
					i++;
			}
		}
	}
}


/// <summary>
/// Permet d'echanger une case genante contre une autre, qui ne l'est pas. On verifie bien que la case remplacee 
/// n'est ni sur le chemin emprunte par les joueurs pour se rejoindre, ni du type EAU.
/// </summary>
void Carte::echangeCase(int pos)
{
	srand((unsigned int)time(NULL));
	int r = pos;
	while(mat[r] == EAU || estPasse[r])
		r = rand() % taille*taille;
	mat[pos] = mat[r];
	mat[r] = EAU;
}