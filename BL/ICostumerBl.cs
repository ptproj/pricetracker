using Entity;
using System.Threading.Tasks;

namespace BL
{
    public interface ICostumerBl
    {
        public Task<Costumer> post(Costumer _costumer);
        public Task<Costumer> get(string email);
    }
    
}