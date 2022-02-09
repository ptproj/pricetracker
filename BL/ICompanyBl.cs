using DTO;
using Entity;
using System.Threading.Tasks;

namespace BL
{
    public interface ICompanyBl
    {
        public Task<DTOLoginCompany> post(Company company);
        public  Task<DTOLoginCompany> get(string name, string pass);
        public Task<bool> put(int packageid, int companyid);
    }
}