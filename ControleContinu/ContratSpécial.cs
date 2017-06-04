namespace ControleContinu
{
    public class ContratSpécial : IContrat
    {
        public int CalculerSalaireMensuel(int tauxHoraire)
        {
            return tauxHoraire*6 + 800;
        }
    }
}
