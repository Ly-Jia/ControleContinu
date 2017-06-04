using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleContinu
{
    public class Service : IOrganigrammeComposant
    {
        public Service(string nom, Employé chef, IList<IOrganigrammeComposant> membres)
        {
            Nom = nom;
            Chef = chef;
            Membres = membres;
        }

        public string Nom { get; set; }
        public Employé Chef { get; set; }
        public IList<IOrganigrammeComposant> Membres { get; set; }
        public void Afficher()
        {
            Console.WriteLine("Service " + Nom + " - (" + Chef.Nom + ", " + Chef.Titre + ")");
            foreach (var employé in Membres)
            {
                employé.Afficher();
            }
        }


        public void Ajouter(IOrganigrammeComposant membre)
        {
            Membres.Add(membre);
        }

        public void Retirer(IOrganigrammeComposant membre)
        {
            Membres.Remove(membre);
        }

        public IOrganigrammeComposant ObtenirMembre(int index)
        {
            return Membres.ElementAt(index);
        }
    }
}
