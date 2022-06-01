using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CostumerProductDl : ICostumerProductDl
    {
        PriceTrackerContext _context;
        public CostumerProductDl(PriceTrackerContext context)
        {
            _context = context;
        }
        public  List<Costumerproduct> get(int Costumerid)
        {
           
            return  _context.Costumerproducts.Where(x => x.Costumerid == Costumerid).ToList();
        }
        public async Task<Costumerproduct> post(Costumerproduct costumerproduct)
        {
            _context.Costumerproducts.Add(costumerproduct);
            await _context.SaveChangesAsync();
            return costumerproduct;
        }
        public void delete(int id)
        {
            Costumerproduct c = _context.Costumerproducts.SingleOrDefault(x => x.Id == id);
            _context.Costumerproducts.Remove(c);
             _context.SaveChanges();
        }
        public async Task put(Costumerproduct costumerproduct)
        {
            Costumerproduct c = await _context.Costumerproducts.FirstOrDefaultAsync(x => x.Id.Equals(costumerproduct.Id));
            if (c == null)
            {

            }
            _context.Entry(c).CurrentValues.SetValues(costumerproduct);
            await _context.SaveChangesAsync();
        }
        

        public List<Costumerproduct> getall() {
            return _context.Costumerproducts.ToList();
        }
        public async Task<string> getemail(int costumerid)
        {
            Costumer c=await _context.Costumers.FirstOrDefaultAsync(x => x.Id.Equals(costumerid));
            return c.Email;
        }
        public List<Companyproduct> findSimilarProduct()
        {

            List<Companyproduct> companyProducts =  _context.Companyproducts.ToList();
            return companyProducts;
        }
    }

}
