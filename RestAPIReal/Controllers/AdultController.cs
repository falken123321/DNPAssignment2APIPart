using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace RestAPIReal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private readonly IAdultDbService adultDbService = new AdultDbService();

        private AdultDbService _context = new AdultDbService();
        
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> Get()
        {
            try
            {
                IList<Adult> adults = await adultDbService.GetAdults();
                IList<Job> jobs = await adultDbService.GetJobs();
                //Console.WriteLine(adults);
                IList<Adult> v = Enumerable.Range(1, adults.Count).Select(index => new Adult                                                            
    {                                                                                                                                   
        JobTitle = new Job                                                                                                              
        {                                                                                                                               
            JobTitle = jobs[index - 1].JobTitle,                                                                             
            Salary = jobs[index - 1].Salary,                                                                                 
            jobNr = jobs[index - 1].jobNr                                                                                    
        },                                                                                                                              
        Id = adults[index - 1].Id,                                                                                                      
        FirstName = adults[index - 1].FirstName,                                                                                        
        LastName = adults[index - 1].LastName,                                                                                          
        HairColor = adults[index - 1].HairColor,                                                                                        
        EyeColor = adults[index - 1].EyeColor,                                                                                          
        Age = adults[index - 1].Age,                                                                                                    
        Weight = adults[index - 1].Weight,                                                                                              
        Height = adults[index - 1].Height,                                                                                              
        Sex = adults[index - 1].Sex                                                                                                     
    })                                                                                                                                  
    .ToArray();                                                                                                                         
                return Ok(v);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        /*public IEnumerable<Adult> Get()
        {
            try
            {
                var adults = adultDbService.GetAdults().Result;

                IList<Adult> v = Enumerable.Range(1, adults.Count).Select(index => new Adult
                    {
                        JobTitle = new Job
                        {
                            JobTitle = adults[index - 1].JobTitle.JobTitle,
                            Salary = adults[index - 1].JobTitle.Salary,
                            jobNr = adults[index - 1].JobTitle.jobNr
                        },
                        Id = adults[index - 1].Id,
                        FirstName = adults[index - 1].FirstName,
                        LastName = adults[index - 1].LastName,
                        HairColor = adults[index - 1].HairColor,
                        EyeColor = adults[index - 1].EyeColor,
                        Age = adults[index - 1].Age,
                        Weight = adults[index - 1].Weight,
                        Height = adults[index - 1].Height,
                        Sex = adults[index - 1].Sex
                    })
                    .ToArray();
                return Ok(v);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }*/

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            try
            {
                var added = await adultDbService.AddAdult(adult);
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