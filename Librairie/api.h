#ifndef API_H
#define API_H


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
	int computeFoo();
	int * genereTableauCarte(int taille);

};

EXTERNC DLL Api* Api_new();
EXTERNC DLL void Api_delete(Api* api);

#endif