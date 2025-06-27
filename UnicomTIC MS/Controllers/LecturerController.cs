using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UnicomTIC_MS.Data;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Controllers
{
    public static class LecturerController
    {
        public static void AddLecturer(User user, Lecturer lecturer)
        {
            using (SQLiteConnection conn = SQLiteConfig.GetConnection())
            {
                string insertUser = @"
                INSERT INTO users (
                    first_name, last_name, gender, date_of_birth,
                    address, email, password, username, role, phone
                )
                VALUES (
                    @firstName, @lastName, @gender, @dob,
                    @address, @email, @password, @username, @role, @phone
                );"; 
               
                using (SQLiteCommand cmd = new SQLiteCommand(insertUser, conn))
                {
                    cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", user.LastName);
                    cmd.Parameters.AddWithValue("@gender", user.Gender);
                    cmd.Parameters.AddWithValue("@dob", user.DateOfBirth);
                    cmd.Parameters.AddWithValue("@address", user.Address);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@role", user.Role.ToString());
                    cmd.Parameters.AddWithValue("@phone", user.Phone);

                    cmd.ExecuteNonQuery();
                }

                int userId;
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid();", conn)) 
                {
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                string insertLecturer = "INSERT INTO lecturers (user_id, subjects) VALUES (@userId, @subjects);";
                using (SQLiteCommand cmd = new SQLiteCommand(insertLecturer, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@subjects", lecturer.Subjects);
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public static DataTable GetAllLecturers()
        {
            using (SQLiteConnection conn = SQLiteConfig.GetConnection())
            {
                string query = @"
                SELECT
                    u.id, u.first_name || ' ' || u.last_name AS full_name,
                    u.username, u.email, u.phone, l.subjects
                FROM users u
                JOIN lecturers l ON u.id = l.user_id
                WHERE u.role = 'Lecturer';
                ";

                SQLiteDataAdapter dataadapter = new SQLiteDataAdapter(query, conn);
                DataTable datatable = new DataTable();
                dataadapter.Fill(datatable);
                return datatable;
            }
        }
        public static void UpdateLecturer(int UserId, User user, Lecturer lecturer)
        {
            using (SQLiteConnection conn = SQLiteConfig.GetConnection())
            {
                // 1. Update users table
                string updateUser = @"
                     UPDATE users SET 
                        first_name = @firstName, 
                        last_name = @lastName,
                        gender = @gender,
                        date_of_birth = @dob,   
                        address = @address,
                        email = @email,
                        password = @password,
                        username = @username,
                        role = @role,
                        phone = @phone,
                        updated_at = CURRENT_TIMESTAMP
                    WHERE id = @userId;";

                using (SQLiteCommand cmd = new SQLiteCommand(updateUser, conn))
                {
                    cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", user.LastName);
                    cmd.Parameters.AddWithValue("@gender", user.Gender);
                    cmd.Parameters.AddWithValue("@dob", user.DateOfBirth);
                    cmd.Parameters.AddWithValue("@address", user.Address);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@roles", user.Role.ToString());
                    cmd.Parameters.AddWithValue("@phone", user.Phone);
                    cmd.Parameters.AddWithValue("@userId", UserId);

                    cmd.ExecuteNonQuery();
                }

                // 2. Update lecturers table
                string updateLecturer = @"
                    UPDATE lecturers SET 
                        subjects = @subjects
                    WHERE user_id = @userId;";

                using (SQLiteCommand cmd = new SQLiteCommand(updateLecturer, conn))
                {
                    cmd.Parameters.AddWithValue("@subjects", lecturer.Subjects);
                    cmd.Parameters.AddWithValue("@userId", UserId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteLecturer(int userId) 
        {
            using (SQLiteConnection conn = SQLiteConfig.GetConnection())
            {
                string deleteUser = "DELETE FROM users WHERE id = @userId;";
                using (SQLiteCommand cmd = new SQLiteCommand(deleteUser, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
