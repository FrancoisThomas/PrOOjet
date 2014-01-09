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

		List<int>^ suggestionDeplacementNain(int posUnite, int ** carte, int tailleCarte, int ** posEnnemis){
			int * list = api->deplacementsPossiblesNain(posUnite, carte, tailleCarte, posEnnemis);
			List<int>^ suggestions = gcnew List<int>();

			for (int i = 0; i < tailleCarte*tailleCarte; i++)
				suggestions->Add(list[i]);

			return suggestions;
		}

		List<int>^ suggestionDeplacementViking(int posUnite, int ** carte, int tailleCarte, int ** posEnnemis){
			int * list = api->deplacementsPossiblesViking(posUnite, carte, tailleCarte, posEnnemis);
			List<int>^ suggestions = gcnew List<int>();

			for (int i = 0; i < tailleCarte*tailleCarte; i++)
				suggestions->Add(list[i]);

			return suggestions;
		}

		List<int>^ suggestionDeplacementGaulois(int posUnite, int ** carte, int tailleCarte, int ** posEnnemis){
			int * list = api->deplacementsPossiblesGaulois(posUnite, carte, tailleCarte, posEnnemis);
			List<int>^ suggestions = gcnew List<int>();

			for (int i = 0; i < tailleCarte*tailleCarte; i++)
				suggestions->Add(list[i]);

			return suggestions;
		}
	};


	
	public ref class WrapperCombat
	{
	private:
		Api* api;
		int pdvAttaquantFin;
		int pdvDefenseurFin;

	public:
		WrapperCombat(){
				api = Api_new();
		}
		~WrapperCombat(){Api_delete(api);}

		void combattre(int pdvAtt, int pdvAttMax, int pdvDef, int pdvDefMax, int ptsAtt, int ptsDef){
			api->combat(pdvAtt, pdvAttMax, pdvDef, pdvDefMax, ptsAtt, ptsDef);
			pdvAttaquantFin = api->pdv_attaquant_fin;
			pdvDefenseurFin = api->pdv_defenseur_fin;
		}

		int getVieAttaquant(){return pdvAttaquantFin;}
		int getVieDefenseur(){return pdvDefenseurFin;}

	};
}

#endif