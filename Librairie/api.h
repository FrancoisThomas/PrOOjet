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

enum ennemiPresent{
	ENNEMI = -1, RAS = 0
};

enum pointsCase{
	DEPLACEMENT_IMPOSSIBLE = 0, NUL = 2, NORMAL = 4, SUPER = 6
};

class DLL Api{
	public:

	Api() {}
	~Api() {}
	
	int * genereTableauCarte(int taille);

	int pointsCase(int pointsCarte, int nombreEnnemis);

	int ** cartePondereePointsViking(int tailleCarte, int ** carte);
	int * deplacementsPossiblesViking(int posUnite, int ** carte, int tailleCarte, int ** posEnnemis);
	
	int * deplacementsPossiblesGaulois(int posUnite, int ** carte, int tailleCarte, int ** posEnnemis);
	
	int * deplacementsPossiblesNain(int posUnite, int ** carte, int tailleCarte, int ** posEnnemis);

	int calculePointsTourViking(int ** carte, int tailleCarte, int ** posUnites);
	int calculePointsTourGaulois(int ** carte, int tailleCarte, int ** posUnites);
	int calculePointsTourNain(int ** carte, int tailleCarte, int ** posUnites);



	int pdv_attaquant_fin;
	int pdv_defenseur_fin;
	void combat(int pdvAtt, int pdvAttMax, int pdvDef, int pdvDefMax, int ptsAtt, int ptsDef);
	


};

EXTERNC DLL Api* Api_new();
EXTERNC DLL void Api_delete(Api* api);

#endif