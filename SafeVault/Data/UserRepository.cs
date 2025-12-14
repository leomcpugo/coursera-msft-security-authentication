using Microsoft.Data.SqlClient;

public static class UserRepository
{
    private static readonly string ConnectionString =
        "Server=.;Database=SafeVault;Trusted_Connection=True;";

    public static void CreateUser(string username, string email, string password, string role)
    {
        var hash = PasswordHasher.HashPassword(password);

        using var connection = new SqlConnection(ConnectionString);
        using var command = new SqlCommand(
            @"INSERT INTO Users (Username, Email, PasswordHash, Role)
              VALUES (@u, @e, @p, @r)", connection);

        command.Parameters.AddWithValue("@u", username);
        command.Parameters.AddWithValue("@e", email);
        command.Parameters.AddWithValue("@p", hash);
        command.Parameters.AddWithValue("@r", role);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public static (string PasswordHash, string Role)? GetUser(string username)
    {
        using var connection = new SqlConnection(ConnectionString);
        using var command = new SqlCommand(
            "SELECT PasswordHash, Role FROM Users WHERE Username = @u",
            connection);

        command.Parameters.AddWithValue("@u", username);

        connection.Open();
        using var reader = command.ExecuteReader();

        if (!reader.Read())
            return null;

        return (reader.GetString(0), reader.GetString(1));
    }
}
