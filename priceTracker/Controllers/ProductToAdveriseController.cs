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
    public class ProductToAdveriseController : ControllerBase
    {
        // GET: api/<ProductToAdveriseController>
        [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ProductToAdveriseController>/5
        [HttpGet("{id}")]
        public ActionResult<List<Companyproduct>> Get(int costumerid)
        {

            //return "value";
        }
      
        // POST api/<ProductToAdveriseController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<ProductToAdveriseController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ProductToAdveriseController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
