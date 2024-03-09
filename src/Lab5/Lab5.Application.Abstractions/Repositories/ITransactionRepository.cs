using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Abstractions.Repositories;

public interface ITransactionRepository
{
    Task<IList<Transaction>> GetAllTransactions();
    Task<IList<Transaction>> GetAllUserTransactions(long userId);
    Task AddNewTransaction(string transactionId, long userId, long transactionAmount);
}