using System;
using System.Threading.Tasks;
using FamilyWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Model;

using System;
using System.Threading.Tasks;
using FamilyWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Model;
namespace FamilyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChildrenController : ControllerBase
    {
        private IChildrenReader childrenReader;

        public ChildrenController(IChildrenReader childrenReader)
        {
            this.childrenReader = childrenReader;
        }
        
        [HttpPost]
        [Route("Child/{streetName}/{houseNumber}")]
        public async Task<ActionResult<Child>> AddChild([FromRoute] string streetName, int houseNumber,
            [FromBody] Child childToAdd)
        {
            try
            {
                Child child = await childrenReader.AddChildAsync(streetName, houseNumber, childToAdd);
                return Created($"/{streetName} / {houseNumber}", child);
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
                await childrenReader.RemoveChildAsync(Id);
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