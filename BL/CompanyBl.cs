using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CompanyBl: ICompanyBl
    {
        ICompanyDl companydl;
        public CompanyBl(ICompanyDl companydl)
        {
            this.companydl = companydl;
        }
     public async Task<Company> post(Company company)
        {
            return await companydl.post(company);
        }
        public async Task<Company> get(string name, string pass)
        {
            return await companydl.get(name, pass);
        }
        public async Task<bool> put(int packageid, int companyid)
        {
            return await companydl.put(packageid, companyid);
        }
    }
}
