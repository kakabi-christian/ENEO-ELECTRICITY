using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_eneo
{
    public class Client
    {
        private string Nom;
        private string Prenom;
        private string Ville;

        private string Quartier{ get; set; }
        private  string Identifiant{ get; set; }
        private int Consommation{ get; set; }
        public string GetNom()
        {
            return Nom;
        }
        public String GetPrenom()
        {
            return Prenom;
        }
        public String GetVille()
        {
            return Ville;
        }
        public string GetIdentifiant()
        {
            return Identifiant;
        }
        public string GetQuartier()
        {
            return Identifiant;
        }
        public int GetConsommation()
        {
            return Consommation;
        }
  

        public  Client(string prenom, string ville, string quartier, string identifaint, int consommation, string nom)
        {
            Nom = nom;
            Prenom = prenom;
            Ville = ville;
            Quartier = quartier;
            Identifiant = identifaint;
            Consommation = consommation;

        }
    }
}
