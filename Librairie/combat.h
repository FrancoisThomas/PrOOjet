#ifndef COMBAT_H
#define COMBAT_H

#include <stddef.h>
#include <stdlib.h>		//srand/rand
#include <time.h>		//time
#include <algorithm>	//max   

class Combat
{
private:
	float pdv_attaquant;
	float pdv_attaquant_max;
	float pdv_defenseur;
	float pdv_defenseur_max;
	float points_att_attaquant;
	float att_attaquant;
	float points_def_defenseur;
	float def_defenseur;

public:
	Combat(int pdv_att, int pdv_att_max, int pdv_def, int pdv_def_max, int pts_att, int pts_def);
	~Combat();

	void calculeCarac();
	void combattre();
};

#endif