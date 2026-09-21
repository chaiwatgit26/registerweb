using Microsoft.Data.Sqlite;
using RegisterWeb.Models;

namespace RegisterWeb.Repositories
{
    public class OccupationRepository
    {
        private readonly string _connectionString;

        public OccupationRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' was not found.");
        }

        public List<Occupation> GetAll()
        {
            var occupations = new List<Occupation>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            const string sql = """
                SELECT Id, Name
                FROM Occupation
                ORDER BY Id;
                """;

            using var command = new SqliteCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                occupations.Add(new Occupation
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }

            return occupations;
        }
    }
}