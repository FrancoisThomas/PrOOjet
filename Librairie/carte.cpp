#include "carte.h"


Carte::Carte(int t) : taille(t)
{
	if(t > 0)
	{
		mat = new int[t*t];
	}
	else mat = NULL;
}

Carte::~Carte()
{
	if(mat!=NULL) delete[] mat;
}

int * Carte::getData()
{
	return mat;
}

void Carte::genereTableauCarte()
{
	// TODO Remplir mat
	for(int i=0; i<taille*taille; i++)
		mat[i] = i % 5;
}

void Carte::genereTableauCarte2()
{
	
	srand((unsigned int)time(NULL));
	for(int i=0; i<taille*taille; i++)
		mat[i] = rand() % 5;

	int i = 0;
	estPasse = new bool[taille*taille];
	for (int i = 0; i < taille*taille; i++)
		estPasse[i] = false;

	enum Direction {
		BAS = 0, DROITE
	};

	while (i < taille*taille)
	{
		estPasse[i] = true;

		// Si on est tout en bas de la carte, on doit forcement aller a droite
		if(i == taille - 1)
		{
			i ++;
			if(mat[i] == EAU)
			{
				int r = rand() % taille*taille;
				while(estPasse[r])
					r = rand() % taille*taille;
				mat[i] = mat[r];
				mat[r] = EAU;
			}
		}

		// Si on est tout a droite de la carte, on doit forcement descendre
		else if(i % taille == taille - 1)
		{
			i += taille;
			if(mat[i] == EAU)
			{
				int r = rand() % taille*taille;
				while(estPasse[r])
					r = rand() % taille*taille;
				mat[i] = mat[r];
				mat[r] = EAU;
			}
		}

		// Sinon, on tire au sort la direction
		else
		{
			int dir = rand() % 2;

		}
	}
}

/*bool Carte::testCase(int pos)
{
	bool res;
	if(estTeste[pos] || mat[pos] == EAU)
	{
		estTeste[pos] = true;
		return false;
	}
	else if(pos == taille*taille - 1)
		return true;
	else
	{
		estTeste[pos] = true;
		bool haut, gauche, bas, droite = false;

		if(pos < taille*(taille - 1))
			if(testCase(pos + taille))
				return true;

		if(pos % taille < taille - 1)
			if(testCase(pos + 1))
				return true;

		if(pos > taille)
		{
			bool haut = testCase(pos - taille);
			if(haut)
				return haut;
		}
		if(pos % taille > 0)
		{
			bool gauche = testCase(pos - 1);
			if(gauche)
				return(gauche);
		}
		
	}
	return false;
}


bool Carte::carteValide()
{
	estTeste = new bool[taille*taille];
	return testCase(0);
}

*/