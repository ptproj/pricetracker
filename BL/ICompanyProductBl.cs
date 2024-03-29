﻿using DTO;
using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICompanyProductBl
    {

        public List<DTOCompanyproduct> get(int companyid);
        public int getcount(int companyid);
        public  Task<Companyproduct> post(Companyproduct companyproduct);

        public Task<bool> delete(int id);
        public Task<Companyproduct> put(Companyproduct companyproduct);
        public void findSimilarProduct(Companyproduct companyproduct);

    }
}