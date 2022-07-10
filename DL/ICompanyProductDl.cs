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

        public Task<Companyproduct> put(Companyproduct companyproduct);
        public List<Costumerproduct> findSimilarProduct();

        public Task addProductToAdvertise(int companyProductId, int costumerId);
    }
}