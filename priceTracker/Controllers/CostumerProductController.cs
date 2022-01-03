using BL;
using Entity;
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
        public async Task<ActionResult<List<Costumerproduct>>> Get(int id)
        {
           
            return await costumerProductbl.get(id);
        }

        // POST api/<CostumerProductController>
        [HttpPost]
        public async Task<Costumerproduct> Post([FromBody] Costumerproduct costumerproduct)
        {
            return await costumerProductbl.post(costumerproduct);
        }

        // PUT api/<CostumerProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<CostumerProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            costumerProductbl.delete(id);
        }
    }
}
