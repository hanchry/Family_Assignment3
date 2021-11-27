using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DataAccess.Database;
using FamilyWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Model;


namespace FamilyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController : ControllerBase
    {
        private IFamilyReader familyReader;


        public FamilyController(IFamilyReader familyReader)
        {
            this.familyReader = familyReader;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetAllFamilies()
        {
            try
            {
                IList<Family> families = await familyReader.GetAllFamiliesAsync();
                string familiesAsJson = JsonSerializer.Serialize(families);
                return Ok(familiesAsJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{streetName}/{houseNumber:int}")]
        public async Task<ActionResult<Family>> GetFamilyAsync(string streetName, int houseNumber)
        {
            try
            {
                Family family = await familyReader.GetFamilyAsync(streetName, houseNumber);
                string familiesAsJson = JsonSerializer.Serialize(family);
                return Ok(familiesAsJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        

        [HttpPost]
        [Route("{newFamily}")]
        public async Task<ActionResult<Family>> AddFamily([FromBody] Family family)
        {
            try
            {
                Family familyAdded = await familyReader.AddFamilyAsync(family);
                return Created($"/{familyAdded.StreetName} / {familyAdded.HouseNumber}", familyAdded);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("Child/{streetName}/{houseNumber}")]
        public async Task<ActionResult<Child>> AddChild([FromRoute] string streetName, int houseNumber,[FromBody] Child childToAdd)
        {
            try
            {
                Child child = await familyReader.AddChildAsync(streetName, houseNumber, childToAdd );
                return Created($"/{streetName} / {houseNumber}", child);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        [Route("PetFamily/{streetName}/{houseNumber}")]
        public async Task<ActionResult<Pet>> AddPetFamily([FromRoute] string streetName, int houseNumber,[FromBody] Pet petToAdd)
        {
            try
            {
                Pet pet = await familyReader.AddPetToFamilyAsync(streetName, houseNumber, petToAdd );
                return Created($"/{streetName}, {houseNumber}", pet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);;
            }
        }
        [HttpPost]
        [Route("PetChild/{childId}")]
        public async Task<ActionResult<Pet>> AddPetChild([FromRoute] int childId,[FromBody] Pet petToAdd)
        {
            try
            {
                Pet pet = await familyReader.AddPetToChildAsync(childId, petToAdd );
                return Created($"/{childId}", pet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500,e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{streetName}/{houseNumber}")]
        public async Task<ActionResult> DeleteFamily([FromRoute] string streetName, int houseNumber)
        {
            try
            {
                Console.WriteLine("Delete method add family");

                await familyReader.RemoveFamilyAsync(streetName, houseNumber);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete]
        [Route("Child/{Id}")]
        public async Task<ActionResult> DeleteChild([FromRoute] int Id)
        {
            try
            {
                await familyReader.RemoveChildAsync(Id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete]
        [Route("Pet/{Id}")]
        public async Task<ActionResult> DeletePet([FromRoute] int Id)
        {
            try
            {
                await familyReader.RemovePetAsync(Id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("Child/{streetName}/{houseNumber}")]
        public async Task<ActionResult<Family>> UpdateChild([FromRoute] string streetName, int houseNumber,[FromBody] Child child)
        {
            try
            {
                await familyReader.UpdateChildAsync(streetName,houseNumber,child);
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