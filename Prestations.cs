using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesMetier;
using soins;


namespace MaBoiteAOutils
{
   public class Prestations
    {
        private string libelle;
        private DateTime dateHeureSoin;
        private Intervenant intervenant;
        private IntervenantExterne intervenantExterne;

        //Constructeur
        public Prestations(string libelle, DateTime dateHeureSoin,Intervenant intervenant)
        {
            this.libelle = libelle;
            this.dateHeureSoin = dateHeureSoin;
            this.intervenant = intervenant;
        }

        public Prestations(string libelle, DateTime dateHeureSoin, IntervenantExterne intervenantExterne)
        {
            this.libelle = libelle;
            this.dateHeureSoin = dateHeureSoin;
            this.intervenantExterne = intervenantExterne;
        }

        

        //Property
        public string Libelle { get => libelle;}
        public DateTime DateHeureSoin { get => dateHeureSoin;}
        public Intervenant Intervenant { get => intervenant; }
        public IntervenantExterne IntervenantExterne { get => intervenantExterne;}

        //Méthodes
        //Renvoi la date la plus vielle entre les 2 prestations
        public static int ComparteTo(Prestations Comparer,Prestations ComparerA )
        {
            return Comparer.DateHeureSoin.Date.CompareTo(ComparerA.DateHeureSoin.Date);
        }
        //création de la méthode to string
        public override string ToString()
        {
            
            return "\tLibelle: " + this.libelle + " - " + this.dateHeureSoin + " - Intervenant : "+intervenant+intervenantExterne; 
        }
    }
}
