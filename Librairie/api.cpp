
#include "api.h"

Api* Api_new(){ return new Api(); }
void Api_delete(Api* api){ delete api; }

int * Api::genereTableauCarte(int taille)
{
	Carte * c = new Carte(taille);
	c->genereTableauCarte();
	return c->getData();
}

void combattre(int pdv_att, int pdv_att_max, int pdv_def, int pdv_def_max, int pts_att, int pts_def)
{
	Combat * cbt = new Combat(pdv_att, pdv_att_max, pdv_def, pdv_def_max, pts_att, pts_def);

}