#include "api.h"

Api * Api_new(){ return new Api(); }
void Api_delete(Api* api){ delete api; }

enum cases{
	DESERT = 0, EAU, MONTAGNE, FORET, PLAINE
};

enum ennemisPresents{
	ENNEMIS = -1, RAS = 0
};

enum pointsCase{
	NUL = 2, NORMAL = 4, SUPER = 6
};

enum deplacement{
	IMPOSSIBLE = 0, POSSIBLE
};

int * Api::genereTableauCarte(int taille)
{
	Carte * c = new Carte(taille);
	c->genereTableauCarte2();
	return c->getData();
}

int ** Api::cartePondereeEnnemis(int tailleCarte, int * posEnnemis)
{
	int ** res = new int *[tailleCarte];
	for(int i = 0; i < tailleCarte; i++)
	{
		res[i] = new int[tailleCarte];
		for(int j = 0; j < tailleCarte; j++)
		{
		res[i][j] = (posEnnemis[i*tailleCarte+j] == 0 ? 0 : ENNEMIS);
		}
	}
	return res;
}




int * Api::deplacementsPossiblesViking(int posUnite, int * carte, int tailleCarte, int * posEnnemis)
{
	int * resultat = new int[tailleCarte*tailleCarte];

	int x_unit = posUnite % tailleCarte;
	int y_unit = (int)(posUnite/tailleCarte);
	int ** res = cartePondereeEnnemis(tailleCarte, posEnnemis);

	res[x_unit-1][y_unit] *= POSSIBLE;
	res[x_unit][y_unit-1] *= POSSIBLE;
	res[x_unit+1][y_unit] *= POSSIBLE;
	res[x_unit][y_unit+1] *= POSSIBLE;

	for (int i = 0; i < tailleCarte; i++)
	{
		for (int j = 0; j < tailleCarte; j++)
		{
			if(carte[i*tailleCarte+j] == DESERT)
				res[i][j] += NUL;
			else if (carte[i*tailleCarte+j] == EAU)
			{
				if(i > 0 && res[i-1][j] < (SUPER-1)) res[i-1][j] += SUPER;
				if(j > 0 && res[i][j-1] < (SUPER-1)) res[i][j-1] += SUPER;
				if(i < (tailleCarte - 1) && res[i+1][j] < (SUPER-1)) res[i+1][j] += SUPER;
				if(j < (tailleCarte - 1) && res[i+1][j] < (SUPER-1)) res[i][j+1] += SUPER;
			}
			res[i][j] *= (std::abs(x_unit-i) + std::abs(y_unit-j) > 1 ? IMPOSSIBLE : POSSIBLE);
			resultat[i*tailleCarte+j] = res[i][j];
		}
		return resultat;
	}
}

int * Api::deplacementsPossiblesGaulois(int posUnite, int * carte, int tailleCarte, int * posEnnemis)
{
	int * res = new int[tailleCarte*tailleCarte];
	for(int i = 0; i < tailleCarte*tailleCarte; i++)
		res[i] = 0;

	if(posUnite % tailleCarte != 0 && carte[posUnite-1] != EAU) 
	{
		res[posUnite-1] = 1;
		if(posEnnemis[posUnite-1] == 0 && carte[posUnite-1] == PLAINE)
		{
			if((posUnite-1) % tailleCarte != 0 && carte[posUnite-2] != EAU)
				res[posUnite-2] = 1;
			if((posUnite-1) > tailleCarte && carte[posUnite-tailleCarte-1] != EAU)
				res[posUnite-tailleCarte-1] = 1;
			if((posUnite-1) < tailleCarte && carte[posUnite+tailleCarte-1] != EAU)
				res[posUnite+tailleCarte-1] = 1;
		}
	}
	
	if(posUnite % tailleCarte != (tailleCarte-1) && carte[posUnite] != EAU)
	{
		res[posUnite+1] = 1;
		if(posEnnemis[posUnite+1] == 0 && carte[posUnite+1] == PLAINE)
		{
			if((posUnite+1) % tailleCarte != (tailleCarte-1) && carte[posUnite+2] != EAU)
				res[posUnite+2] = 1;
			if((posUnite+1) > tailleCarte && carte[posUnite-tailleCarte+1] != EAU)
				res[posUnite-tailleCarte+1] = 1;
			if((posUnite+1) < tailleCarte && carte[posUnite+tailleCarte+1] != EAU)
				res[posUnite+tailleCarte+1] = 1;
		}
	}

	if(posUnite > tailleCarte)
	{
		res[posUnite-tailleCarte] = 1;
		if(posEnnemis[posUnite-tailleCarte] == 0 && carte[posUnite-tailleCarte] == PLAINE)
		{
			if((posUnite-tailleCarte) % tailleCarte != 0 && carte[posUnite+tailleCarte+1] != EAU)
				res[posUnite+2] = 1;
			if((posUnite-tailleCarte) % tailleCarte != (tailleCarte-1) && carte[posUnite+2] != EAU)
				res[posUnite+2] = 1;
			if((posUnite+1) > tailleCarte && carte[posUnite-tailleCarte+1] != EAU)
				res[posUnite-tailleCarte+1] = 1;
			if((posUnite+1) < tailleCarte && carte[posUnite+tailleCarte+1] != EAU)
				res[posUnite+tailleCarte+1] = 1;
		}


	}
	if(posUnite < tailleCarte*(tailleCarte-1))
		res[posUnite+tailleCarte] = 1;




};
int * Api::deplacementsPossiblesNain(int posUnite, int * carte, int tailleCarte, int * posEnnemis){};


void Api::combat(int pdvAtt, int pdvAttMax, int pdvDef, int pdvDefMax, int ptsAtt, int ptsDef)
{
	Combat * cbt = new Combat(pdvAtt, pdvAttMax, pdvDef, pdvDefMax, ptsAtt, ptsDef);
	cbt->combattre();
}

