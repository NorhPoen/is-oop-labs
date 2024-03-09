using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User?> FindUserByUserId(long userid);
    Task CreateNewUser(long userId, long password, long balance);
    Task UpdateAccountBalance(long userId, long password, long sum);
}