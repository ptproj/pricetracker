using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class CompanyProductDl : ICompanyProductDl
    {
        PriceTrackerContext _context;
        public CompanyProductDl(PriceTrackerContext context)
        {
            _context = context;
        }
        public async Task<List<Companyproduct>> get(int companyid)
        {
            return _context.Companyproducts.Where(x => x.Companyid == companyid).ToList();

        }
        public async Task<Companyproduct> post(Companyproduct companyproduct)
        {
            _context.Companyproducts.Add(companyproduct);
            await _context.SaveChangesAsync();
            return companyproduct;

        }
        public async Task delete(int id)
        {
           Companyproduct c=await _context.Companyproducts.FirstOrDefaultAsync(x => x.Id.Equals(id));
            _context.Remove(c);
            await _context.SaveChangesAsync();
        }
        public async Task put(Companyproduct companyproduct)
        {
            Companyproduct c= await _context.Companyproducts.FirstOrDefaultAsync(x => x.Id.Equals(companyproduct.Id));
            if(c==null)
            {
                
            }
            _context.Entry(c).CurrentValues.SetValues(companyproduct);
            await _context.SaveChangesAsync();
        }


    }
}
