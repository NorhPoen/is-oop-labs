using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Contracts.Admin;

public interface IAdminService
{
    Task<AdminLoginResult> Login(long password);
    Task<AccountCreatingResult> CreateAccount(long userid, long password, long accountBalance = 0);
    Task<IList<Transaction>> GetAllTransactions();
}