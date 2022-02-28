using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
   public class CostumerDl : ICostumerDl
    {
        PriceTrackerContext _context;
        public CostumerDl( PriceTrackerContext context)
        {
            _context = context;
        }
        public async Task<Costumer> post(Costumer costumer)
        {
           if(await _context.Costumers.SingleOrDefaultAsync(x => x.Email == costumer.Email)!=null)
            {
                throw new Exception("there is a costumer with the same email");
            }
           await _context.Costumers.AddAsync(costumer);
           await  _context.SaveChangesAsync();
            return costumer;
        }

        public async Task<Costumer> get(string email)
        {
           
            return await _context.Costumers.SingleOrDefaultAsync(x => x.Email == email);
        }
        public async Task<bool> getnewpassword(string email,string newpassword,string salt)
        {
            Costumer c1= await _context.Costumers.SingleOrDefaultAsync(x => x.Email == email);
            Costumer c = await _context.Costumers.SingleOrDefaultAsync(x => x.Email == email);
           
            c.Password = newpassword;
            c.Salt = salt;
            _context.Entry(c1).CurrentValues.SetValues(c);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
