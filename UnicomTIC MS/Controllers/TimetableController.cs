using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UnicomTIC_MS.Data;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Controllers
{
    public class TimetableController
    {
        public static void AddTimetable(Timetable t)
        {
            using (var conn = SQLiteConfig.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO timetable (SubjectID, TimeSlot, RoomID) VALUES (@sid, @slot, @rid)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@sid", t.SubjectID);
                    cmd.Parameters.AddWithValue("@slot", t.TimeSlot);
                    cmd.Parameters.AddWithValue("@rid", t.RoomID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Timetable> GetAllTimetables()
        {
            List<Timetable> list = new List<Timetable>();

            using (var conn = SQLiteConfig.GetConnection())
            {
                conn.Open();
                string query = @"SELECT t.TimetableID, t.TimeSlot, s.SubjectName, r.RoomName, r.RoomType
                        FROM timetable t 
                        JOIN subject s ON t.SubjectID = s.SubjectID
                        JOIN room r ON t.RoomID = r.RoomID";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Timetable t = new Timetable
                        {
                            TimetableID = Convert.ToInt32(reader["TimetableID"]),
                            SubjectName = reader["SubjectName"].ToString(),
                            TimeSlot = reader["TimeSlot"].ToString(),
                            RoomName = reader["RoomName"].ToString(),
                            RoomType = reader["RoomType"].ToString(),
                        };
                        list.Add(t);
                    }
                }
            }
            return list;
        }
        public static void UpdateTimetable(Timetable t)
        {
            using (var conn = SQLiteConfig.GetConnection())
            {
                conn.Open();
                string query = "UPDATE timetable SET SubjectID=@sid, TimeSlot=@slot, RoomID=@rid WHERE TimetableID=@id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@sid", t.SubjectID);
                    cmd.Parameters.AddWithValue("@slot", t.TimeSlot);
                    cmd.Parameters.AddWithValue("@rid", t.RoomID);
                    cmd.Parameters.AddWithValue("@id", t.TimetableID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteTimetable(int id)
        {
            using (var conn = SQLiteConfig.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM timetable WHERE TimetableID=@id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
