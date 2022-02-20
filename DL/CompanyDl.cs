using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CompanyDl: ICompanyDl
    {
        PriceTrackerContext _context;
        public CompanyDl(PriceTrackerContext context)
        {
            _context = context;
        }
        public async Task<Company> post(Company Company)
        {
            if(await _context.Companies.SingleOrDefaultAsync(x => x.Passward == Company.Passward && x.Name == Company.Name)!=null)
            {
                throw new Exception("there is a company with the same name and password");
            }
            await _context.Companies.AddAsync(Company);
            await _context.SaveChangesAsync();
            return Company;
        }
        public async Task<Company> get(string name)
        {
            return await _context.Companies.FirstOrDefaultAsync(x =>  x.Name==name);
        }
        public async Task<bool> put(int packageid,int companyid)
        {
           
           Company c= await _context.Companies.Where(x=>x.Id.Equals( companyid)).FirstAsync();
            c.Packageid = packageid;
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
