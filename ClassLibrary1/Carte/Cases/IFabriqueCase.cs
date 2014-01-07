using System;
namespace PrOOjet
{
	/// <summary>
	/// Interface de la fabrique de <c>ICase</c>
	/// </summary>
    public interface IFabriqueCase
    {
        ICaseDesert CaseDesert { get; }
        ICaseEau CaseEau { get; }
        ICaseForet CaseForet { get; }
        ICaseMontagne CaseMontagne { get; }
        ICasePlaine CasePlaine { get; }

		/// <summary>
		/// Fournit une case.
		/// </summary>
		/// <param name="cle"> Indique le type de case à fournir. </param>
		/// <returns> La case correspondant à la clé. </returns>
		/// <exception cref="ArgumentException"> Levée si la clé n'est pas valide. </exception>
        ICase creeCase(string cle);
    }
}
