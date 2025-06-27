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
    public class ExamController
    {
        public static List<dynamic> GetAllExamsWithSubject()
            {
                List<dynamic> list = new List<dynamic>();
                using (var conn = SQLiteConfig.GetConnection())
                {
                    
                    string query = @"SELECT e.ExamId, e.ExamName, s.subject_name, e.SubjectId
                             FROM exam e
                             JOIN subject s ON e.SubjectId = s.subject_id";

                    var cmd = new SQLiteCommand(query, conn);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            ExamId = Convert.ToInt32(reader["ExamId"]),
                            ExamName = reader["ExamName"].ToString(),
                            SubjectName = reader["SubjectName"].ToString(),
                            SubjectId = Convert.ToInt32(reader["subject_id"])
                        });
                    }
                }
                return list;
            }

            public static void AddExam(Exam exam)
            {
                using (var conn = SQLiteConfig.GetConnection())
                {
                    
                    var cmd = new SQLiteCommand("INSERT INTO exam (ExamName, SubjectId) VALUES (@name, @sid)", conn);
                    cmd.Parameters.AddWithValue("@name", exam.ExamName);
                    cmd.Parameters.AddWithValue("@sid", exam.SubjectID);
                    cmd.ExecuteNonQuery();
                }
            }

            public static void UpdateExam(Exam exam)
            {
                using (var conn = SQLiteConfig.GetConnection())
                {
                    
                    var cmd = new SQLiteCommand("UPDATE exam SET ExamName=@name, SubjectId=@sid WHERE ExamId=@id", conn);
                    cmd.Parameters.AddWithValue("@name", exam.ExamName);
                    cmd.Parameters.AddWithValue("@sid", exam.SubjectID);
                    cmd.Parameters.AddWithValue("@id", exam.ExamId);
                    cmd.ExecuteNonQuery();
                }
            }

            public static void DeleteExam(int id)
            {
                using (var conn = SQLiteConfig.GetConnection())
                {
                    
                    var cmd = new SQLiteCommand("DELETE FROM exam WHERE ExamId=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }

