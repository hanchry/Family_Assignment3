using System;
using System.Threading.Tasks;
using FamilyWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace FamilyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private IPetReader petReader;

        public PetController(IPetReader petReader)
        {
            this.petReader = petReader;
        }

        [HttpPost]
        [Route("Child/Pet/{childId}")]
        public async Task<ActionResult<Pet>> AddChildPet([FromRoute] int childId, [FromBody] Pet petToAdd)
        {
            try
            {
                Pet pet = await petReader.AddPetToChildAsync(childId, petToAdd);
                return Created($"/{childId}", pet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("Pet/{streetName}/{houseNumber}")]
        public async Task<ActionResult<Pet>> AddPetFamily([FromRoute] string streetName, int houseNumber,
            [FromBody] Pet petToAdd)
        {
            try
            {
                Pet pet = await petReader.AddPetToFamilyAsync(streetName, houseNumber, petToAdd);
                return Created($"/{streetName}, {houseNumber}", pet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
                ;
            }
        }

        [HttpDelete]
        [Route("Pet/{Id}")]
        public async Task<ActionResult> DeletePet([FromRoute] int Id)
        {
            try
            {
                await petReader.RemovePetAsync(Id);
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