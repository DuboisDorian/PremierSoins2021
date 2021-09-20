using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesMetier;
using MaBoiteAOutils;
using Prestations_soins;

namespace Prestations_soins
{
    static class Traitement
    {
        public static void TesteDossier()
        {
            Intervenant DP = new Intervenant("Dupont", "Jean");
            IntervenantExterne DA = new IntervenantExterne("Durand", "Annie", "Cardiologue", "Marseille", "0202020202");
            IntervenantExterne SO = new IntervenantExterne("Sainz", "Olivier", "Radiologue", "Toulon", "0303030303");
            Intervenant MJ = new Intervenant("Maurin", "Joëlle");
            Intervenant BM = new Intervenant("Blanchard", "Michel");
            Intervenant TH = new Intervenant("Tournier", "Hémène");
            List<Prestations> prestations = new List<Prestations>();

            Prestations p3 = new Prestations("P3", Convert.ToDateTime("10/13/2015 12:00:00"), DP);
            prestations.Add(p3);
            Prestations p1 = new Prestations("P1", Convert.ToDateTime("01/09/2015 12:00:00"), DA);
            prestations.Add(p1);
            Prestations p2 = new Prestations("P2", Convert.ToDateTime("08/09/2015 12:00:00"), SO);
            prestations.Add(p2);
            Prestations p4 = new Prestations("P4", Convert.ToDateTime("20/09/2015 12:00:00"), MJ);
            prestations.Add(p4);
            Prestations p6 = new Prestations("P6", Convert.ToDateTime("08/09/2015 09:00:00"), BM);
            prestations.Add(p6);
            Prestations p5 = new Prestations("P5", Convert.ToDateTime("10/09/2015 06:00:00"), TH);
            prestations.Add(p5);


            Dossier dossier = new Dossier("Robert", "Jean", Convert.ToDateTime("03/12/1980").Date, prestations);
        }
        public static int GetNbPrestationsI(List<Prestations> ext)
        {
            int i = 0;
            foreach (Prestations prestation in ext)
            {
                if (prestation.Intervenant is Intervenant)
                {
                    i++;
                }
            }
            return i;
        }
        public static int GetNbPrestationsIE(List<Prestations> ext)
        {
            int i = 0;
            foreach (Prestations prestation in ext)
            {
                if (prestation.IntervenantExterne is IntervenantExterne)
                {
                    i++;
                }
            }
            return i;
        }
    }
}
