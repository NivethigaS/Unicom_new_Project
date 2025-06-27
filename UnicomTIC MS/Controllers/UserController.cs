using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Data;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Controllers
{
    public static class UserController
    {
        public static User Authenticate(string username, string password) 
        {
            using (var conn = SQLiteConfig.GetConnection()) 
            {
                
                string query = "SELECT * FROM user WHERE username = @username AND password = @password";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                
                var reader = cmd.ExecuteReader();
                if (reader.Read()) 
                {
                    return new User
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Username = reader["username"].ToString(),
                        Password = reader["password"].ToString(),
                        Role = (UserRole)Enum.Parse(typeof(UserRole), reader["role"].ToString(), true)

                    };
                }
            }
            return null;
        }
    }
}
