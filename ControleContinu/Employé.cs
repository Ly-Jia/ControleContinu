namespace ControleContinu
{
    public class Employé
    {
        public Employé(string nom, string titre, int tauxHoraire)
        {
            Nom = nom;
            Titre = titre;
            TauxHoraire = tauxHoraire;
        }

        public string Nom { get; private set; }
        public string Titre { get; private set; }
        public int TauxHoraire { get; private set; }

        public int SalaireMensuel()
        {
            return TauxHoraire*8*20;
        }
    }
}
