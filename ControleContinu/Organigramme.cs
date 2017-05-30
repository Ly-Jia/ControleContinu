using System;

namespace ControleContinu
{
    public class Organigramme
    {
        public Organigramme(string pdg, Service rh, Service it, Service compta)
        {
            PDG = pdg;
            RH = rh;
            IT = it;
            Comptabilité = compta;
        }

        // Nom du PDG
        public string PDG { get; private set; }

        public Service RH { get; private set; }

        public Service IT { get; private set; }

        public Service Comptabilité { get; private set; }

        //@TODO Question 1 : Quels sont les problèmes de conception dans cette fonction ?
        //@TODO Question 2 : Quel principe SOLID cette classe ne respecte-elle pas ?
        public void Afficher()
        {
            Console.WriteLine("PDG : " + PDG);
            Console.WriteLine("Service "+ RH.Nom + " - ("+ RH.Chef.Nom + ", " + RH.Chef.Titre +")");
            foreach (var employé in RH.Membres)
            {
                Console.WriteLine(" * " + employé.Nom + ", " + employé.Titre);
            }
            Console.WriteLine("Service " + IT.Nom + " - (" + IT.Chef.Nom + ", " + IT.Chef.Titre + ")");
            foreach (var employé in IT.Membres)
            {
                Console.WriteLine(" * " + employé.Nom + ", " + employé.Titre);
            }
            Console.WriteLine("Service " + Comptabilité.Nom + " - (" + Comptabilité.Chef.Nom + ", " + Comptabilité.Chef.Titre + ")");
            foreach (var employé in Comptabilité.Membres)
            {
                Console.WriteLine(" * " + employé.Nom + ", " + employé.Titre);
            }
        }
    }
}
