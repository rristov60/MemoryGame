using System;
using System.Data;
using System.Data.SqlClient;
using Users_and_Security;

namespace SQLLogic
{
    public class Connection_and_Queries
    {
        static string connectionString = "Server=tcp:memorygame.database.windows.net,1433;Initial Catalog=Users;Persist Security Info=False;User ID=riste;Password=Ristov123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static bool signUpUser(string username, string password, string firstName, string secondName)
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

                    try
                    {
                        conn.Open();
                    }catch (Exception ex)
                    {
                        return false;
                    }

                    //cmd.ExecuteNonQuery()
                    int sucess = (int)cmd.ExecuteNonQuery();

                    if(sucess != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }


        }

        public static bool logIn(string username, string password)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT * FROM Users
                        WHERE Username='" + username + "' AND Passwd='" + password + "'";
                    try
                    {
                        conn.Open();
                    }
                    catch(Exception ex)
                    {
                        User.connected = false;
                        return false;
                    }

                    SqlDataAdapter sda = new SqlDataAdapter(cmd.CommandText, connectionString);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                    if (dtbl.Rows.Count == 1)
                    {
                        foreach(DataRow row in dtbl.Rows)
                        {
                            User.setUserName(row["Username"].ToString());
                            User.setName(row["FirstName"].ToString());
                            User.setLastName(row["SecondName"].ToString());
                            User.setBestScore(int.Parse(row["PersonalBest"].ToString()));
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }

        public static void updateHighScore()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Users
                        SET PersonalBest=" + User.getBestScore() + " WHERE Username='" + User.getUser() + "'";
                    ;
                    try
                    {
                        conn.Open();
                    }catch (Exception ex)
                    {

                    }

                    int i = (int)cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
