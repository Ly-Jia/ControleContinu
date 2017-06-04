using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleContinu
{
    public class Organigramme : IOrganigrammeComposant
    {
        public Organigramme(string pdg, IList<IOrganigrammeComposant> composants)
        {
            PDG = pdg;
            Composants = composants;
        }

        // Nom du PDG
        public string PDG { get; private set; }

        public IList<IOrganigrammeComposant> Composants { get; private set; }
        
        //@TODO Question 1 : Quels sont les problèmes de conception dans cette fonction ?
        // Répétitions de code
        // La classe organigramme accède directement aux propriétés de Service et Employé
        //@TODO Question 2 : Quel principe SOLID cette classe ne respecte-elle pas ?
        // Dependency Principle : Organigramme dépend fortement de Service et Employé (classes concrètes)
        // Autre réponse pouvant être acceptée (mais ça reste limite), SRP (Single Responsibility Principle) : 
        // Une classe ne doit avoir qu'une seule responsabilité, la responsabilité d'Organigramme
        // est d'afficher l'organigramme et non d'accéder directement aux propriétés de Service et Employé
        public void Afficher()
        {
            Console.WriteLine("PDG : " + PDG);
            foreach (var composant in Composants)
            {
                composant.Afficher();
            }
        }

        public void Ajouter(IOrganigrammeComposant composant)
        {
            Composants.Add(composant);
        }

        public void Retirer(IOrganigrammeComposant composant)
        {
            Composants.Remove(composant);
        }

        public IOrganigrammeComposant ObtenirComposant(int index)
        {
            return Composants.ElementAt(index);
        }
    }
}
