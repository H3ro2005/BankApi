using BankApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BankApi.Data
{
    public class BankService : IBank
    {
        public BankService(MainDBContext context)
        {
            Context = context;
        }

        private readonly MainDBContext Context;

        public async Task<List<BankId>> GetAll()
        {
           var x = await Context.Banks.ToListAsync();
            return x;
        }

        public async Task Add([FromBody] BankId bank)
        {
             await Context.Banks.AddAsync(bank);
            await Context.SaveChangesAsync();   


        }

        public async Task Delete(long id)
        {
          
        
             Context.Banks.Remove(await Context.Banks.FirstOrDefaultAsync(x => x.Id == id));
            await Context.SaveChangesAsync();   

        }
    }

}
