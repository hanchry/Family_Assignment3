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

        private FamilyDBContext familyDbContext;

        public FamilyController()
        {
            familyReader = new FileReader();
            familyDbContext = new FamilyDBContext();
        }

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetAllFamilies()
        {
            try
            {
                IList<Family> families = familyDbContext.Families.ToList();
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
                Family family = familyDbContext.Families.FirstOrDefault(f => f.StreetName.Equals(streetName) && f.HouseNumber == houseNumber);
                string familiesAsJson = JsonSerializer.Serialize(family);
                return Ok(familiesAsJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
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

        [HttpPost]
        [Route("{newFamily}")]
        public async Task<ActionResult<Family>> AddFamily([FromBody] Family family)
        {
            try
            {
                Console.WriteLine("Post method add family");
                Family familyAdded = await familyReader.AddFamilyAsync(family);
                return Created($"/{familyAdded.StreetName} / {familyAdded.HouseNumber}", familyAdded);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{streetName}/{streetNumber:int}")]
        public async Task<ActionResult<Family>> UpdateFamily([FromBody] Family family)
        {
            try
            {
                Console.WriteLine("updating family");
                Adult adult1 = new Adult();
                Family updatedFamily = await familyReader.UpdateFamilyAsync(family);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine("catch");
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}