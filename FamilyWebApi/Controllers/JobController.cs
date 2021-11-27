using System;
using System.Threading.Tasks;
using FamilyWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace FamilyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController :ControllerBase
    {
        private IJobReader jobReader;

        public JobController(IJobReader jobReader)
        {
            this.jobReader = jobReader;
        }


        [HttpPost]
        [Route("Adult/Job/{adultId}")]
        public async Task<ActionResult<Job>> AddJob([FromRoute] int adultId, [FromBody] Job jobToAdd)
        {
            try
            {
                Job job = await jobReader.AddJobAsync(adultId, jobToAdd);
                return Created($"/{adultId}", job);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        
        [HttpDelete]
        [Route("Adult/Job/{Id}")]
        public async Task<ActionResult> DeleteJob([FromRoute] int Id)
        {
            try
            {
                await jobReader.RemoveJobAsync(Id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}