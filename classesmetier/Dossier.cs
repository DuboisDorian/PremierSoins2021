using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soins2021Exception;

namespace ClassesMetier
{
    /// <summary>
    /// classe Dossier
    /// </summary>
    public class Dossier
    {
        private string nomPatient;
        private string prenomPatient;
        private DateTime dateDeNaissancePatient;
        private DateTime dateDeCreationDossier;
        internal List<Prestation> prestations;


        public string NomPatient { get => nomPatient; }
        public string PrenomPatient { get => prenomPatient; }
        public DateTime DateDeNaissancePatient { get => dateDeNaissancePatient; }
        public DateTime DateDeCreationDossier { get => dateDeCreationDossier; }


        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nomPatient">nom du patient</param>
        /// <param name="prenomPatient">prenom du patient</param>
        /// <param name="dateDeNaissance">date de naissance du patient au format JJ/MM/AAAA</param>
        public Dossier(string nomPatient, string prenomPatient, DateTime dateDeNaissance)
        {
            
                this.nomPatient = nomPatient;
                this.prenomPatient = prenomPatient;
                this.dateDeNaissancePatient = dateDeNaissance;
                this.prestations = new List<Prestation>();
                this.dateDeCreationDossier = DateTime.Now;
        }
        public Dossier(string nomPatient, string prenomPatient, DateTime dateDeNaissance, DateTime dateDeCreationDossier)
            : this(nomPatient, prenomPatient, dateDeNaissance)
        {
            try {
                this.dateDeCreationDossier = dateDeCreationDossier;
                if (this.dateDeCreationDossier > DateTime.Now)
                { throw new SoinsException("la date de création du dossier ne peut pas être supérieur à la date du jour"); }
            }
            catch (SoinsException ex) { Console.WriteLine(ex); }
        }
            
        /// <summary>
        /// constructeur surchargé.
        /// Il comprend en plus un objet de la classe Prestation à rajouter dans la 
        /// collection prestations
        /// </summary>
        /// <param name="nomPatient"></param>
        /// <param name="prenomPatient"></param>
        /// <param name="dateDeNaissance"></param>
        /// <param name="unePrestation">objet de la classe Prestation à rajouter</param>
        public Dossier(string nomPatient, string prenomPatient, DateTime dateDeNaissance, Prestation unePrestation)
            : this(nomPatient, prenomPatient, dateDeNaissance)
        {
            this.prestations.Add(unePrestation);
        }
        /// <summary>
        /// constructeur surchargé
        /// Il comprend un onbjet Collection de Prestation 
        /// Il faudra affecter cette Collection à l'objet prestations
        /// </summary>
        /// <param name="nomPatient"></param>
        /// <param name="prenomPatient"></param>
        /// <param name="dateDeNaissance"></param>
        /// <param name="desPrestations"></param>
        public Dossier(string nomPatient, string prenomPatient, DateTime dateDeNaissance, List<Prestation> desPrestations)
            : this(nomPatient, prenomPatient, dateDeNaissance)
        {
            this.prestations = desPrestations;
        }

        /// <summary>
        ///    Ajoute un objet de la classe Prestation à la collection prestations
        /// à noter qu'il faudra construire cet objet à partir des paramètres fournis
        /// </summary>
        /// <param name="unLibelle">libellé de la prestation</param>
        /// <param name="uneDate" date de la prestation></param>
        /// <param name="uneHeure">heure de la prestation</param>
        /// <param name="unIntervenant">objet de la classe Intervenant, celui qui a fait la prestation</param>
        public void AjoutePrestation(string unLibelle, DateTime uneDateHeure, Intervenant unIntervenant)
        {
            try
            {
                if (uneDateHeure <= DateTime.Now)
                {
                    this.prestations.Add(new Prestation(unLibelle, uneDateHeure, unIntervenant));
                }
                else { throw new SoinsException("la date d'ajout ne doit pas être posterieur à la date du jour");}
            }
            catch (SoinsException ex) { Console.WriteLine(ex); }
        }
            
            
            

        /// <summary>
        /// retourne le npmbre de prestations du dossier effectuées
        /// par un intervenant externe 
        /// </summary>
        /// <returns>entier représentatnt le nb de prestations externes du dossier</returns>
        public Int16 GetNbPrestationsExternes()
        {
            Int16 nb = 0;
            foreach (Prestation prestation in this.prestations)
            {
                if (prestation.Intervenant is IntervenantExterne)
                {
                    nb++;
                }
            }
            return nb;
        }

        /// <summary>
        /// Retourne le nombre de jours de soins comptabilisés pour le dossier. Il ne s'agit pas ici de déterminer
        ///  le nombre de prestations attachées à un dossier, mais le nombre de jours pour lesquels au moins 
        /// une prestation a été réalisée.
        /// On crée une collection de type LIST qui va contenir les dates de soins. On choisit LIST plutôt que Collection
        /// car LIST possède la méthode Contains qui va nous éviter d'écrire nous même la recherche de date existante dans la collection
        /// </summary>
        /// <returns>le nombre de jours où il y a eu au moins une prestation</returns>
        public int GetNbJoursSoins()
        {
            List<DateTime> lesDates = new List<DateTime>();
            foreach (Prestation unePrestation in this.prestations)
            {
                if (!lesDates.Contains(unePrestation.DateHeureSoin.Date))
                {
                    lesDates.Add(unePrestation.DateHeureSoin.Date);
                }
            }
            return lesDates.Count;
        }
        /// <summary>
        /// Retourne aussi le nombre de jours de soins comptabilisés pour le dossier. Il ne s'agit pas ici de déterminer
        ///  le nombre de prestations attachées à un dossier, mais le nombre de jours pour lesquels au moins 
        /// une prestation a été réalisée.
        /// 
        /// On va utiliser un delegate qui va se charger de retourner si deux dates de prestations sont égales ou non
        /// </summary>
        /// <returns>le nombre de jours où il y a eu au moins une prestation</returns>
        public int GetNbJoursSoinsV2()
        {

            if (this.prestations.Count == 0)
            {       // pas de prestation
                return 0;
            }
            else
            {
                // il faut trier les prestations par date de soin
                this.prestations.Sort(delegate (Prestation prestation1, Prestation prestation2)
                {
                    return prestation1.DateHeureSoin.Date.CompareTo(prestation2.DateHeureSoin.Date);

                });
                Prestation oldPrestation = this.prestations[0];
                int nb = 1;
                for (int i = 0; i < this.prestations.Count; i++)
                {
                    if (this.prestations[i].compareTo(oldPrestation) != 0)
                    {
                        nb++;
                        oldPrestation = this.prestations[i];

                    }
                }
                return nb;
            }
        }
        /// <summary>
        /// Retourne aussi le nombre de jours de soins comptabilisés pour le dossier. Il ne s'agit pas ici de déterminer
        ///  le nombre de prestations attachées à un dossier, mais le nombre de jours pour lesquels au moins 
        /// une prestation a été réalisée.
        /// 
        /// On va utiliser le langage LinQ qui va se charger de comptabiliser le nombres de dates de soins différentes
        /// parmi toutes les prestations.
        /// LinQ est une forme de SQL appliquée au objets. 
        /// </summary>
        /// <returns>le nombre de jours où il y a eu au moins une prestation</returns>
        public int GetNbJoursSoinsV3()
        {
            // return mesPrestations.Select(x => DateTime.Parse(x.GetDateSoin())).Distinct().Count();
            return this.prestations.Select(x => x.DateHeureSoin.Date).Distinct().Count();
        }

        public override string ToString()
        {

            string s = " -----Début dossier--------------";
            s += "\nNom: " + this.nomPatient + " Prenom: " + this.prenomPatient + " Date de naissance: " + this.dateDeNaissancePatient.ToShortDateString();
            foreach (Prestation unePrestation in prestations)
            {
                s += "\n" + unePrestation;
            }
            s += "\n -----Fin dossier--------------";

            return s;
        }


    }


}