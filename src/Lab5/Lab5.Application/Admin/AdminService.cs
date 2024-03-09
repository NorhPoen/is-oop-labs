using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Admin;
using Lab5.Application.Models.Transactions;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Admin;

public class AdminService : IAdminService
{
    private const long SystemPassword = 239239;
    private readonly IUserRepository _userRepository;
    private readonly ITransactionRepository _transactionRepository;

    public AdminService(IUserRepository userRepository, ITransactionRepository transactionRepository)
    {
        _userRepository = userRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task<AdminLoginResult> Login(long password)
    {
        if (password != SystemPassword)
        {
            return await Task.FromResult<AdminLoginResult>(new AdminLoginIncorrectPassword());
        }

        return await Task.FromResult<AdminLoginResult>(new AdminLoginSuccess());
    }

    public async Task<AccountCreatingResult> CreateAccount(long userid, long password, long accountBalance = 0)
    {
        User? user = await _userRepository.FindUserByUserId(userid);
        if (user is not null)
        {
            return await Task.FromResult<AccountCreatingResult>(new AccountCreateAlreadyExisting());
        }

        await _userRepository.CreateNewUser(userid, password, 0);
        return await Task.FromResult<AccountCreatingResult>(new AccountCreateSuccess());
    }

    public Task<IList<Transaction>> GetAllTransactions()
    {
        return _transactionRepository.GetAllTransactions();
    }
}