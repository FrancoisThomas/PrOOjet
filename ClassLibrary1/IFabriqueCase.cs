using System;
namespace PrOOjet
{
    interface IFabriqueCase
    {
        ICase creeCase(string cle);
        ICaseDesert creeCaseDesert();
        ICaseEau creeCaseEau();
        ICaseForet creeCaseForet();
        ICaseMontagne creeCaseMontagne();
        ICasePlaine creeCasePlaine();
    }
}
