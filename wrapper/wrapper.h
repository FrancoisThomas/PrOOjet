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

		int ** deListAMatrice(List<int>^ listCarte, int taille){
			int ** matrice = new int *[taille];
			for(int i = 0; i < taille; i++)
			{
				matrice[i] = new int[taille];
				for (int j = 0; j < taille; j++)
					matrice[i][j] = listCarte[i*taille+j];
			}
			return matrice;
		}

		int ** deDictionaryAMatrice(Dictionary<int, int>^ dico, int taille){
			int ** matrice = new int *[taille];
			for(int i = 0; i < taille; i++)
			{
				matrice[i] = new int[taille];
				for (int j = 0; j < taille; j++)
					dico->TryGetValue(i*taille+j, matrice[i][j]);
			}
			return matrice;
		}


		List<int>^ suggestionDeplacementViking(int posUnite, List<int>^ listCarte, int tailleCarte, Dictionary<int, int>^ ennemis){
			
			// On traite d'abord les parametres afin de les transmettre au bon format a l'api
			
			// Traitement de listCarte en carte
			int ** carte = deListAMatrice(listCarte, tailleCarte);

			// Traitement de enemmis en posEnnemis
			int ** posEnnemis = deDictionaryAMatrice(ennemis, tailleCarte);
						
			int * list = api->deplacementsPossiblesViking(posUnite, carte, tailleCarte, posEnnemis);
			List<int>^ suggestions = gcnew List<int>();

			for (int i = 0; i < tailleCarte*tailleCarte; i++)
				suggestions->Add(list[i]);

			return suggestions;
		}


		List<int>^ suggestionDeplacementGaulois(int posUnite, List<int>^ listCarte, int tailleCarte, Dictionary<int, int>^ ennemis){
			
			// On traite d'abord les parametres afin de les transmettre au bon format a l'api
			
			// Traitement de listCarte en carte
			int ** carte = deListAMatrice(listCarte, tailleCarte);

			// Traitement de enemmis en posEnnemis
			int ** posEnnemis = deDictionaryAMatrice(ennemis, tailleCarte);
						
			int * list = api->deplacementsPossiblesGaulois(posUnite, carte, tailleCarte, posEnnemis);
			List<int>^ suggestions = gcnew List<int>();

			for (int i = 0; i < tailleCarte*tailleCarte; i++)
				suggestions->Add(list[i]);

			return suggestions;
		}


		List<int>^ suggestionDeplacementNain(int posUnite, List<int>^ listCarte, int tailleCarte, Dictionary<int, int>^ ennemis){
			
			// On traite d'abord les parametres afin de les transmettre au bon format a l'api
			
			// Traitement de listCarte en carte
			int ** carte = deListAMatrice(listCarte, tailleCarte);

			// Traitement de enemmis en posEnnemis
			int ** posEnnemis = deDictionaryAMatrice(ennemis, tailleCarte);
						
			int * list = api->deplacementsPossiblesNain(posUnite, carte, tailleCarte, posEnnemis);
			List<int>^ suggestions = gcnew List<int>();

			for (int i = 0; i < tailleCarte*tailleCarte; i++)
				suggestions->Add(list[i]);

			return suggestions;
		}

		int pointsTourViking(List<int>^ listCarte, int tailleCarte, Dictionary<int, int>^ unites)
		{
			// On traite d'abord les parametres afin de les transmettre au bon format a l'api
			
			// Traitement de listCarte en carte
			int ** carte = deListAMatrice(listCarte, tailleCarte);

			// Traitement de unites en posEnnemis
			int ** posUnites = deDictionaryAMatrice(unites, tailleCarte);

			return api->calculePointsTourViking(carte, tailleCarte, posUnites);
		}

		int pointsTourGaulois(List<int>^ listCarte, int tailleCarte, Dictionary<int, int>^ unites)
		{
			// On traite d'abord les parametres afin de les transmettre au bon format a l'api
			
			// Traitement de listCarte en carte
			int ** carte = deListAMatrice(listCarte, tailleCarte);

			// Traitement de unites en posEnnemis
			int ** posUnites = deDictionaryAMatrice(unites, tailleCarte);

			return api->calculePointsTourGaulois(carte, tailleCarte, posUnites);
		}


		int pointsTourNain(List<int>^ listCarte, int tailleCarte, Dictionary<int, int>^ unites)
		{
			// On traite d'abord les parametres afin de les transmettre au bon format a l'api
			
			// Traitement de listCarte en carte
			int ** carte = deListAMatrice(listCarte, tailleCarte);

			// Traitement de unites en posEnnemis
			int ** posUnites = deDictionaryAMatrice(unites, tailleCarte);

			return api->calculePointsTourNain(carte, tailleCarte, posUnites);
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