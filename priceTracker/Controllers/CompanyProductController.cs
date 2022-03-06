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
    public class CompanyProductController : ControllerBase
    {
        ICompanyProductBl companyproductbl;
        public CompanyProductController(ICompanyProductBl companyproductbl)
        {
         this.companyproductbl = companyproductbl;
        }
        // GET: api/<CompanyProductController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<CompanyProductController>/5
        [HttpGet("{companyid}")]
        public ActionResult<List<Companyproduct>> Get(int companyid)
        {
          List<Companyproduct> c= companyproductbl.get(companyid);
            if (c.Count() > 0)
                return c;
            else return new List<Companyproduct>();
             //       NoContent();
        }

        [HttpGet("count/{companyid}")]
        public ActionResult<int> Getcount(int companyid)
        {
            int c = -1;
            c= companyproductbl.getcount(companyid);
            if (c != -1)
                return c;
            else
                return NoContent();
        }

        // POST api/<CompanyProductController>
        [HttpPost]
        public async Task<ActionResult<Companyproduct>> Post([FromBody] Companyproduct companyproduct)
        {
             Companyproduct c=await companyproductbl.post(companyproduct);
            if (c != null)
                return c;
            else return NoContent();
        }

        // PUT api/<CompanyProductController>/5
        [HttpPut]
        public async Task<Companyproduct> Put( [FromBody] Companyproduct companyproduct)
        {
          return await companyproductbl.put(companyproduct);

        }

        // DELETE api/<CompanyProductController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
          await companyproductbl.delete(id);
            return true;

        }
    }
}
