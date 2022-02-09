using AutoMapper;
using DL;
using DTO;
using Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CompanyBl: ICompanyBl
    {
        ICompanyDl companydl;
        IConfiguration _configuration;
        IMapper _mapper;
        public CompanyBl(ICompanyDl companydl, IConfiguration configuration, IMapper mapper)
        {
            _mapper = mapper;
            this._configuration = configuration;
            this.companydl = companydl;
        }
     public async Task<DTOLoginCompany> post(Company company)
        {
            Company c = await companydl.post(company);
            DTOLoginCompany c1 = _mapper.Map<Company, DTOLoginCompany>(c);
            if (c == null) return null;
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, c.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            c1.Token = tokenHandler.WriteToken(token);
            c1.Passward = null;
            return c1;
        }
        public async Task<DTOLoginCompany> get(string name, string pass)
        {
           Company c= await companydl.get(name, pass);
            DTOLoginCompany c1=_mapper.Map<Company,DTOLoginCompany>(c);
            if (c == null) return null;
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, c.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            c1.Token = tokenHandler.WriteToken(token);
            c1.Passward = null;
            return c1;
        }
        public async Task<bool> put(int packageid, int companyid)
        {
            return await companydl.put(packageid, companyid);
        }
    }
}
