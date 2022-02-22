using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICompanyProductDl
    {
        public List<Companyproduct> get(int companyid);
        public  int getcount(int companyid);
        public Task<Companyproduct> post(Companyproduct companyproduct);

        public  Task<bool> delete(int id);

        public  Task put(Companyproduct companyproduct);
        
    }
}