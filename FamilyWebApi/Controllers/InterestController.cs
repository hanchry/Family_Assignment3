using System;
using System.Threading.Tasks;
using FamilyWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace FamilyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterestController:ControllerBase
    {
        private IInterestReader interestReader;

        public InterestController(IInterestReader interestReader)
        {
            this.interestReader = interestReader;
        }

        [HttpPost]
        [Route("Child/Interest/{childId}")]
        public async Task<ActionResult<Job>> AddInterest([FromRoute] int childId, [FromBody] Interest interestToAdd)
        {
            try
            {
                Interest interest = await interestReader.AddInterestAsync(childId, interestToAdd);
                return Created($"/{childId}", interest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("Child/Interest/{Id}")]
        public async Task<ActionResult> DeleteInterest([FromRoute] int Id)
        {
            try
            {
                await interestReader.RemoveInterestAsync(Id);
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