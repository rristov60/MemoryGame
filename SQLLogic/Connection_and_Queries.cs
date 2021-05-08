using System;
using System.Data.SqlClient;

namespace SQLLogic
{
    public class Connection_and_Queries
    {
        string connectionString = "Server=tcp:memorygame.database.windows.net,1433;Initial Catalog=Users;Persist Security Info=False;User ID=riste;Password=Ristov123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public void signUpUser(string username, string password, string firstName, string secondName)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    // Username, Password, FirstName, SecondName, PersonalBest
                    cmd.CommandText = @"
                        INSERT INTO Users
                        VALUES (@Username, @Passwd, @FirstName, @SecondName, @PersonalBest)
                    ";

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Passwd", password);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@SecondName", secondName);
                    cmd.Parameters.AddWithValue("@PersonalBest", 0);
                }
            }

        }
    }
}
