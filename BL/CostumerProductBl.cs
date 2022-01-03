using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CostumerProductBl: ICostumerProductBl
    {
        ICostumerProductDl costumerProductdl;
        public CostumerProductBl(ICostumerProductDl costumerProductdl)
        {
            this.costumerProductdl = costumerProductdl;
        }
        public async Task<List<Costumerproduct>>get(int id)
        {
            return await costumerProductdl.get(id);
        }
        public async Task<Costumerproduct> post(Costumerproduct costumerproduct)
        {
            return await costumerProductdl.post(costumerproduct);
        }
        public void delete(int id)
        {
            costumerProductdl.delete(id);
        }
    }
}
