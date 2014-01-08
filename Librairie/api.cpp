
#include "api.h"

Api* Api_new(){ return new Api(); }
void Api_delete(Api* api){ delete api; }

int * Api::genereTableauCarte(int taille)
{
	Carte * c = new Carte(taille);
	c->genereTableauCarte();
	return c->getData();
}

void Api::combat(int pdvAtt, int pdvAttMax, int pdvDef, int pdvDefMax, int ptsAtt, int ptsDef)
{
	Combat * cbt = new Combat(pdvAtt, pdvAttMax, pdvDef, pdvDefMax, ptsAtt, ptsDef);
	cbt->combattre();
}