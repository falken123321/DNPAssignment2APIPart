using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace RestAPIReal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class AdultController : ControllerBase
    {
        private IAdultService adultService = new AdultService();


        [HttpGet]
        public IEnumerable<Adult> Get()
        {
            IList<Adult> adults = adultService.GetAdults().Result;
            return Enumerable.Range(1, adults.Count).Select(index => new Adult
                {
                    JobTitle = new Job
                    {
                        JobTitle = adults[index-1].JobTitle.JobTitle,
                        Salary = adults[index-1].JobTitle.Salary
                    },
                    Id = adults[index-1].Id,
                    FirstName = adults[index-1].FirstName,
                    LastName = adults[index-1].LastName,
                    HairColor = adults[index-1].HairColor,
                    EyeColor = adults[index-1].EyeColor,
                    Age = adults[index-1].Age,
                    Weight = adults[index-1].Weight,
                    Height = adults[index-1].Height,
                    Sex = adults[index-1].Sex,
                })
                .ToArray();
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            try
            {
                Adult added = await adultService.AddAdult(adult);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
            
        
    }
}