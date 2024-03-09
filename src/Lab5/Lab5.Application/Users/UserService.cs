using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Transactions;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Transactions;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepository userRepository, CurrentUserManager currentUserManager, ITransactionRepository transactionRepository)
    {
        _userRepository = userRepository;
        _currentUserManager = currentUserManager;
        _transactionRepository = transactionRepository;
    }

    public async Task<LoginResult> Login(long userid, long password)
    {
        User? user = await _userRepository.FindUserByUserId(userid);

        if (user is null)
        {
            return new LoginResultNotFound();
        }

        if (user.Password != password)
        {
            return new LoginResultIncorrectPassword();
        }

        _currentUserManager.User = user;
        return new LoginResultSuccess();
    }

    public async Task<TransactionResult> ReceiveMoney(long transactionAmount)
    {
        if (transactionAmount <= 0)
        {
            return new TransactionResultIncorrectMoneyAmount();
        }

        ArgumentNullException.ThrowIfNull(_currentUserManager.User);
        if (_currentUserManager.User.AccountBalance < transactionAmount)
        {
            return new TransactionResultNotEnoughBalance();
        }

        ArgumentNullException.ThrowIfNull(_currentUserManager.User);
        await _userRepository.UpdateAccountBalance(
            _currentUserManager.User.Id,
            _currentUserManager.User.Password,
            _currentUserManager.User.AccountBalance - transactionAmount);

        _currentUserManager.User = _currentUserManager.User with { AccountBalance = _currentUserManager.User.AccountBalance - transactionAmount };

        await _transactionRepository.AddNewTransaction(Guid.NewGuid().ToString(), _currentUserManager.User.Id, -transactionAmount);

        return new TransactionResultSuccess();
    }

    public async Task<TransactionResult> DepositMoney(long transactionAmount)
    {
        if (transactionAmount <= 0)
        {
            return new TransactionResultIncorrectMoneyAmount();
        }

        ArgumentNullException.ThrowIfNull(_currentUserManager.User);
        await _userRepository.UpdateAccountBalance(
            _currentUserManager.User.Id,
            _currentUserManager.User.Password,
            _currentUserManager.User.AccountBalance + transactionAmount);

        _currentUserManager.User = _currentUserManager.User with {
            AccountBalance = _currentUserManager.User.AccountBalance + transactionAmount, };

        await _transactionRepository.AddNewTransaction(Guid.NewGuid().ToString(), _currentUserManager.User.Id, transactionAmount);

        return new TransactionResultSuccess();
    }

    public long CheckBalance()
    {
        ArgumentNullException.ThrowIfNull(_currentUserManager.User);
        return _currentUserManager.User.AccountBalance;
    }

    public Task<IList<Transaction>> GetAllTransactions()
    {
        ArgumentNullException.ThrowIfNull(_currentUserManager.User);
        return _transactionRepository.GetAllUserTransactions(_currentUserManager.User.Id);
    }
}