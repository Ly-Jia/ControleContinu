using System.Collections.Generic;

namespace ControleContinu
{
    public class Service
    {
        public Service(string nom, Employé chef, IList<Employé> membres)
        {
            Nom = nom;
            Chef = chef;
            Membres = membres;
        }

        public string Nom { get; set; }
        public Employé Chef { get; set; }
        public IList<Employé> Membres { get; set; } 
    }
}
