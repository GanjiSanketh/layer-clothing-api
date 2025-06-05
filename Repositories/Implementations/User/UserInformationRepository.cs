using Npgsql;
using System.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
public class UserInformationRepository : IUserInformationRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    private readonly AppDbContext _context;

    public UserInformationRepository(IConfiguration configuration, AppDbContext context)
    {
        _configuration = configuration;
        _context = context;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<bool> RegisterUserInformation(UserInformation userInformation)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userInformation.Password);

        using var command = new NpgsqlCommand("CALL register_user(@full_name, @mobile_number, @password, @role_id, @status_id, @is_registered)", connection);

        command.Parameters.AddWithValue("@full_name", userInformation.FullName);
        command.Parameters.AddWithValue("@mobile_number", userInformation.MobileNumber);
        command.Parameters.AddWithValue("@password", hashedPassword);
        command.Parameters.AddWithValue("@role_id", userInformation.RoleId);
        command.Parameters.AddWithValue("@status_id", 1);

        var isRegistered = new NpgsqlParameter("@is_registered", NpgsqlTypes.NpgsqlDbType.Boolean)
        {
            Direction = ParameterDirection.Output
        };
        command.Parameters.Add(isRegistered);

        await command.ExecuteNonQueryAsync();
        return (bool)isRegistered.Value;
    }
}
