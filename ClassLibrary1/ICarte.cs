using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public interface ICarte
    {
        int Taille { get; }
        List<ICase> Cases { get; }

        ICase getCase(int colonne, int ligne); 
    }

}
