
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
		mat[i] = 1;
}