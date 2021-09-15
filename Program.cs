using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaBoiteAOutils;
using ClassesMetier;

namespace soins
{
    class Program
    {
        static void Main()
        {
            //Dossier
            var dateRJ = new DateTime(1980, 12, 3);
            List<Prestations> listePrestation = new List<Prestations>();
            Dossier RJ = new Dossier("Robert", "Jean", dateRJ, listePrestation);
            

            //1 prestation
            Intervenant DJ = new Intervenant("Dupont", "Jean");
            var dateP3=new DateTime(2015, 9, 10, 12, 0, 0);
            Prestations P3 = new Prestations("P3", dateP3,DJ);
            RJ.ajoutePrestations(P3);

            //2 prestation
            IntervenantExterne DA = new IntervenantExterne("Durand", "Annie", "Cardiologue", "Marseille", "0202020202");
            var dateP1 = new DateTime(2015, 9, 1, 12, 0, 0);
            Prestations P1 = new Prestations("P1", dateP1, DA);
            RJ.ajoutePrestations(P1);

            //3 prestation
            IntervenantExterne SO = new IntervenantExterne("Sainz", "Olivier", "Radiologue","Toulon","0303030303");
            var dateP2 = new DateTime(2015, 9, 8, 12, 0, 0);
            Prestations P2 = new Prestations("P2", dateP2, SO);
            RJ.ajoutePrestations(P2);

            //4 prestation
            Intervenant MJ = new Intervenant("Maurin", "Joëlle");
            var dateP4 = new DateTime(2015, 9, 20, 12, 0, 0);
            Prestations P4 = new Prestations("P4", dateP4, MJ);
            RJ.ajoutePrestations(P4);

            //5 prestation
            Intervenant BM = new Intervenant("Blanchard", "Michel");
            var dateP6 = new DateTime(2015, 9, 8, 9, 0, 0);
            Prestations P6 = new Prestations("P6", dateP6, BM);
            RJ.ajoutePrestations(P6);

            //6 prestation
            Intervenant TH = new Intervenant("Tournier", "Hélène");
            var dateP5 = new DateTime(2015, 9, 10, 6, 0, 0);
            Prestations P5 = new Prestations("P5", dateP5, TH);
            RJ.ajoutePrestations(P5);
            
            //formatage du texte
            Console.WriteLine("-----Début dossier----------------");
            Console.WriteLine("Nom: "+ RJ.Nom +" Prenom: "+RJ.Prenom +" Date de naissance: "+ RJ.DateNaissance.ToString("d") );
            Console.WriteLine("      Libelle" + P3.Libelle+" - "+ P3.DateHeureSoin +" -  Intervenant: "+DJ.Nom+ " - "+DJ.Prenom);
            Console.WriteLine("      Libelle" + P1.Libelle + " - " + P1.DateHeureSoin + " -  Intervenant: " + DA.Nom + " - " + DA.Prenom +" -  Spécialité: "+DA.Specialite +" " +DA.Adresse);
            Console.WriteLine("      Libelle" + P2.Libelle + " - " + P2.DateHeureSoin + " -  Intervenant: " + SO.Nom + " - " + SO.Prenom + " -  Spécialité: " + SO.Specialite + " " + SO.Adresse);
            Console.WriteLine("      Libelle" + P4.Libelle + " - " + P4.DateHeureSoin + " -  Intervenant: " + MJ.Nom + " - " + MJ.Prenom);
            Console.WriteLine("      Libelle" + P6.Libelle + " - " + P6.DateHeureSoin + " -  Intervenant: " + BM.Nom + " - " + BM.Prenom);
            Console.WriteLine("      Libelle" + P5.Libelle + " - " + P5.DateHeureSoin + " -  Intervenant: " + TH.Nom + " - " + TH.Prenom);
            Console.WriteLine("-----Fin dossier------------------");
            Console.WriteLine("Nombre de jours de Soins V1 : " + RJ.getNbJoursSoins(RJ));
            Console.WriteLine("Nombre de soins externes: "+ RJ.GetNbPrestationExternes(listePrestation));
            Console.ReadLine();
        }
    }
}
