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
        public Task<List<Companyproduct>> Get(int companyid)
        {
            return companyproductbl.get(companyid);
        }

        [HttpGet("count/{companyid}")]
        public int Getcount(int companyid)
        {
            return companyproductbl.getcount(companyid);
        }

        // POST api/<CompanyProductController>
        [HttpPost]
        public Task<Companyproduct> Post([FromBody] Companyproduct companyproduct)
        {
            return companyproductbl.post(companyproduct);
        }

        // PUT api/<CompanyProductController>/5
        [HttpPut]
        public async Task Put( [FromBody] Companyproduct companyproduct)
        {
            await companyproductbl.put(companyproduct);

        }

        // DELETE api/<CompanyProductController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await companyproductbl.delete(id);

        }
    }
}/////tttttttkkkk
