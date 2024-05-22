using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_eneo
{
    public class Facture
    {
        private Client Client { get; set; }
        private double MontantTotal { get; set; }
        private String DateEmission { get; set; }
        public double GetMontantTotal()
        {
            return MontantTotal;
        }
        public Facture(Client client ,double montantTotal)
        {
            Client = client;
            MontantTotal = montantTotal;
            DateEmission = DateTime.Now.ToString(" dd-MM-yyyy");
        }
        public string GenererContenu()
        {
            return "Facture d'electricite pour " + Client.GetPrenom() + " " + Client.GetNom() + "(ID: " + Client.GetIdentifiant() + ") emise le " + DateEmission + " :\n " + "Ville: " + Client.GetVille() + "\n" + "Quartier : " + Client.GetQuartier() + "\n" + "Consommation: " + Client.GetConsommation() + " kwh\n" + "Montant total:" + MontantTotal + "FCFA \n";

        }
    }
}
