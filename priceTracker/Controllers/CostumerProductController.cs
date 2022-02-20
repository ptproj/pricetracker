using BL;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace priceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CostumerProductController : ControllerBase
    {
        ICostumerProductBl costumerProductbl;
        public CostumerProductController(ICostumerProductBl costumerProductbl)
        {
            this.costumerProductbl = costumerProductbl;
        }
        // GET: api/<CostumerProductController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<CostumerProductController>/5
        [HttpGet("{id}")]
        public  ActionResult<List<Costumerproduct>> Get(int id)
        {
            int c = id;
            List < Costumerproduct > l= costumerProductbl.get(id);
            return l;

        }

        // POST api/<CostumerProductController>
        [HttpPost]
        public async Task<ActionResult<Costumerproduct>> Post([FromBody] Costumerproduct costumerproduct)
        {
            Costumerproduct c=  await costumerProductbl.post(costumerproduct);
            if (c != null)
                return c;
            else return NoContent();
        }

        // PUT api/<CostumerProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<CostumerProductController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            costumerProductbl.delete(id);
            return true;
        }
    }
}
