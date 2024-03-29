﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class CompanyProductDl : ICompanyProductDl
    {
        PriceTrackerContext _context;
        public CompanyProductDl(PriceTrackerContext context)
        {
            _context = context;
        }
        public List<Companyproduct> get(int companyid)
        {
            
            return _context.Companyproducts.Where(x => x.Companyid == companyid).ToList();
        
        }
        public int getcount(int companyid)
        {
            int count = _context.Companyproducts.Where(x => x.Companyid == companyid).Count();
            try
            {
                int Packageid = (int)_context.Companies.Where(x => x.Id == companyid).FirstOrDefault().Packageid;
                int numproductsamount = _context.Packages.Where(x => x.Id == Packageid).FirstOrDefault().Productsamount;
                return numproductsamount - count;
            }
            catch (Exception ex) {
                return(-1);
            };
        }
        public async Task<Companyproduct> post(Companyproduct companyproduct)
        {
            try { 
            int count = _context.Companyproducts.Where(x => x.Companyid == companyproduct.Companyid&&x.Active==true).Count();
            int Packageid = (int)_context.Companies.Where(x => x.Id == companyproduct.Companyid).FirstOrDefault().Packageid;
            int numproductsamount = _context.Packages.Where(x => x.Id == Packageid).FirstOrDefault().Productsamount;
            if(count< numproductsamount)
            {
                _context.Companyproducts.Add(companyproduct);
                await _context.SaveChangesAsync();
                return companyproduct;

            }
            throw new Exception("you passed your numproductsamount.");
                }
            catch { return null; }
        }
        public async Task<bool> delete(int id)
        {
           Companyproduct c=await _context.Companyproducts.FirstOrDefaultAsync(x => x.Id.Equals(id));
            _context.Remove(c);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Companyproduct> put(Companyproduct companyproduct)
        {
            Companyproduct c= await _context.Companyproducts.FirstOrDefaultAsync(x => x.Id.Equals(companyproduct.Id));
            if(c==null)
            {
                
            }
            _context.Entry(c).CurrentValues.SetValues(companyproduct);
            await _context.SaveChangesAsync();
            return companyproduct;
        }
        public List<Costumerproduct> findSimilarProduct()
        {

            List<Costumerproduct> costumerProduct = _context.Costumerproducts.ToList();
            return costumerProduct;
        }
        public async Task addProductToAdvertise(int companyProductId, int costumerId)
        {
            await _context.Producttoadvertises.AddAsync(new Producttoadvertise(companyProductId, costumerId, false));
        }


    }
}
