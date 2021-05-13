using System;
using System.Data;
using System.Data.SqlClient;
using Users_and_Security;
// Дополнително во Solution имаме инсталирано SQL packages со помош на NuGet Packet Manager
namespace SQLLogic
{
    public class Connection_and_Queries
    {   // Connection String којшто се користи за поврзување на Azure
        static string connectionString = "Server=tcp:memorygame.database.windows.net,1433;Initial Catalog=Users;Persist Security Info=False;User ID=riste;Password=Ristov123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
        // Функција за поврзување на user
        public static bool signUpUser(string username, string password, string firstName, string secondName)
        {
            // креиранје на конекција conn
            using (var conn = new SqlConnection(connectionString))
            {
                // креирање на Command
                using (var cmd = conn.CreateCommand())
                {
                    // Query за внесување на корисник
                    cmd.CommandText = @"
                        INSERT INTO Users
                        VALUES (@Username, @Passwd, @FirstName, @SecondName, @PersonalBest)
                    ";
                    // Додавање на параметрите во Query
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Passwd", password);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@SecondName", secondName);
                    cmd.Parameters.AddWithValue("@PersonalBest", 0);

                    // Се пробува дали може да се оствари конекција до базата, доколку не може
                    // истот генерира exception којшто резултира со соодветен одговор
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }

                    // Се изврушува Query и притоа се проверува дали се извршило успешно
                    int sucess = (int)cmd.ExecuteNonQuery();
                    // Доколку е успешно
                    if (sucess != 0)
                    {
                        return true;
                    }
                    // Доколку не е успешно
                    else
                    {
                        return false;
                    }
                }
            }


        }
        // Функција за логирање на одреден user
        public static bool logIn(string username, string password)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    // Query коешто го чита user-от и проверува дали истиот постои
                    cmd.CommandText = @"
                        SELECT * FROM Users
                        WHERE Username='" + username + "' AND Passwd='" + password + "'";
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        User.connected = false;
                        return false;
                    }
                    // Прилагодување на податоци за да ја пополниме табелата подолу
                    SqlDataAdapter sda = new SqlDataAdapter(cmd.CommandText, connectionString);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl); // пополнување на табелата
                    if (dtbl.Rows.Count == 1) // Доколку имаме одговор таа ќе има точно еден ред, бидејќи username е сетиран како Primary Key
                    {
                        // Ги земаме вредностите од табелата и ги поставуавме глобално во класата на играч/корисник
                        foreach (DataRow row in dtbl.Rows)
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
        // Функција за ако некој корисник го надминал својот најдобар резултат, па истиот да се ажурира во DB
        public static void updateHighScore()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {   // Соодветно Query
                    cmd.CommandText = @"
                        UPDATE Users
                        SET PersonalBest=" + User.getBestScore() + " WHERE Username='" + User.getUser() + "'";
                    ;
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {

                    }
                    // Извршување на Query
                    int i = (int)cmd.ExecuteNonQuery();
                }
            }
        }

        // Функција која проверува дали одреден корисник постои, користена кај SignUp 
        public static bool UserExists(string username)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    // Соодветно Query
                    cmd.CommandText = @"
                        SELECT * FROM Users
                        WHERE Username='" + username + "'";
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        User.connected = false;
                        return false;
                    }
                    // Читање на податоците коишто се добиени или не се добиени од DB
                    SqlDataAdapter sda = new SqlDataAdapter(cmd.CommandText, connectionString);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                    if (dtbl.Rows.Count == 1)
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
    }
}
