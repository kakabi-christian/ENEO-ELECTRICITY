using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_eneo
{
    class CalculateurFacture
    {
        public double CalculerFactureBT(int consommation)
        {
            double total = 0;
            if(consommation<=110)
            {
                total = consommation * 50;

            }
            else if(consommation<=400)
            {
                total = (110 * 50) + ((consommation - 110) * 79);
            }
            else if(consommation<=800)
            {
                total = (100 * 50) + (290 * 79) + (400 * 94) + ((consommation - 800) + 99);
            }
            return total;
        }

        public double CalculerFactureMT(int consommation)
        {
            const double primefixe = 3700;
            const double tarifparkwh = 150;
            return primefixe + (tarifparkwh * consommation);
        }
    }
}
