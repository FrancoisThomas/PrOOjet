#ifndef CARTE_H
#define CARTE_H

#include <stddef.h>
#include <stdlib.h>		//srand/rand
#include <time.h>		//time
#include <algorithm>	//max   


class Carte 
{
private:
	int taille;
	int* mat;

public:
	Carte(int taille);
	~Carte();

	int * getData();
	void genereTableauCarte();
	void genereTableauCarte2();
};

#endif