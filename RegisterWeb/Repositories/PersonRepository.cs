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
                    (
                        FirstName,
                        LastName,
                        Email,
                        Phone,
                        BirthDate,
                        OccupationId,
                        Sex,
                        Profile
                    )
                VALUES
                    (
                        $firstName,
                        $lastName,
                        $email,
                        $phone,
                        $birthDate,
                        $occupationId,
                        $sex,
                        $profile
                    );

                SELECT last_insert_rowid();
                """;

            using var command = new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue("$firstName", person.FirstName);
            command.Parameters.AddWithValue("$lastName", person.LastName);
            command.Parameters.AddWithValue("$email", person.Email);
            command.Parameters.AddWithValue("$phone", person.Phone);
            command.Parameters.AddWithValue(
                "$birthDate",
                person.BirthDate.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("$occupationId", person.OccupationId);
            command.Parameters.AddWithValue("$sex", person.Sex);
            command.Parameters.AddWithValue("$profile", person.Profile);

            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}