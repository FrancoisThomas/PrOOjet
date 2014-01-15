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

/// <summary>
/// Enumeration permettant de ponderer la valeur d'une case selon la presence d'un ennemi.
/// ENNEMI : Un ennemi est present.
/// RAS : Il n'y a pas d'ennemi sur la case.
/// </summary>
enum ennemiPresent{
	ENNEMI = -1, RAS = 0
};

/// <summary>
/// Enumeration permettant de donner un score a une case selon son gain en points.
/// DEPLACEMENT_IMPOSSIBLE : On ne peut pas acceder a la case.
/// NUL : La case ne rapporte pas de point.
/// NORMAL : La case rapporte un seul point.
/// SUPER : La case rapporte deux points.
/// </summary>
enum pointsCase{
	DEPLACEMENT_IMPOSSIBLE = 0, NUL = 2, NORMAL = 4, SUPER = 6
};

/// <summary>
/// L'api du programme.
/// </summary>
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