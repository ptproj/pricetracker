using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICostumerProductDl
    {

        public List<Costumerproduct> get(int id);
        public Task<Costumerproduct> post(Costumerproduct costumerproduct);
        public void delete(int id);
        public Task put(Costumerproduct costumerproduct);
        public Task putAll(List<Costumerproduct> products);
        public List<Costumerproduct> getall();
        public Task<string> getemail(int costumerid);

    }
}