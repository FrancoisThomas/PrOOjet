// wrapper.h

#pragma once

#include "api.h"

using namespace System::Collections::Generic;

namespace wrapper {

	public ref class WrapperCarte
	{
	
	public:
		static List<int>^ genereCarte(int taille){ 
			int* list =	genereTableauCarte(taille);
			List<int>^ carte = gcnew List<int>();

			for (int i = 0; i < taille*taille; i++)
			{
				carte->Add(list[i]);
			}

			return carte;
		}
	};
}
