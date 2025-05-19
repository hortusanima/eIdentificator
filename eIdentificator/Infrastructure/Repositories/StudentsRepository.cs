using eIdentificator.Domain;
using eIdentificator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace eIdentificator.Infrastructure.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly IDatabaseHelper _databaseHelper;
        private readonly string _connectionString;
        public StudentsRepository(IDatabaseHelper databaseHelper) 
        { 
            _databaseHelper = databaseHelper;
            _connectionString = _databaseHelper
                .GetConnectionString();
        }

        public List<Student> GetAllStudentsByFilters(
            string key, 
            string year, 
            string level, 
            string department
        )
        {
            string polishedKey = key.ToLower().Trim().Replace(" ", "");

            List<Student> students = new List<Student>();
            using (SQLiteConnection connection = 
                new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT DISTINCT 
                        StudentId, 
                        Name, 
                        Surname, 
                        Year, 
                        Level, 
                        Department, 
                        Identified, 
                        Identification_Date 
                    FROM Student
                    WHERE
                    (
                        StudentId COLLATE NOCASE LIKE @Key || '%' OR
                        StudentId COLLATE NOCASE LIKE @Key || '/%' OR
                        StudentId COLLATE NOCASE LIKE @Key || ' %' OR

                        Name COLLATE NOCASE LIKE '%' || @Key || '%' OR

                        Surname COLLATE NOCASE LIKE '%' || @Key || '%' OR

                        (Name || Surname) COLLATE NOCASE LIKE '%' || @Key || '%' OR
                        (Surname || Name) COLLATE NOCASE LIKE '%' || @Key || '%'
                    )";

                if (!string.Equals(
                    year.Trim(), 
                    "All", 
                    StringComparison.OrdinalIgnoreCase
                ))
                {
                    query += " AND Year = @Year";
                }

                if (!string.Equals(
                    level.Trim(), 
                    "All", 
                    StringComparison.OrdinalIgnoreCase
                ))
                {
                    query += " AND Level = @Level";
                }

                if (!string.Equals(
                    department.Trim(), 
                    "All", 
                    StringComparison.OrdinalIgnoreCase
                ))
                {
                    query += " AND Department = @Department";
                }

                using (SQLiteCommand command = 
                    new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Key", polishedKey);
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@Level", level);
                    command.Parameters.AddWithValue("@Department", department);

                    using (SQLiteDataReader reader = 
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                StudentId = reader["StudentId"].ToString(),
                                Name = reader["Name"].ToString(),
                                Surname = reader["Surname"].ToString(),
                                Year = reader["Year"].ToString(),
                                Level = reader["Level"].ToString(),
                                Department = reader["Department"].ToString(),
                                Identified = Convert.ToBoolean(reader["Identified"]),
                                Identification_Date = string
                                    .IsNullOrEmpty(reader["Identification_Date"].ToString())
                                ? (DateTime?)null
                                : DateTime.Parse(reader["Identification_Date"].ToString())
                            };

                            students.Add(student);
                        }
                    }
                }
                connection.Close();
                return students;
            }
        }

        public List<Student> GetIdentifiedStudents()
        {
            List<Student> students = new List<Student>();
            using (SQLiteConnection connection = 
                new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT DISTINCT " +
                    "StudentId, " +
                    "Name, " +
                    "Surname, " +
                    "Year, " +
                    "Level, " +
                    "Department, " +
                    "Identified, " +
                    "Identification_Date" +
                    " FROM Student " +
                    "WHERE Identified = true";

                using (SQLiteCommand command = 
                    new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = 
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                StudentId = reader["StudentId"].ToString(),
                                Name = reader["Name"].ToString(),
                                Surname = reader["Surname"].ToString(),
                                Year = reader["Year"].ToString(),
                                Level = reader["Level"].ToString(),
                                Department = reader["Department"].ToString(),
                                Identified = Convert.ToBoolean(reader["Identified"]),
                                Identification_Date = string
                                    .IsNullOrEmpty(reader["Identification_Date"].ToString())
                                ? (DateTime?)null
                                : DateTime.Parse(reader["Identification_Date"].ToString())
                            };

                            students.Add(student);
                        }
                    }
                }
                connection.Close();
                return students;
            }
        }

        public int GetCountOfAllStudents()
        {
            using (SQLiteConnection connection = 
                new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) " +
                    "" +
                    "FROM Student";

                int count;
                using (SQLiteCommand command = 
                    new SQLiteCommand(query, connection))
                {
                    count = Convert
                        .ToInt32(command.ExecuteScalar());
                }

                connection.Close();
                return count;
            }
        }

        public int GetCountOfStudentsByIdentifiedValue(
            bool isIdentified, 
            string level
        )
        {
            using (SQLiteConnection connection = 
                new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) " +
                    "FROM Student " +
                    "WHERE Identified = @Identified";

                if (!string.IsNullOrEmpty(level))
                {
                    query += " AND Level = @Level";
                }

                int count;
                using (SQLiteCommand command = 
                    new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Identified", isIdentified);
                    command.Parameters.AddWithValue("@Level", level);
                    count = Convert.ToInt32(command.ExecuteScalar());
                }

                connection.Close();
                return count;
            }
        }

        public List<string> GetStudentDistinctFieldValues(
            string field, 
            string referenceField, 
            string referenceValue
        )
        {
            List<string> values = new List<string>();
            using (SQLiteConnection connection = 
                new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = $"SELECT DISTINCT {field} " +
                    "FROM Student";

                if (!string.Equals(
                    referenceValue, 
                    "All", 
                    StringComparison.OrdinalIgnoreCase
                ))
                {
                    query += $" WHERE {referenceField} = @Reference";
                }

                using (SQLiteCommand command = new 
                    SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Reference", referenceValue);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                values.Add(reader.GetString(0));
                            }
                        }
                    }
                }

                connection.Close();
                return values;
            }
        }

        public void UpdateStudentIdentifiedField(
            string index, 
            bool isIdentified
        )
        {
            using (SQLiteConnection connection = 
                new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE Student " +
                    "SET Identified=@Identified, " +
                    "Identification_Date=@Identification_Date " +
                    "WHERE StudentId=@StudentId";

                using (SQLiteCommand command = 
                    new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", index);
                    command.Parameters.AddWithValue("@Identified", isIdentified);
                    if (isIdentified)
                    {
                        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        command.Parameters.AddWithValue("@Identification_Date", date);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Identification_Date", null);
                    }
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void ResetStudentFieldValues(bool isForced)
        {
            using (SQLiteConnection connection = 
                new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE Student " +
                               "SET Identified = @Identified, " +
                               "Identification_Date = NULL";

                if (!isForced)
                {
                    query += " WHERE DATE(Identification_Date) != " +
                        "DATE(@Identification_Date)";
                }

                using (SQLiteCommand command = 
                    new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Identified", false);
                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    command.Parameters.AddWithValue("@Identification_Date", date);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
