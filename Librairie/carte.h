#ifndef CARTE_H
#define CARTE_H

#include <stddef.h>

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
};

#endif