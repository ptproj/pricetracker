using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICompanyProductBl
    {

        public  Task<List<Companyproduct>> get(int companyid);
        public int getcount(int companyid);
        public  Task<Companyproduct> post(Companyproduct companyproduct);

        public Task delete(int id);
        public Task put(Companyproduct companyproduct);
    }
}