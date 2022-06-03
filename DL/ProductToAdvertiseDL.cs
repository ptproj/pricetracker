using Entity;
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
        public async Task<List<Companyproduct>> get(int Costumerid)
        {

            //    return all products to advertise that match the costumer id;
            return null;
        }
    }
}
