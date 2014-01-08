#ifndef COMBAT_H
#define COMBAT_H

#include <stddef.h>
#include <stdlib.h>		//srand/rand
#include <time.h>		//time
#include <algorithm>	//max   

class Combat
{
private:
	int pdv_attaquant;
	int pdv_attaquant_max;
	int pdv_defenseur;
	int pdv_defenseur_max;
	int points_att_attaquant;
	int att_attaquant;
	int points_def_defenseur;
	int def_defenseur;

public:
	Combat(int pdv_att, int pdv_att_max, int pdv_def, int pdv_def_max, int pts_att, int pts_def);
	~Combat();

	void calculeCarac();
	void combattre();
};

#endif