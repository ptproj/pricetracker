using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public  interface IProductToAdvertiseDL
    {
        public Task<List<Companyproduct>> get(int Costumerid);

    }
}