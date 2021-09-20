using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaBoiteAOutils;
using ClassesMetier;
using Prestations_soins;

namespace soins
{
    class Program
    {
        static void Main()
        {
            //Traitement.TesteDossier();
            Console.WriteLine("Nb Prestations intervenant : " + Traitement.GetNbPrestationsI());
            Console.ReadLine();
        }
    }
}
