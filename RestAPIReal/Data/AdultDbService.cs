using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using LoginExample.Models;
using Models;

namespace RestAPIReal
{
    public class AdultDbService : IAdultDbService
    {
        public async Task<IList<Adult>> GetAdults()
        {
            using var dbContext = new AdultDbContext();
            IList<Adult> adults = dbContext.Adults.ToList();
            return adults;
        }
        public async Task<IList<Job>> GetJobs()
        {
            using var dbContext = new AdultDbContext();
            IList<Job> jobs = dbContext.Jobs.ToList();
            return jobs;
        }
        
        public async Task<IList<User>> GetUsers()
        {
            using var dbContext = new AdultDbContext();
            IList<User> users = dbContext.Users.ToList();
            return users;
        }

        public async Task<Adult> AddAdult(Adult adult)
        {
            using var dbContext = new AdultDbContext();

            await dbContext.Adults.AddAsync(adult);
            await dbContext.SaveChangesAsync();
            return null;
        }

        public async Task<User> AddUsersToDb(User user)
        {
            using var dbContext = new AdultDbContext();

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return null;
        }
    }
}