using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Data;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Controllers
{
    public static class StaffController
    {
        public static void AddStaff(User user, Staff staff)
        {
            using (SQLiteConnection conn = SQLiteConfig.GetConnection())
            {
                conn.Open();

                string insertUser = @"INSERT INTO users(first_name, last_name, gender, role, date_of_birth, email, phone, address, username, password) 
                    VALUES (@firstName, @lastName, @gender, @role, @dob, @email, @phone, @address, @username, @password )";

                using (SQLiteCommand cmd1 = new SQLiteCommand(insertUser, conn))
                {
                    cmd1.Parameters.AddWithValue("@firstName", user.FirstName);
                    cmd1.Parameters.AddWithValue("@lastName", user.LastName);
                    cmd1.Parameters.AddWithValue("@gender", user.Gender);
                    cmd1.Parameters.AddWithValue("@dob", user.DateOfBirth);
                    cmd1.Parameters.AddWithValue("@email", user.Email);
                    cmd1.Parameters.AddWithValue("@phone", user.Phone);
                    cmd1.Parameters.AddWithValue("@address", user.Address);
                    cmd1.Parameters.AddWithValue("@username", user.Username);
                    cmd1.Parameters.AddWithValue("@password", user.Password);
                    cmd1.Parameters.AddWithValue("@role", user.Role);
                }
                int userId = (int)conn.LastInsertRowId;

                string insertStaff = @"INSERT INTO staffs (user_id, designation) VALUES (@userId, @designation);";
                using (SQLiteCommand cmd2 = new SQLiteCommand(insertStaff, conn))
                {
                    cmd2.Parameters.AddWithValue("@userId", userId);
                    cmd2.Parameters.AddWithValue("@designation", staff.Designation);
                    cmd2.ExecuteNonQuery();
                }
            }
        }
        public static DataTable GetAllStaffs()
        {
            using (SQLiteConnection conn = SQLiteConfig.GetConnection())
            {
                string query = @"
                SELECT
                    u.id, u.first_name || ' ' || u.last_name AS full_name,
                    u.username, u.email, u.phone, st.designation
                FROM users u
                JOIN staffs st ON u.id = st.id
                WHERE u.role = 'Staff';
                ";

                SQLiteDataAdapter dataadapter = new SQLiteDataAdapter(query, conn);
                DataTable datatable = new DataTable();
                dataadapter.Fill(datatable);
                return datatable;
            }
        }
        public static void UpdateStaff(User user, Staff staff)
        {
            using (SQLiteConnection conn = SQLiteConfig.GetConnection())
            {

                string updateUser = @"UPDATE users SET
                    first_name = @firstName, last_name = @lastname, gender = @gender, date_of_birth = @dob, adress = @address,
                    email = @email, phone = @phone, username = @username, password = @password
                    WHERE user_id = @userId;";

                using (SQLiteCommand cmd1 = new SQLiteCommand(updateUser, conn))
                {
                    cmd1.Parameters.AddWithValue("@firstName", user.FirstName);
                    cmd1.Parameters.AddWithValue("@lastName", user.LastName);
                    cmd1.Parameters.AddWithValue("@gender", user.Gender);
                    cmd1.Parameters.AddWithValue("@dob", user.DateOfBirth);
                    cmd1.Parameters.AddWithValue("@address", user.Address);
                    cmd1.Parameters.AddWithValue("@email", user.Email);
                    cmd1.Parameters.AddWithValue("@phone", user.Phone);
                    cmd1.Parameters.AddWithValue("@username", user.Username);
                    cmd1.Parameters.AddWithValue("@password", user.Password);
                    cmd1.Parameters.AddWithValue("@userId", user.Id);
                    cmd1.ExecuteNonQuery();
                }
                string updateStaff = @"UPDATE staffs SET designation = @designation, WHERE staff_id = @stId;";

                using (SQLiteCommand cmd2 = new SQLiteCommand(updateStaff, conn))
                {
                    cmd2.Parameters.AddWithValue("@designation", staff.Designation);
                    cmd2.Parameters.AddWithValue("@stId", staff.StaffID);
                    cmd2.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteStaff (User user, Staff staff)
        {
            using (SQLiteConnection conn = SQLiteConfig.GetConnection())
            {
                string deleteStaff = @"DELETE FROM staffs WHERE staff_id = @stId;";
                using (SQLiteCommand cmd1 = new SQLiteCommand(deleteStaff, conn))
                {
                    cmd1.Parameters.AddWithValue("@stId", staff.StaffID);
                    cmd1.ExecuteNonQuery();
                }
                string deleteUser = @"DELETE FROM users WHERE user_id = @userId;";
                using (SQLiteCommand cmd2 = new SQLiteCommand(deleteUser, conn))
                {
                    cmd2.Parameters.AddWithValue("@userId", user.Id);
                    cmd2.ExecuteNonQuery();
                }
            }
        }
    }
}
