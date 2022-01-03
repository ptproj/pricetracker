using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public  class PackageBl: IPackageBl
    {
        IPackageDl packagedl;
        public PackageBl(IPackageDl packagedl)
        {
            this.packagedl = packagedl;
        }
        public async Task<List<Package>> get()
        {
            return await packagedl.get();
        }
    }
}
