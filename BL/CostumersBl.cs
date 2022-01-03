using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CostumerBl : ICostumerBl
    {
        ICostumerDl costumerdl;
        public CostumerBl(ICostumerDl costumerdl)
        {
            this.costumerdl = costumerdl;
        }

        public async Task<Costumer> post(Costumer costumer)
        {
            return await costumerdl.post(costumer);
        }
        public async Task<Costumer> get(string email)
        {
            return await costumerdl.get(email);
        }

    }
}
