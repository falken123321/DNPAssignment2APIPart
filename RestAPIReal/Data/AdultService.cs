using System.Collections.Generic;
using System.Threading.Tasks;
using FileData;
using Models;

namespace RestAPIReal
{
    public class AdultService : IAdultService
    {
        private readonly FileContext adultsFromJson = new();


        public async Task<IList<Adult>> GetAdults()
        {
            var tmp = new List<Adult>(adultsFromJson.Adults);
            return tmp;
        }

        public async Task<Adult> AddAdult(Adult adult)
        {
            adultsFromJson.Adults.Add(adult);
            adultsFromJson.SaveChanges();
            return adult;
        }
    }
}