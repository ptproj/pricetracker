using Entity;
using System.Threading.Tasks;

namespace DL
{
   public interface ICompanyDl
    {
        public Task<Company> post(Company Company);
        public  Task<Company> get(string name, string pass);
        public Task<bool> put(int packageid, int companyid);
    }
}