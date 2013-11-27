#ifndef API_H
#define API_H


#ifdef CARTE_DLL_EXPORTS
	#define CARTE_DLL __declspec(dllexport)
#else
	#define CARTE_DLL __declspec(dllimport)	
#endif

#define EXTERNC extern "C"

EXTERNC {
	CARTE_DLL int * genereTableauCarte(int taille);
}

#endif