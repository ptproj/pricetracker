using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICostumerProductBl
    {
        public Task<List<Costumerproduct>> get(int id);
        public Task<Costumerproduct> post(Costumerproduct costumerproduct);
        public void delete(int id);
        public  void trackprice();
        
    }
}