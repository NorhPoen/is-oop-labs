using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Users;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> FindUserByUserId(long userid)
    {
        const string sql = """
               select user_id, user_password, account_balance
               from users
               where user_id = @userid;
               """;

        ArgumentNullException.ThrowIfNull(_connectionProvider);
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userid", userid);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync() is false)
        {
            return null;
        }

        return new User(
            Id: reader.GetInt32(0),
            Password: reader.GetInt32(1),
            AccountBalance: reader.GetInt32(2));
    }

    public async Task UpdateAccountBalance(long userId, long password, long sum)
    {
        const string sql = """
           UPDATE users
           SET account_balance = @sum
           Where user_id = @user_id
           """;

        ArgumentNullException.ThrowIfNull(_connectionProvider);
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userId", userId)
            .AddParameter("password", password)
            .AddParameter("sum", sum);

        await command.ExecuteNonQueryAsync();
    }

    public async Task CreateNewUser(long userId, long password, long balance)
    {
        const string sql = @"
           INSERT INTO users (user_id, user_password, account_balance)
           VALUES (@userId, @password, @balance)
           ";

        ArgumentNullException.ThrowIfNull(_connectionProvider);
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userId", userId)
            .AddParameter("password", password)
            .AddParameter("balance", balance);

        await command.ExecuteNonQueryAsync();
    }
}