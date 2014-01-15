#ifndef COMBAT_H
#define COMBAT_H

#include <stddef.h>
#include <stdlib.h>		// pour utiliser srand/rand
#include <time.h>		// pour utiliser time
#include <algorithm>	// pour utiliser max   

/// <summary>
/// Classe permettant de representer un combat, et de le faire se derouler.
/// </summary>
class Combat
{
private:
	int pdv_attaquant;
	float pdv_attaquant_max;
	int pdv_defenseur;
	float pdv_defenseur_max;
	float points_att_attaquant;
	float att_attaquant;
	float points_def_defenseur;
	float def_defenseur;

public:
	Combat(int pdv_att, int pdv_att_max, int pdv_def, int pdv_def_max, int pts_att, int pts_def);
	~Combat();

	inline int getPointsDeVieAttaquant(){ return this->pdv_attaquant; };
	inline int getPointsDeVieDefenseur(){ return this->pdv_defenseur; };
	void calculeCarac();
	void combattre();
};

#endif