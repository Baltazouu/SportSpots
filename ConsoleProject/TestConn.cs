
using Model;
namespace ConsoleProject
{
    public class TestConn
    {

        public TestConn()
        {

        // uncomment for tests
          /*Console.WriteLine("[TestConn]");

            string u1 = "bapt.14@hotmail.com";
            string pass1 = "nouvpass";
            string pass2 = "wrongpass";

            Console.WriteLine("Test :", u1,pass1);
            Connexion conn = new Connexion(u1, pass1);
           
            bool res = conn.CheckMailExist(u1);
            Console.WriteLine("Connexion check user exist :  {0}", res);

            bool respass = conn.CheckRightPasswd(u1,pass1);
            Console.WriteLine("Check Right password for {0} {1}", u1,respass );
            *//* 
              Console.WriteLine("Check Right password for {0} with wrong pass : {1}", u1, conn.CheckRightPasswd(u1,pass2));


              Console.WriteLine("Test : jean.michel@icloud.com", "mdp");

              conn = new Connexion("jean.michel@icloud.com", "mdp");
              res = conn.CheckUserExist("jean.michel@icloud.com");
              Console.WriteLine("Connexion check user exist :  {0}", res);*//*

            conn.GetNewUserId();


            string mail2 = "test.com@gmail.com";
            string pass = "password";

            Connexion cn = new(mail2,pass);

            Console.WriteLine("TEST LOAD FAVSPOTS :");
            List<Spot> l = cn.LoadFavSpotFromUser(mail2);

            Console.WriteLine("Nom : {0}", l[0].Name);*/
        }

    }
}
