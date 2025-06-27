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
    public static class CourseController
    {
        public static List<Course> GetAllCourses()
        {
            List<Course> list = new List<Course>();
            using (var conn = SQLiteConfig.GetConnection())
            {
                
                var cmd = new SQLiteCommand("SELECT * FROM course", conn);
                var reader = cmd.ExecuteReader();
                
                {
                    while (reader.Read())
                    {
                        list.Add(new Course
                        {
                            CourseId = Convert.ToInt32(reader["course_id"]),
                            CourseName = reader["course_name"].ToString(),
                            Duration = reader["duration"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public static void AddCourse(Course course)
        {
            using (var conn = SQLiteConfig.GetConnection())
            {
                
                var cmd = new SQLiteCommand("INSERT INTO course (course_name, duration) VALUES (@name, @duration)", conn);
                
                    cmd.Parameters.AddWithValue("@name", course.CourseName);
                    cmd.Parameters.AddWithValue("@duration", course.Duration);
                    cmd.ExecuteNonQuery();
                
            }
        }

        public static void UpdateCourse(Course course)
        {
            using (var conn = SQLiteConfig.GetConnection())
            {
                
                var cmd = new SQLiteCommand("UPDATE course SET course_name = @name, duration = @duration WHERE course_id = @id", conn);
                
                    cmd.Parameters.AddWithValue("@id", course.CourseId);
                    cmd.Parameters.AddWithValue("@name", course.CourseName);
                    cmd.Parameters.AddWithValue("@duration", course.Duration);
                    cmd.ExecuteNonQuery();
                
            }
        }

        public static void DeleteCourse(int courseId)
        {
            using (var conn = SQLiteConfig.GetConnection())
            {
                
                var cmd = new SQLiteCommand("DELETE FROM course WHERE course_id = @id", conn);
                
                    cmd.Parameters.AddWithValue("@id", courseId);
                    cmd.ExecuteNonQuery();
                
            }
        }
        public static DataTable GetCourseSubjectData() 
        {
            DataTable datatable = new DataTable();
            using (var conn = SQLiteConfig.GetConnection()) 
            {
                
                string query = @"
                    SELECT c.course_name AS'Course Name', c.duration AS 'Duration', s.subject_name AS 'Subject Name'
                    FROM course c
                    LEFT JOIN subject s ON c.course_id = s.course_id";

                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, conn);
                dataAdapter.Fill(datatable);
    
            }
            return datatable;
        }

    }
}

            
        


    

