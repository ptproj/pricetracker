using BL;
using DTO;
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
    public class CustomerController : ControllerBase//test git
    {
        ICostumerBl costumerbl;
        public CustomerController(ICostumerBl costumerbl)
        {
            this.costumerbl = costumerbl;
        }
        // GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<UserController>/5
        [HttpPost("login")]
        
        public async Task<ActionResult<DTOLoginCostumer>> Get([FromBody] DTOLoginCostumer dTOLoginCostumer)
        {

            DTOLoginCostumer c =  await costumerbl.get(dTOLoginCostumer.Email,dTOLoginCostumer.Password);
            if (c != null)
                return c;
            else return NoContent();
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<DTOLoginCostumer>>  Post([FromBody] Costumer costumer)
        {
            DTOLoginCostumer c = await costumerbl.post(costumer);
            if (c != null)
                return c;
            else return NoContent();
        }

        // PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<UserController>/5
        // [HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
