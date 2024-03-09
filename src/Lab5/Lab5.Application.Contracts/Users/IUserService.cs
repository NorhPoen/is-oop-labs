using Lab5.Application.Contracts.Transactions;
using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    Task<LoginResult> Login(long userid, long password);
    Task<TransactionResult> ReceiveMoney(long transactionAmount);
    Task<TransactionResult> DepositMoney(long transactionAmount);
    long CheckBalance();
    Task<IList<Transaction>> GetAllTransactions();
}