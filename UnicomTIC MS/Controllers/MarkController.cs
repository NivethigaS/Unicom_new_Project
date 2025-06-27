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
    public class MarkController
    {
        public static List<dynamic> GetAllMarks() 
        {
            List<dynamic> list = new List<dynamic>();
            using (var conn = SQLiteConfig.GetConnection())
            {
                
                string query = @"SELECT m.MarkId, m.Score, 
                                    u.first_name || ' ' || u.last_name AS StudentName,
                                    e.ExamName, m.StudentId, m.ExamId
                             FROM mark m
                             JOIN students s ON m.StudentId = s.StudentId
                             JOIN exam e ON m.ExamId = e.ExamId";

                var cmd = new SQLiteCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new
                    {
                        MarkId = Convert.ToInt32(reader["MarkId"]),
                        Score = Convert.ToInt32(reader["Score"]),
                        StudentName = reader["StudentName"].ToString(),
                        ExamName = reader["ExamName"].ToString(),
                        StudentId = Convert.ToInt32(reader["StudentId"]),
                        ExamId = Convert.ToInt32(reader["ExamId"])
                    });
                }
            }
            return list;
        }
        public static void AddMark(Mark mark) 
        {
            using (var conn = SQLiteConfig.GetConnection()) 
            {
                
                var cmd = new SQLiteCommand("INSERT INTO mark (StudentId, ExamId, Score) VALUES (@sid, @eid, @score)", conn);
                cmd.Parameters.AddWithValue("@sid", mark.StudentID);
                cmd.Parameters.AddWithValue("@eid", mark.ExamId);
                cmd.Parameters.AddWithValue("@score", mark.Score);
                cmd.ExecuteNonQuery();

            }

        }
        public static void UpdateMark(Mark mark) 
        {
            using (var conn = SQLiteConfig.GetConnection()) 
            {
                
                var cmd = new SQLiteCommand("UPDATE mark SET StudentId=@sid, ExamId=@eid, Score=@score WHERE MarkId=@id", conn);
                cmd.Parameters.AddWithValue("@sid", mark.StudentID);
                cmd.Parameters.AddWithValue("@eid", mark.ExamId);
                cmd.Parameters.AddWithValue("@score", mark.Score);
                cmd.Parameters.AddWithValue("@id", mark.MarkId);
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteMark(int markId) 
        {
            using (var conn = SQLiteConfig.GetConnection()) 
            {
                
                var cmd = new SQLiteCommand("DELETE FROM mark WHERE MarkId=@id", conn);
                cmd.Parameters.AddWithValue("@id", markId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
