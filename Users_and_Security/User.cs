using System;

namespace Users_and_Security
{
    public class User
    {
        private static string username;
        private static string name;
        private static string lastName;
        private static int bestScore;
        public static bool newHighScore;
        public static bool connected = true;
        public User(string _username, string _name, string _lastName, int _bestScore) 
        {
            username = _username;
            name = _name;
            lastName = _lastName;
            bestScore = _bestScore;
        }

        public static void guestUser()
        {
            username = "guest";
            name = "Guest";
            lastName = "";
            bestScore = 0;
        }

        public static string getName()
        {
            return name;
        }

        public static int getBestScore()
        {
            return bestScore;
        }

        public static void setBestScore(int _bestScore)
        {
            bestScore = _bestScore;
        }

        public static string getUser()
        {
            return username;
        }
    }
}
