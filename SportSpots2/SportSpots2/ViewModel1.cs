using Model;


namespace SportsSpots
{
    public class ViewModel1
    {

        public User Utilisateur { get; set; }
        public SportStub SportsAvaibles { get; set; } = new SportStub();

        public List<Sport> toSearch { get; set; } = new();

        public ViewModel1(User utilisateur)
        {
            Utilisateur = utilisateur;
            
        }

        

    }
}
