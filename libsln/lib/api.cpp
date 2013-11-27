
#include "api.h"
#include "carte.h"

CARTE_DLL int * genereCarte(int taille)
{
	Carte * c = new Carte(taille);
	c->genereCarte();
	return c->getData();
}