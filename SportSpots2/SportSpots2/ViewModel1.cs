using Model;


namespace SportsSpots
{
    public class ViewModel1
    {

        public User Utilisateur { get; set; }
        public SportStub SportsAvaibles { get; set; } = new SportStub();


        public ViewModel1(User utilisateur)
        {
            Utilisateur = utilisateur;
        }


    }
}
