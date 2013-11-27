
#include "api.h"
#include "carte.h"

CARTE_DLL int * genereTableauCarte(int taille)
{
	Carte * c = new Carte(taille);
	c->genereTableauCarte();
	return c->getData();
}