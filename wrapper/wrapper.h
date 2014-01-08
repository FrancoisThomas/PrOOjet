#ifndef __WRAPPER__
#define __WRAPPER__

#include "../Librairie/api.h"

using namespace System::Collections::Generic;

namespace wrapper 
{

	public ref class WrapperCarte
	{
	private:
		Api* api;
	public:
		WrapperCarte(){ api = Api_new();}
		~WrapperCarte(){Api_delete(api);}

		List<int>^ genereCarte(int taille){ 
			int* list =	api->genereTableauCarte(taille);
			List<int>^ carte = gcnew List<int>();

			for (int i = 0; i < taille*taille; i++)
				carte->Add(list[i]);

			return carte;
		}
	};
}

#endif