using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IProductToAdvertiseBL
    {

        public Task<List<Companyproduct>> get(int costumerid);

        public Task Advertise();

    }
}