using System;
namespace PrOOjet
{
    public interface IFabriqueCase
    {
        ICaseDesert CaseDesert { get; }
        ICaseEau CaseEau { get; }
        ICaseForet CaseForet { get; }
        ICaseMontagne CaseMontagne { get; }
        ICasePlaine CasePlaine { get; }

        ICase creeCase(string cle);
    }
}
