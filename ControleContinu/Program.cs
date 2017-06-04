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
             * => Composite, car permet d'appliquer une même opération (afficher les informations d'un élément) à un groupe d'objet
             * Quelle(s) autre(s) modification(s) majeure(s) avez-vous apportée(s), et pourquoi ?
             * 
             * Barème :
             * * La modification permet de rajouter des couches de hiérarchie (2 points)
             * * Le design pattern principal a été appliqué et expliqué (2 points)              
             * * Le design pattern a été correctement appliqué (4 points)
             * * Le code respecte les principes de la programmation objet (2 points)
             * * Les réponses aux questions 1 et 2 de la classe organigramme sont correctes (1 point chacune)
             * * Bonus : 2ème design pattern applicable (2 points) => Iterator
             */
            organigramme.Afficher();

            Console.WriteLine("----------------------------------");

            Console.WriteLine("Exercice 2 : Les salaires mensuels");
            /*
             * Le salaire mensuel d'un employé est déterminé actuellement par la formule suivante : taux horaire x 8 x 20
             * Modifiez le code afin que les salaires de Quentin et Justine suivent la formule suivante : taux horaire x 6 + 800
             * Quel design pattern avez-vous appliqué, et pourquoi ?
             * => Stratégie, le calcul du salaire est le seul concept variable, et peut donc être encapsulé en suivant
             * le principe Open-Closed (ouvert à l'extension, fermé à la modification)
             * Barème :
             * * La modification est fonctionnelle (2 points)
             * * Le design pattern attendu a été appliqué et correctement expliqué (2 points)
             * * Le design pattern a été correctement appliqué (4 points)
             * * Bonus : Pourquoi est-il conseillé de privilégier la composition à l'héritage ? (2 points)
             * => La composition permet un moindre couplage entre deux classes par rapport à l'héritage
             */
            foreach (var employé in employés)
            {
                Console.WriteLine(employé.Nom + " " + employé.SalaireMensuel());
            }
            Console.ReadKey();
        }

        private static void CreateOrganigramme()
        {
            ContratClassique contratClassique = new ContratClassique();
            ContratSpécial contratSpécial = new ContratSpécial();

            Employé grégoire = new Employé("Grégoire Chaloux", "Responsable RH", 20, contratClassique);
            Employé denise = new Employé("Denise Trudeau", "Formations et carrières", 15, contratClassique);
            Employé quentin = new Employé("Quentin Rousseau", "Recruteur", 15, contratSpécial);
            IList<IOrganigrammeComposant> membresRH = new List<IOrganigrammeComposant> { denise, quentin };
            Service rh = new Service("RH", grégoire, membresRH);
            employés.Add(grégoire);
            employés.Add(denise);
            employés.Add(quentin);

            Employé delphine = new Employé("Delphine Lajoie", "Responsable IT", 20, contratClassique);
            Employé gérard = new Employé("Gérard Martin", "Développeur", 15, contratClassique);
            Employé justine = new Employé("Justine Dupont", "Développeuse", 15, contratSpécial);
            IList<IOrganigrammeComposant> membresIT = new List<IOrganigrammeComposant> { gérard, justine };
            Service it = new Service("IT", delphine, membresIT);
            employés.Add(delphine);
            employés.Add(gérard);
            employés.Add(justine);

            Employé laurent = new Employé("Laurent Davignon", "Comptable", 20, contratClassique);
            Employé juste = new Employé("Juste Blanc", "Stagiaire", 12, contratClassique);
            IList<IOrganigrammeComposant> membresCompta = new List<IOrganigrammeComposant> { juste };
            Service compta = new Service("Comptabilité", laurent, membresCompta);
            employés.Add(laurent);
            employés.Add(juste);

            organigramme = new Organigramme("Arianne Cosmos", new List<IOrganigrammeComposant> { rh, it, compta });
        }
    }
}
