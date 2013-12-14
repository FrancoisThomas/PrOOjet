using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public interface ICarte
    {
        int getTaille();

        ICase getCase(int colonne, int ligne); 
    }

}
