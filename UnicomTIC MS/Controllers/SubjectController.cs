using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Data;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Controllers
{
    public static class SubjectController
    {
        public static List<dynamic> GetCourseSubjects() 
        {
            List<dynamic> list = new List<dynamic>();

            using (var conn = SQLiteConfig.GetConnection())
            {
                
                string query = @"
                   SELECT s.subject_id, s.subject_name, c.course_id, c.course_name, c.duration
                     FROM course c
                        LEFT JOIN subject s ON c.course_id = s.course_id";
                var cmd = new SQLiteCommand(query, conn);
                var reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        list.Add(new 
                        {
                            SubjectID = Convert.ToInt32(reader["subject_id"]),
                            SubjectName = reader["subject_name"].ToString(),
                            CourseID = Convert.ToInt32(reader["course_id"]),
                            CourseName = reader["course_name"].ToString(),
                            Duration = reader["duration"].ToString()
                        });
                    }
                }
            }
                        
            return list;
        }
        public static void AddSubject (Subject subject) 
        {
            using (var conn = SQLiteConfig.GetConnection()) 
            {
                
                var cmd = new SQLiteCommand("INSERT INTO subject (subject_name, course_id) VALUES (@subject_name, @course_id)", conn);
                {
                    cmd.Parameters.AddWithValue("@subject_name", subject.SubjectName);
                    cmd.Parameters.AddWithValue("@course_id", subject.CourseID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<dynamic> GetAllSubjects() 
        {
            List <dynamic> list = new List<dynamic>();
            using (var conn = SQLiteConfig.GetConnection()) 
            {
                
                string query = "SELECT subject_id, subject_name FROM subject";
                var cmd = new SQLiteCommand (query, conn);
                var reader = cmd.ExecuteReader() ;

                while (reader.Read()) 
                {
                    list.Add(new
                    {
                        SubjectID = Convert.ToInt32(reader["Subject_id"]),
                        SubjectName = reader["subject_name"].ToString()
                    });
                }
            }
            return list;
        }
    }
      
   
}
