using System.Data.SQLite;
using System;
using System.IO;
using eIdentificator.Domain.Interfaces;

namespace eIdentificator
{
    public class DatabaseHelper : IDatabaseHelper
    {
        private readonly string _dbFilePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Infrastructure",
            "Persistance",
            "eIdentificatorResources.db"
        );

        public void InitializeDatabase()
        {
            string connectionString = $"Data Source={_dbFilePath}";

            if (!File.Exists($"{_dbFilePath}"))
            {
                File.Create(_dbFilePath).Close();
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string initialQuery = @"
                    CREATE TABLE IF NOT EXISTS Student (
                        StudentId text primary key,
                        Name text not null,
                        Surname text not null,
                        Year text not null,
                        Level text null,
                        Department text null,
                        Identified int not null,
                        Identification_Date text null
                )";

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = initialQuery;
                    command.ExecuteNonQuery();
                }
            }
        }

        public string GetConnectionString()
        {
            return $"Data Source={_dbFilePath}";
        }
    }
}
