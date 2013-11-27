#ifndef API_H
#define API_H

#define CARTE_DLL_EXPORTS

#ifdef CARTE_DLL_EXPORTS
	#define CARTE_DLL __declspec(dllexport)
	#define EXTERNC extern "C"
#else
	#define CARTE_DLL __declspec(dllimport)
	#define EXTERNC
#endif

EXTERNC {
	CARTE_DLL int * genereCarte(int taille);
}

#endif