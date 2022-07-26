using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public  interface IProductToAdvertiseDL
    {
        public Task<List<Producttoadvertise>> get(int Costumerid);
        public Task<List<Producttoadvertise>> Advertise();
        public Task<bool> put(int productToAdveriseId);



    }
}