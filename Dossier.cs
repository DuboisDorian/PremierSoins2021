using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesMetier;
using MaBoiteAOutils;


namespace MaBoiteAOutils
{
    public class Dossier
    {
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private List<Prestations> listePrestations;

        //Constructeur
        public Dossier(string nom, string prenom, DateTime dateNaissance)
        {
            this.nom = Nom;
            this.prenom = Prenom;
            this.dateNaissance = DateNaissance;
        }

        //Constructeur ListePrestations
        public Dossier(string nom, string prenom, DateTime dateNaissance, List<Prestations> listePrestations)
        {
            this.nom = Nom;
            this.prenom = Prenom;
            this.dateNaissance = DateNaissance;
            this.listePrestations = listePrestations;
        }

        //Property
        public string Nom { get => nom; }
        public string Prenom { get => prenom; }
        public DateTime DateNaissance { get => dateNaissance; }

        //Méthodes
        //Ajoutes une prestations au dossier
        public void ajoutePrestations(Prestations nouvellePresta)
        {
            listePrestations.Add(nouvellePresta);

        }
        //ajoute d'une méthode pour afficher le nombre de jours de prestation
        public int getNbJoursSoins(Dossier utilisee)
        {
            int nbdate = this.listePrestations.Count;
            for (int i = 0; i < this.listePrestations.Count;i++)
            {
                for(int a = i+1; a<this.listePrestations.Count;a++)
                {
                    if(Prestations.ComparteTo(utilisee.listePrestations[i], utilisee.listePrestations[a]) == 0)
                    {
                        nbdate --;
                    }
                }
            }
            return nbdate;
        }
       public int GetNbPrestationExternes(List<Prestations> ext)
        {
            int i = 0;
            foreach(Prestations prestation in listePrestations)
            {
                if(prestation.IntervenantExterne is IntervenantExterne)
                {
                    i++;
                }
            }
            return i;
        }
        //création de la méthode to string
        public override string ToString()
        {
            string s = "-----Debut dossier-------------";
            s += "\nNom: " + this.nom + "Prenom: " + this.prenom + " Date de naissance: " + this.dateNaissance.Date;
            foreach(Prestations prestation in listePrestations)
            {
                s += "\n" + prestation;
            }
            s += "\n-----Fin dossier-----------------";
            return s;
        }
    }
    
}
