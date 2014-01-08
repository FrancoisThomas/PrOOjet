
#include "api.h"
#include "carte.h"

Api* Api_new(){ return new Api(); }
void Api_delete(Api* api){ delete api; }

int * Api::genereTableauCarte(int taille)
{
	Carte * c = new Carte(taille);
	c->genereTableauCarte();
	return c->getData();
}