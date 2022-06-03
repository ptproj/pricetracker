using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductToAdvertiseBL: IProductToAdvertiseBL
    {

        IProductToAdvertiseDL productToAdvertisedl;
        public ProductToAdvertiseBL(IProductToAdvertiseDL productToAdvertisedl)
        {
            this.productToAdvertisedl = productToAdvertisedl;
        }

        public async Task<List<Companyproduct>> get(int costumerid)
        {
            return await productToAdvertisedl.get(costumerid);
        }
    }
}
