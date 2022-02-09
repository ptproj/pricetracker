using AutoMapper;
using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace priceTracker
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Company, DTOLoginCompany>();
            CreateMap<Costumer, DTOLoginCostumer>();

        }
        

    }
}
