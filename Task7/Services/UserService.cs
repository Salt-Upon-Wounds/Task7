using Microsoft.EntityFrameworkCore;
using Task7.Models;

namespace Task7.Services
{
    public interface IUserService
    {
        public List<UserModel> GetUsers();
        public Task CreateUser(string name);
        Task<UserModel> GetByNameAsync(string name);
        Task<IEnumerable<UserModel>> FindByNameAsync(string? substring);
        
    }
    public class UserService : IUserService
    {
        private readonly ApplicationContext db;

        public UserService(ApplicationContext db)
        {
            this.db = db;
        }

        public List<UserModel> GetUsers()
        {
            return db.Users.ToList();
        }

        public async Task CreateUser(string name)
        {
            db.Users.Add(new UserModel { Name = name });
            await db.SaveChangesAsync();
        }

        public async Task<UserModel> GetByNameAsync(string name) =>
            await db.Users.FirstOrDefaultAsync(x => string.Equals(x.Name, name));

        public async Task<IEnumerable<UserModel>> FindByNameAsync(string? substring)
        {
            if (substring is null)
            {
                return await db.Users.Take(10).ToListAsync();
            }
            return await db.Users.Where(x => x.Name.Contains(substring)).Take(10).ToListAsync();
        }
    }
}

