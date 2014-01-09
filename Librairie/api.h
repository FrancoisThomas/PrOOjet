#ifndef API_H
#define API_H

#include "carte.h"
#include "combat.h"
#include <list>


#ifdef WANTDLLEXP
#define DLL _declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif

class DLL Api{
	public:

	Api() {}
	~Api() {}
	
	int * genereTableauCarte(int taille);

	int ** cartePondereeEnnemis(int tailleCarte, int ** posEnnemis);

	int ** cartePondereePointsViking(int tailleCarte, int ** carte);
	int * deplacementsPossiblesViking(int posUnite, int ** carte, int tailleCarte, int ** posEnnemis);
	
	int ** cartePondereePointsGaulois(int tailleCarte, int ** carte);
	int * deplacementsPossiblesGaulois(int posUnite, int ** carte, int tailleCarte, int ** posEnnemis);
	
	int ** cartePondereePointsNain(int tailleCarte, int ** carte);
	int * deplacementsPossiblesNain(int posUnite, int ** carte, int tailleCarte, int ** posEnnemis);

	int pdv_attaquant_fin;
	int pdv_defenseur_fin;
	void combat(int pdvAtt, int pdvAttMax, int pdvDef, int pdvDefMax, int ptsAtt, int ptsDef);
	


};

EXTERNC DLL Api* Api_new();
EXTERNC DLL void Api_delete(Api* api);

#endif