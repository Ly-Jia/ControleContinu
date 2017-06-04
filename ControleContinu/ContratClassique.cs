namespace ControleContinu
{
    public class ContratClassique : IContrat
    {
        public int CalculerSalaireMensuel(int tauxHoraire)
        {
            return tauxHoraire * 8 * 20;
        }
    }
}
