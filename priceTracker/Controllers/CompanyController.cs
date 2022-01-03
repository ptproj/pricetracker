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
    public class CompanyController : ControllerBase
    {
        ICompanyBl companybl;
        public CompanyController(ICompanyBl companybl)
        {
            this.companybl = companybl;
        }
        // GET: api/<CompanyController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<CompanyController>/5
        [HttpGet("{name}/{pass}")]
        public async Task<ActionResult<Company>>Get(string name,string pass)
        {
            Company c= await companybl.get(name,pass);
            if (c!=null)
                return c;
            else return NoContent();
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<Company> Post([FromBody] Company company)
        {
           return await companybl.post(company);

        }

        // PUT api/<CompanyController>/5
        [HttpPut("{packageid}/{companyid}")]
        public async Task<bool> put(int packageid, int companyid)
        {
            return await companybl.put(packageid, companyid);
        }

        // DELETE api/<CompanyController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
