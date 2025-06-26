using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Data;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Controllers
{
    public class StudentController
    {
        public static void AddStudent(User user, Student student)
        {
            using (SQLiteConnection conn = SQLiteConfig.GetConnection())
            {
                
                string insertUser = @"INSERT INTO users(first_name, last_name, gender, role, date_of_birth, email, phone, address, username, password) 
                    VALUES (@firstName, @lastName, @gender, @role, @dob, @email, @phone,@address, @username, @password )";

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
                    cmd1.Parameters.AddWithValue("@role", user.Role.ToString());

                    cmd1.ExecuteNonQuery(); 
                    long userId = conn.LastInsertRowId;


                    string insertStudent = @" INSERT INTO students (user_id, student_number, course_id)
                                             VALUES (@userId, @studentNumber, @courseid);";

                    using (SQLiteCommand cmd2 = new SQLiteCommand(insertStudent, conn))
                    {
                        cmd2.Parameters.AddWithValue("@userId", userId);
                        cmd2.Parameters.AddWithValue("@studentNumber", student.StudentNumber);
                        cmd2.Parameters.AddWithValue("@courseid", student.CourseId);
                        cmd2.ExecuteNonQuery();
                    }
                    
                }
            }
        }

        public static List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (SQLiteConnection conn = SQLiteConfig.GetConnection())
            {
               
                string query = @"
                SELECT s.student_id, u.id AS user_id, u.first_name, u.last_name, u.username, u.email, u.phone, s.student_number, s.course_id
                FROM students s
                JOIN users  u ON u.id = s.user_id
                WHERE u.role = 'Student';";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                   
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                StudentID = reader.GetInt32(reader.GetOrdinal("student_id")),
                                UserID = reader.GetInt32(reader.GetOrdinal("user_id")),
                                StudentNumber = reader.GetString(reader.GetOrdinal("student_number")),
                                CourseId = reader.GetString(reader.GetOrdinal("course_id")),
                                UserInfo = new User
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("user_id")),
                                    FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                                    LastName = reader.GetString(reader.GetOrdinal("last_name")),
                                    Username = reader.GetString(reader.GetOrdinal("username")),
                                    Email = reader.GetString(reader.GetOrdinal("email")),
                                    Phone = reader.GetString(reader.GetOrdinal("phone"))
                                }
                            };
                            students.Add(student);
                        }
                    }
                }
            }
            return students;
        }
        

    
        
        public static void UpdateStudent(User user, Student student) 
        {
            using (SQLiteConnection conn = SQLiteConfig.GetConnection()) 
            {
                

                string query1 = @"UPDATE users SET
                    first_name =@fname, last_name =@lname, email = @eml, gender = @gen, date_of_birth =@dob, address =@add,
                    password =@pwd, username =@uname, phone = @ph, role = @role
                    WHERE id = @uid";

                using (SQLiteCommand cmd1 = new SQLiteCommand(query1, conn)) 
                {
                    cmd1.Parameters.AddWithValue("@fname", user.FirstName);
                    cmd1.Parameters.AddWithValue("@lname", user.LastName);
                    cmd1.Parameters.AddWithValue("@eml", user.Email);
                    cmd1.Parameters.AddWithValue("gen", user.Gender);
                    cmd1.Parameters.AddWithValue("@dob", user.DateOfBirth);
                    cmd1.Parameters.AddWithValue("@address", user.Address);
                    cmd1.Parameters.AddWithValue("@pwd", user.Password);
                    cmd1.Parameters.AddWithValue("@uname", user.Username);
                    cmd1.Parameters.AddWithValue("@ph", user.Phone);
                    cmd1.Parameters.AddWithValue("@role", user.Role.ToString());
                    cmd1.Parameters.AddWithValue("@uid", user.Id);
                    cmd1.ExecuteNonQuery();
                }
                string query2 = @"UPDATE students SET
                    student_number = @sn, course_id = @cu
                    WHERE student_id = @sid";

                using (SQLiteCommand cmd2 = new SQLiteCommand(query2, conn)) 
                {
                    cmd2.Parameters.AddWithValue("@sn", student.StudentNumber);
                    cmd2.Parameters.AddWithValue("@cu", student.CourseId);
                    cmd2.Parameters.AddWithValue("@sid", student.StudentID);
                    cmd2.ExecuteNonQuery();

                }
            }

        }
        public static void DeleteStudent(int studentID, int userId) 
        {
            using (SQLiteConnection conn = SQLiteConfig.GetConnection()) 
            {
                
                string query1 = "DELETE FROM students WHERE student_id =@sid";
                using (SQLiteCommand cmd1 = new SQLiteCommand(query1, conn)) 
                {
                    cmd1.Parameters.AddWithValue("@sid", studentID);
                    cmd1.ExecuteNonQuery();
                }
                string query2 = "DELETE FROM users WHERE id = @uid";
                using (SQLiteCommand cmd2 = new SQLiteCommand(query2, conn)) 
                {
                    cmd2.Parameters.AddWithValue("@uid", userId);
                    cmd2.ExecuteNonQuery();
                }
            }
        }
    }
}
