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
    public class RoomController
    {
        public static List<Room> GetAllRooms()
        {
            List<Room> list = new List<Room>();
            using (var conn = SQLiteConfig.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM room";
                var cmd = new SQLiteCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Room
                    {
                        RoomID = Convert.ToInt32(reader["RoomID"]),
                        RoomName = reader["RoomName"].ToString(),
                        RoomType = reader["RoomType"].ToString()
                    });
                }
            }
            return list;
        }
        public static void AddRoom(Room room)
        {
            using (var conn = SQLiteConfig.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO room(RoomName, Roomtype) VALUES (@name, @type)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", room.RoomName);
                    cmd.Parameters.AddWithValue("@type", room.RoomType);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateRoom(Room room)
        {
            using (var conn = SQLiteConfig.GetConnection())
            {
                conn.Open();
                string query = "UPDATE room SET RoomName = @name, RoomType = @type WHERE RoomID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", room.RoomName);
                    cmd.Parameters.AddWithValue("@type", room.RoomType);
                    cmd.Parameters.AddWithValue("id", room.RoomID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteRoom(int roomID)
        {
            using (var conn = SQLiteConfig.GetConnection())
            {
                conn.Open();
                string query = "DELETE from ROOM WHERE ROOMID =@id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", roomID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //public static List<Room> GetAllRooms()
        //{
        //    List<Room> list = new List<Room>();
        //    using (var conn = SQLiteConfig.GetConnection())
        //    {
        //        conn.Open();
        //        string query = "SELECT * FROM room";
        //        var cmd = new SQLiteCommand(query, conn);
        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            list.Add(new Room
        //            {
        //                RoomID = Convert.ToInt32(reader["RoomID"]),
        //                RoomName = reader["RoomName"].ToString(),
        //                RoomType = reader["RoomType"].ToString()
        //            });
        //        }
        //    }
        //    return list;
        

    }
}
