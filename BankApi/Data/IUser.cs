using BankApi.Models;

namespace BankApi.Data
{
    public interface IUser
    {
        Task<long> Add(User user);
        Task Delete(long id);
        Task<User> Get(long id);
        Task<long> Get(string email,string password);
    }
}
