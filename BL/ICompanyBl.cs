using Entity;
using System.Threading.Tasks;

namespace BL
{
    public interface ICompanyBl
    {
        public Task<Company> post(Company company);
        public  Task<Company> get(string name, string pass);
        public Task<bool> put(int packageid, int companyid);
    }
}