using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace RestAPIReal
{
    public interface IAdultService
    {
        Task<IList<Adult>>  GetAdults();
        Task<Adult> AddAdult(Adult adult);
        
       
    }
}