using AutoMapper;
using BL;
using Entity;
using DTO;
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
    public class CompanyController : ControllerBase
    {
        ICompanyBl companybl;
        IMapper _mapper;
        public CompanyController(ICompanyBl companybl, IMapper mapper)
        {
            this.companybl = companybl;
            this._mapper = mapper;
        }
        // GET: api/<CompanyController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<CompanyController>/5
        [HttpPost("login")]
        public async Task<ActionResult<DTOLoginCompany>>Get([FromBody] DTOLoginCompany dTOLoginCompany)
        {
            DTOLoginCompany c= await companybl.get(dTOLoginCompany.Name, dTOLoginCompany.Passward);
            
            if (c!=null)
                return c;
            else return NoContent();
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<ActionResult<DTOLoginCompany>> Post([FromBody] Company company)
        {
            DTOLoginCompany c =await companybl.post(company);
            if (c != null)
                return c;
            else return NoContent();
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{packageid}/{companyid}")]
        [Authorize]

        public async Task<bool> put(int packageid, int companyid)
        {
            String name=HttpContext.User.Identity.Name;


            return await companybl.put(packageid, companyid);
        }

        // DELETE api/<CompanyController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
