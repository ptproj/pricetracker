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
        IPasswordHashHelper _passwordHashHelper;
        ICompanyDl companydl;
        IConfiguration _configuration;
        IMapper _mapper;
        public CompanyBl(ICompanyDl companydl, IConfiguration configuration, IMapper mapper, IPasswordHashHelper passwordHashHelper)
        {
            _passwordHashHelper = passwordHashHelper;
            _mapper = mapper;
            this._configuration = configuration;
            this.companydl = companydl;
        }
     public async Task<DTOLoginCompany> post(Company company)
        {
            company.Salt = _passwordHashHelper.GenerateSalt(8);
            company.Password = _passwordHashHelper.HashPassword(company.Password, company.Salt, 1000, 8);

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
            c1.Password = null;
            return c1;
        }
        public async Task<DTOLoginCompany> get(string name, string password)
        {
            Company c = await companydl.get(name);

            string Hashedpassword = _passwordHashHelper.HashPassword(password, c.Salt, 1000, 8);

            if (Hashedpassword.Equals(c.Password.TrimEnd()) != true)
                return null;


            
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
            c1.Password = null;
            return c1;
        }
        public async Task<bool> put(int packageid, int companyid)
        {
            return await companydl.put(packageid, companyid);
        }
    }
}
