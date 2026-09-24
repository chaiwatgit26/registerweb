using Microsoft.Data.Sqlite;

namespace RegisterWeb.Data
{
    public class Database
    {
        private readonly string _connectionString;
        private readonly string _databaseScriptPath;

        public Database(
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Database connection string is not configured.");

            _databaseScriptPath = Path.Combine(
                environment.ContentRootPath,
                "Data",
                "Database.sql");
        }

        public SqliteConnection CreateConnection()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "PRAGMA foreign_keys = ON;";
            command.ExecuteNonQuery();

            return connection;
        }

        public void Initialize()
        {
            var sql = File.ReadAllText(_databaseScriptPath);

            using var connection = CreateConnection();
            using var command = connection.CreateCommand();

            command.CommandText = sql;
            command.ExecuteNonQuery();
        }
    }
}