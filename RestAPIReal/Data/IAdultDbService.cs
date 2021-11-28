using System.Collections.Generic;
using System.Threading.Tasks;
using LoginExample.Models;
using Models;

namespace RestAPIReal
{
    public interface IAdultDbService
    {
        Task<IList<Adult>> GetAdults();
        Task<IList<Job>> GetJobs();
        Task<IList<User>> GetUsers();
        Task<Adult> AddAdult(Adult adult);

        Task<User> AddUsersToDb(User user);

    }
}