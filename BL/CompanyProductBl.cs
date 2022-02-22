using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class CompanyProductBl: ICompanyProductBl
    {
        ICompanyProductDl companyproductdl;
        public CompanyProductBl(ICompanyProductDl companyproductdl)
        {
            this.companyproductdl = companyproductdl;
        }
        public List<Companyproduct> get(int companyid)
        {
            return companyproductdl.get(companyid);
        }
        public int getcount(int companyid)
        {
            return companyproductdl.getcount(companyid);
        }

        public async Task<Companyproduct> post(Companyproduct companyproduct)
        {
            return await companyproductdl.post(companyproduct);
        }
        public async Task<bool> delete(int id)
        {
           return await companyproductdl.delete(id);
        }
        public async Task put(Companyproduct companyproduct)
        {
            await companyproductdl.put(companyproduct);
        }


    }
}
