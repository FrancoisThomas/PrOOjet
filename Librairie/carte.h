#ifndef CARTE_H
#define CARTE_H

#include <stddef.h>
#include <stdlib.h>		// pour utiliser srand/rand
#include <time.h>		// pour utiliser time
#include <algorithm>	// pour utiliser max   

/// <summary>
/// Enumeration permettant de convertir un type de case en int.
/// Les noms sont suffisament explicites
/// </summary>
enum Cases{
	DESERT = 0, EAU, MONTAGNE, FORET, PLAINE
};

/// <summary>
/// Classe permettant de representer une carte, et notamment de la generer.
/// </summary>
class Carte 
{
private:

	int taille; // La taille de la carte (largeur ou hauteur, puisque la carte est carree)
	int * mat;	// Matrice a une dimension representant la carte
	void validationCarte();
	void echangeCase(int pos);	
	
	bool * estPasse; // Tableau de booleen permettant de ne pas teste deux fois la meme case lors d'un parcours aleatoire.

public:
	Carte(int taille);
	~Carte();

	int * getData();
	void genereTableauCarte();
	void genereTableauCarte2();

	bool testCase(int pos);
};

#endif