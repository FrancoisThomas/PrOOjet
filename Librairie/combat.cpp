#include "combat.h"

Combat::Combat(int pdv_att, int pdv_att_max, int pdv_def, int pdv_def_max, int pts_att, int pts_def)
{
	pdv_attaquant_max = (float)pdv_att_max;
	pdv_attaquant = pdv_att;
	pdv_defenseur_max = (float)pdv_def_max;
	pdv_defenseur = pdv_def;
	points_att_attaquant = (float)pts_att;
	points_def_defenseur = (float)pts_def;
}

Combat::~Combat(){}

void Combat::calculeCarac()
{
	att_attaquant = ((float)pdv_attaquant * points_att_attaquant)/ pdv_attaquant_max;

	def_defenseur = ((float)pdv_defenseur * points_def_defenseur)/ pdv_defenseur_max;
}



void Combat::combattre()
{

	// Calcul du nombre de combats
	srand((unsigned int)time(NULL));
	int nbTours = rand() % (std::max(pdv_attaquant, pdv_defenseur)) + 3;
	
	// 
	int i = 0;
	while(i<nbTours && (std::min(pdv_attaquant, pdv_defenseur)>0))
	{
		// Mise à jour des caracteristiques
		calculeCarac();

		// Calcul de la probabilite que l'attaquant perde une vie
		float proba = 50*((float)att_attaquant/((float)def_defenseur));
		int resultat = rand() % 100;
		(resultat<proba)? pdv_defenseur-- : pdv_attaquant-- ;
		i++;
	}
};