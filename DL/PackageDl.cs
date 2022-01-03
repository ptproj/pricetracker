using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
   public class PackageDl: IPackageDl
    {
        PriceTrackerContext _context;
        ILogger<PackageDl> logger;
        public PackageDl(PriceTrackerContext context, ILogger<PackageDl> logger)
        {
            _context = context;
            this.logger = logger;
        }
        public async Task<List<Package>> get()
        {
            try
            {
             return await _context.Packages.ToListAsync();
            }
            catch (Exception ex){
                logger.LogError(ex.Message);
                    }
            return null;
        }


    }
}
