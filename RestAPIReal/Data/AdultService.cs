using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using FileData;
using Models;

namespace RestAPIReal
{
    public class AdultService : IAdultService
    {
        FileContext adultsFromJson = new FileContext();
        
        
        
        public async Task<IList<Adult>> GetAdults()
        {
            List<Adult> tmp = new List<Adult>(adultsFromJson.Adults);
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