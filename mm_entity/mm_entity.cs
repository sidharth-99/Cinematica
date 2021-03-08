using System;
namespace mm_entity
{
    public class MovieList//Class containing details of Movie
    {
        public MovieList()//default constructor
        {
        }

        public MovieList(string mname, int myear, string mcat, string mlang, double mrate, string mlead, string mdesc, string mduration, string mbudget)//Parametrized Constructor
        {
            moviename = mname;
            movieyear = myear;
            moviecat = mcat;
            movielang = mlang;
            movierate = mrate;
            movielead = mlead;
            moviedesc = mdesc;
            movieduration = mduration;
            moviebudget = mbudget;
        }
        public string moviename { get; set; }
        public int movieyear { get; set; }
        public string moviecat { get; set; }
        public string movielang { get; set; }
        public double movierate { get; set; }
        public string movielead { get; set; }
        public string moviedesc { get; set; }
        public string movieduration { get; set; }
        public string moviebudget { get; set; }
    }
    public class AdminDetails//Class to add admin registration details
    {

        public AdminDetails(int adid, string adname, string adpswd)//Parametrized Constructor
        {
            adminid = adid;
            adminname = adname;
            adminpswd = adpswd;
        }
        public int adminid { get; set; }
        public string adminname { get; set; }
        public string adminpswd { get; set; }
    }
    public class UserDetails//Class to add customer registration details
    {

        public UserDetails(int uid, string uname, string upswd)//Parametrized Constructor
        {
            usernid = uid;
            username = uname;
            userpswd = upswd;
        }
        public int usernid { get; set; }
        public string username { get; set; }
        public string userpswd { get; set; }
    }
}
