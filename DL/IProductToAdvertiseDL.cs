using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public  interface IProductToAdvertiseDL
    {
        public Task<List<Companyproduct>> get(int Costumerid);
        public Task<List<Producttoadvertise>> Advertise();
        public Task<bool> put(int productToAdveriseId);



    }
}