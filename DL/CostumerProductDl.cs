using Entity;
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
        public async Task<List<Costumerproduct>> get(int Costumerid)
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
    }

}
