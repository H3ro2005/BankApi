using BankApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Data
{
    public class UserService:IUser
    {
        private readonly MainDBContext Context;

        public UserService(MainDBContext context)
        {
            Context = context;
        }



        public async Task<long> Add(User user)
        {
            var check = await Context.Users.FirstOrDefaultAsync(x => x.email == user.email);
            if ( check == null)
            {
                await Context.Users.AddAsync(user);
                await Context.SaveChangesAsync();
            }
            check = await Context.Users.FirstOrDefaultAsync(x => x.email == user.email);
            return check.Id;

        }

        public async Task Delete(long id)
        {
            Context.Users.Remove(await Context.Users.FirstOrDefaultAsync(x => x.Id == id));
            await Context.SaveChangesAsync();
        }

        public async Task<User> Get(long id)
        {
            var user = await Context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<long> Get(string email, string password)
        {
            var check = await Context.Users.FirstOrDefaultAsync(x => x.email == email);
            if (check == null)
            {
                return 0;
            }
            if (check.Password != password)
            {
                return -1;
            }
            return check.Id;
        }
    }
}
