using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext context;
        public DatingRepository(DataContext context)
        {
            this.context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public async Task<User> GetUser(int ID)
        {
            return await context.Users.Include(c=>c.Photos).FirstOrDefaultAsync(x=>x.ID == ID);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await context.Users.Include(c=>c.Photos).ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}