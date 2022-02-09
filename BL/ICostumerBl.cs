using DTO;
using Entity;
using System.Threading.Tasks;

namespace BL
{
    public interface ICostumerBl
    {
        public Task<DTOLoginCostumer> post(Costumer costumer);
        public Task<DTOLoginCostumer> get(string email);
    }
    
}