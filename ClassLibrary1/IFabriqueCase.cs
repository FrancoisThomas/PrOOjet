using System;
namespace PrOOjet
{
    interface IFabriqueCase
    {
        ICase creeCase(string cle);
        ICase creeCaseDesert();
        ICase creeCaseEau();
        ICase creeCaseForet();
        ICase creeCaseMontagne();
        ICase creeCasePlaine();
    }
}
