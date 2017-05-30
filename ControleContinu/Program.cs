using System;
using System.Collections.Generic;

namespace ControleContinu
{
    public class Program
    {
        private static IList<Employé> employés = new List<Employé>();
        private static Organigramme organigramme;

         
        static void Main()
        {
            CreateOrganigramme();
            Console.WriteLine("Exercice 1 : Organigramme");
            /*
             * La classe Organigramme permet d'afficher la structure d'une entreprise, mais n'est pas très souple.
             * En effet, il est nécessaire d'avoir un service RH, un service IT et un service comptabilité. 
             * Rajouter un nouveau service implique de modifier à chaque fois cette classe, et il est envisagé de rajouter des couches de hiérachie
             * (par exemple un sous-service Web et un sous-service SQL dans le service IT)
             * De plus, le code écrit pour afficher l'organigramme laisse à désirer (pensez à répondre aux questions marquées par un @TODO)
             * 
             * Modifiez le code pour permettre de créer un organigramme avec la contrainte énoncée, et corrigez le code si nécessaire.
             * Quel(s) design pattern(s) avez-vous appliqué, et pourquoi ?
             * Quelle(s) autre(s) modification(s) majeure(s) avez-vous apportée(s), et pourquoi ?
             * 
             * Barème :
             * * La modification permet de rajouter des couches de hiérarchie (2 points)
             * * Le design pattern principal a été appliqué et expliqué (2 points)
             * * Le design pattern a été correctement appliqué (4 points)
             * * Le code respecte les principes de la programmation objet (2 points)
             * * Les réponses aux questions 1 et 2 de la classe organigramme sont correctes (1 point chacune)
             * * Bonus : 2ème design pattern applicable (2 points)
             */
            organigramme.Afficher();

            Console.WriteLine("----------------------------------");

            Console.WriteLine("Exercice 2 : Les salaires mensuels");
            /*
             * Le salaire mensuel d'un employé est déterminé actuellement par la formule suivante : taux horaire x 8 x 20
             * Modifiez le code afin que les salaires de Quentin et Justine suivent la formule suivante : taux horaire x 6 + 800
             * Quel design pattern avez-vous appliqué, et pourquoi ?
             * 
             * Barème :
             * * La modification est fonctionnelle (2 points)
             * * Le design pattern attentdu a été appliqué et correctement expliqué (2 points)
             * * Le design pattern a été correctement appliqué (4 points)
             * * Bonus : Pourquoi est-il conseillé de privilégier la composition à l'héritage ? (2 points)
             */
            foreach (var employé in employés)
            {
                Console.WriteLine(employé.Nom + " " + employé.SalaireMensuel());
            }
            Console.ReadKey();
        }

        private static void CreateOrganigramme()
        {
            Employé grégoire = new Employé("Grégoire Chaloux", "Responsable RH", 20);
            Employé denise = new Employé("Denise Trudeau", "Formations et carrières", 15);
            Employé quentin = new Employé("Quentin Rousseau", "Recruteur", 15);
            IList<Employé> membresRH = new List<Employé> {denise, quentin};
            Service rh = new Service("RH", grégoire, membresRH);
            employés.Add(grégoire);
            employés.Add(denise);
            employés.Add(quentin);

            Employé delphine = new Employé("Delphine Lajoie", "Responsable IT", 20);
            Employé gérard = new Employé("Gérard Martin", "Développeur", 15);
            Employé justine = new Employé("Justine Dupont", "Développeuse", 15);
            IList<Employé> membresIT = new List<Employé> {gérard, justine};
            Service it = new Service("IT", delphine, membresIT);
            employés.Add(delphine);
            employés.Add(gérard);
            employés.Add(justine);

            Employé laurent = new Employé("Laurent Davignon", "Comptable", 20);
            Employé juste = new Employé("Juste Blanc", "Stagiaire", 12);
            IList<Employé> membresCompta = new List<Employé> {juste};
            Service compta = new Service("Comptabilité", laurent, membresCompta);
            employés.Add(laurent);
            employés.Add(juste);

            organigramme = new Organigramme("Arianne Cosmos", rh, it, compta);
        }
    }
}
