// wrapper.h

#pragma once

#include "carte.h"
#pragma comment(lib, "carte.lib")

using namespace System;

namespace wrapper {

	public ref class WrapperCarte
	{
	private:
		Carte * carte;

	public:
		WrapperCarte(int taille){carte = new Carte(taille);}
		~WrapperCarte(){}

		int * getData(){ return carte->getData(); }
		void genereCarte(){ carte->genereCarte(); }
	};
}
