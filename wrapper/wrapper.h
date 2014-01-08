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
		WrapperCarte(){api = Api_new();}
		~WrapperCarte(){Api_delete(api);}

		List<int>^ genereCarte(int taille){ 
			int* list =	api->genereTableauCarte(taille);
			List<int>^ carte = gcnew List<int>();

			for (int i = 0; i < taille*taille; i++)
				carte->Add(list[i]);

			return carte;
		}
	};


	public ref class WrapperCombat
	{
	private:
		Api* api;
		int pdv_attaquant_fin;
		int pdv_defenseur_fin;

	public:
		WrapperCombat(int pdv_att, int pdv_att_max, int pdv_def, int pdv_def_max, int pts_att, int pts_def){
				api = Api_new();
		}
		~WrapperCombat(){Api_delete(api);}

		void combattre(int pdv_att, int pdv_att_max, int pdv_def, int pdv_def_max, int pts_att, int pts_def){
			api->combattre(pdv_att, pdv_att_max, pdv_def, pdv_def_max, pts_att, pts_def);
			pdv_attaquant_fin = api->pdv_attaquant_fin;
			pdv_defenseur_fin = api->pdv_defenseur_fin;
		}

		int getVieAttaquant(){return pdv_attaquant_fin;}
		int getVieDefenseur(){return pdv_defenseur_fin;}

	};
}

#endif