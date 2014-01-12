#ifndef CARTE_H
#define CARTE_H

#include <stddef.h>
#include <stdlib.h>		//srand/rand
#include <time.h>		//time
#include <algorithm>	//max   

enum Cases{
	DESERT = 0, EAU, MONTAGNE, FORET, PLAINE
};


class Carte 
{
private:
	int taille;
	int * mat;
	bool * estPasse;

public:
	Carte(int taille);
	~Carte();

	int * getData();
	void genereTableauCarte();
	void genereTableauCarte2();

	bool testCase(int pos);
	bool carteValide();
};

#endif