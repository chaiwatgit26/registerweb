using Microsoft.Data.Sqlite;
using RegisterWeb.Models;

namespace RegisterWeb.Repositories
{
    public class PersonRepository
    {
        private readonly string _connectionString;

        public PersonRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' was not found.");
        }

        public int Create(Person person)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            const string sql = """
                INSERT INTO Person
                    (FirstName, LastName, OccupationId)
                VALUES
                    ($firstName, $lastName, $occupationId);

                SELECT last_insert_rowid();
                """;

            using var command = new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue(
                "$firstName",
                person.FirstName);

            command.Parameters.AddWithValue(
                "$lastName",
                person.LastName);

            command.Parameters.AddWithValue(
                "$occupationId",
                person.OccupationId);

            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}