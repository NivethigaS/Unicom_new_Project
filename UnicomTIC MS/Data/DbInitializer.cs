using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Data
{
    internal class DbInitializer
    {
        public static void CreateTables()
        {
            using (SQLiteConnection conn = SQLiteConfig.GetConnection())
            {
                //Users Table
                string createUsersTable = @"
                    CREATE TABLE IF NOT EXISTS users(
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        first_name TEXT NOT NULL,
                        last_name TEXT NOT NULL,
                        gender TEXT NOT NULL,
                        date_of_birth TEXT NOT NULL,
                        address TEXT NOT NULL,
                        email TEXT NOT NULL,
                        password TEXT NOT NULL,
                        username TEXT NOT NULL,
                        role TEXT NOT NULL,
                        phone TEXT NOT NULL,
                        created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                        updated_at DATETIME DEFAULT CURRENT_TIMESTAMP
                    );";

                //Student Table
                string createStudentsTable = @"
                    CREATE TABLE IF NOT EXISTS students (
                        student_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        user_id INTEGER NOT NULL,
                        student_number TEXT UNIQUE NOT NULL,
                        course_id INTERGER NOT NULL ,
                        FOREIGN KEY(user_id) REFERENCES users(id),
                        FOREIGN KEY(course_id) REFERENCES course(course_id)
                    );
                ";

                //Lectruers Table
                string createLecturersTable = @"
                    CREATE TABLE IF NOT EXISTS lecturers (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        user_id INTEGER NOT NULL,
                        subjects TEXT,
                        FOREIGN KEY(user_id) REFERENCES users(id)
                    );
                ";

                //Staffs Table
                string createStaffsTable = @"
                    CREATE TABLE IF NOT EXISTS staffs (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        user_id INTEGER NOT NULL,
                        designation TEXT,
                        FOREIGN KEY(user_id) REFERENCES users(id)
                    );
                ";

                //Admin Table
                string createAdminsTable = @"
                    CREATE TABLE IF NOT EXISTS admins (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        user_id INTEGER NOT NULL,
                        access_level TEXT,
                        FOREIGN KEY(user_id) REFERENCES users(id)
                    );
                ";
                //Course Table 
                string createCourseTable = @"
                     CREATE TABLE IF NOT EXISTS course (
                        course_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        course_name TEXT NOT NULL,
                        duration TEXT NOT NULL
                    ); 
                ";
                //Subject Table 
                string createSubjecTable = @"
                    CREATE TABLE IF NOT EXISTS subject (
                        subject_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        subject_name TEXT NOT NULL,
                        course_id INTEGER NOT NULL,
                        FOREIGN KEY(course_id) REFERENCES course(course_id)
                    );
                ";
                //Mark Table
                string createMarkTable = @"
                    CREATE TABLE IF NOT EXISTS mark(
                        MarkId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentId INTEGER NOT NULL,
                        ExamId INTEGER NOT NULL,
                        Score INTEGER NOT NULL,
                        FOREIGN KEY(StudentId) REFERENCES student(StudentId),
                        FOREIGN KEY(ExamId) REFERENCES exam(ExamId)
                    );
                ";
                //Exam Table
                string createExamTable = @"
                    CREATE TABLE IF NOT EXISTS exam(
                        ExamId INTEGER PRIMARY KEY AUTOINCREMENT,
                        ExamName TEXT NOT NULL,
                        SubjectId INTEGER NOT NULL,
                        FOREIGN KEY(SubjectId) REFERENCES subject(SubjectId)
                    );
                ";
                //Room Table
                string createRoomTable = @"
                    CREATE TABLE IF NOT EXISTS room (
                        RoomId INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoomName TEXT NOT NULL,
                        RoomType TEXT NOT NULL
                    );
                ";
                //Timetable table
                string createTimetable = @"
                    CREATE TABLE IF NOT EXISTS timetable (
	                    TimetableID INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectID INTEGER NOT NULL,
	                    TimeSlot TEXT NOT NULL,
	                    RoomId	INTEGER NOT NULL,
                        FOREIGN KEY (SubjectID) REFERENCES subject(SubjectID),
                        FOREIGN KEY (RoomId) REFERENCES room(RoomId)
                    );
                ";
	


                // Execute all create table queries
                ExecuteQuery(conn, createUsersTable, "users");
                ExecuteQuery(conn, createStudentsTable, "students");
                ExecuteQuery(conn, createLecturersTable, "lecturers");
                ExecuteQuery(conn, createStaffsTable, "staffs");
                ExecuteQuery(conn, createAdminsTable, "admins");
                ExecuteQuery(conn, createSubjecTable, "subject");
                ExecuteQuery(conn, createCourseTable, "course");
                ExecuteQuery(conn, createMarkTable, "mark");
                ExecuteQuery(conn, createExamTable, "exam");
                ExecuteQuery(conn, createRoomTable, "room");
                ExecuteQuery(conn, createTimetable, "timetable");

            }
        }
        private static void ExecuteQuery(SQLiteConnection conn, string query, string tableName)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Table '{tableName}' created successfully.");
            }
        }
    }
}
