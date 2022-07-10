using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
   public class ProductToAdvertiseDL: IProductToAdvertiseDL
    {
        PriceTrackerContext _context;
        public ProductToAdvertiseDL(PriceTrackerContext context)
        {
            _context = context;
        }
        public async Task<List<Producttoadvertise>> get(int Costumerid)
        {
            List<Producttoadvertise> toAdvertise = await _context.Producttoadvertises.Where(c => c.Sentbyemail == false).Include(c => c.Companyproduct).Distinct().ToListAsync();

            //    return all products to advertise that match the costumer id;
            return toAdvertise;
        }
        public async Task<List<Producttoadvertise>> Advertise()
        {
            
            List<Producttoadvertise> toAdvertise = await _context.Producttoadvertises.Where(c => c.Sentbyemail == false).Include(c => c.Companyproduct).Include(c=>c.Costumert).Distinct().ToListAsync();
            return toAdvertise;
        }
        public async Task<bool> put(int productToAdveriseId)
        {
            Producttoadvertise p = await _context.Producttoadvertises.Where(x => x.Id.Equals(productToAdveriseId)).FirstAsync();
            p.Sentbyemail = true;
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
