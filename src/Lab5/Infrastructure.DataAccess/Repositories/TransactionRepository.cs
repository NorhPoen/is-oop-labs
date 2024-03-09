using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Transactions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<IList<Transaction>> GetAllTransactions()
    {
        var allTransactions = new List<Transaction>();
        const string sql = """
           select transaction_id, user_id, transaction_amount
           from transactions
           """;

        ArgumentNullException.ThrowIfNull(_connectionProvider);
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using var command = new NpgsqlCommand(sql, connection);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            allTransactions.Add(new Transaction(
                reader.GetString(0),
                reader.GetInt64(1),
                reader.GetInt64(2)));
        }

        return allTransactions;
    }

    public async Task<IList<Transaction>> GetAllUserTransactions(long userId)
    {
        var allTransactions = new List<Transaction>();
        const string sql = """
                           select transaction_id, user_id, transaction_amount
                           from transactions
                           where user_id = @userId;
                           """;

        ArgumentNullException.ThrowIfNull(_connectionProvider);
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userId", userId);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            allTransactions.Add(new Transaction(
                reader.GetString(0),
                reader.GetInt64(1),
                reader.GetInt64(2)));
        }

        return allTransactions;
    }

    public async Task AddNewTransaction(string transactionId, long userId, long transactionAmount)
    {
        const string sql = """
           INSERT INTO transactions (transaction_id, user_id, transaction_amount)
           VALUES (@transactionId, @userId, @transactionAmount)
           """;

        ArgumentNullException.ThrowIfNull(_connectionProvider);
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("transactionId", transactionId);
        command.AddParameter("userId", userId);
        command.AddParameter("transactionAmount", transactionAmount);

        await command.ExecuteNonQueryAsync();
    }
}