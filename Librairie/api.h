#ifndef API_H
#define API_H

#include "carte.h"
#include "combat.h"


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

	void combattre(int pdv_att, int pdv_att_max, int pdv_def, int pdv_def_max, int pts_att, int pts_def);
	int pdv_attaquant_fin;
	int pdv_defenseur_fin;


};

EXTERNC DLL Api* Api_new();
EXTERNC DLL void Api_delete(Api* api);

#endif