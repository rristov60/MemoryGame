using System;

namespace Users_and_Security
{
    // Класа која ни содржи информации за корисникот
    public class User
    {
        private static string username; // Корисничко име 
        private static string name; // Име
        private static string lastName; // Презиме
        private static int bestScore; // Најдобар резултат
        public static bool newHighScore; // Нов најдобар резултат
        public static bool connected = true; // Конектиран кон интернет
        
        // Конструктор
        public User(string _username, string _name, string _lastName, int _bestScore) 
        {
            username = _username;
            name = _name;
            lastName = _lastName;
            bestScore = _bestScore;
        }
        // Сетирање на guest user
        public static void guestUser()
        {
            username = "guest";
            name = "Guest";
            lastName = "";
            bestScore = 0;
        }
        // Getters & Setters
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

        public static void setUserName(string _username)
        {
            username = _username;
        }

        public static void setName(string _name)
        {
            name = _name;
        }

        public static void setLastName(string _lastName)
        {
            lastName = _lastName;
        }

    }
}
