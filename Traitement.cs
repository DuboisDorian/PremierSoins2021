using ClassesMetier;
using MaBoiteAOutils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestations_soins
{
    public static class Traitement
    {
        /// <summary>
        /// Méthode qui va nous servir a afficher les élements d'un dossier dans la methode main
        /// </summary>
        public static void TesteDossier(Dossier dossier)
        {
            Console.WriteLine(dossier.ToString()); 

        }
    }
    
}
