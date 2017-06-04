using System;

namespace ControleContinu
{
    public class Employé : IOrganigrammeComposant
    {
        public Employé(string nom, string titre, int tauxHoraire, IContrat _contrat)
        {
            Nom = nom;
            Titre = titre;
            TauxHoraire = tauxHoraire;
            contrat = _contrat;
        }

        public string Nom { get; private set; }
        public string Titre { get; private set; }
        public int TauxHoraire { get; private set; }
        private IContrat contrat;

        public int SalaireMensuel()
        {
            return contrat.CalculerSalaireMensuel(TauxHoraire);
        }

        public void Afficher()
        {
            Console.WriteLine(" * " + Nom + ", " + Titre);
        }
    }
}
