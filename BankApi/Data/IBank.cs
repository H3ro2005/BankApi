using BankApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Data
{
    public interface IBank
    {
        Task<List<BankId>> GetAll();

        Task Add(BankId bankId);

        Task Delete(long id);
    }
}
