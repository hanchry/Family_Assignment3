using System;
using System.Threading.Tasks;
using FamilyWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace FamilyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private IAdultReader adultReader;

        public AdultController(IAdultReader adultReader)
        {
            this.adultReader = adultReader;
        }


        [HttpPost]
        [Route("Adult/{streetName}/{houseNumber}")]
        public async Task<ActionResult<Adult>> AddAdult([FromRoute] string streetName, int houseNumber,
            [FromBody] Adult adultToAdd)
        {
            try
            {
                Adult adult = await adultReader.AddAdultAsync(streetName, houseNumber, adultToAdd);
                return Created($"/{streetName} / {houseNumber}", adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("Adult/{Id}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int Id)
        {
            try
            {
                await adultReader.RemoveAdultAsync(Id);
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