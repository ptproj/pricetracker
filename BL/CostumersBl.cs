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
    public class CostumerBl : ICostumerBl
    {
        ICostumerDl costumerdl;
        IConfiguration _configuration;
        IMapper _mapper;
        public CostumerBl(ICostumerDl costumerdl, IConfiguration configuration, IMapper mapper)
        {
            this.costumerdl = costumerdl;
            this._mapper = mapper;
            this._configuration = configuration;
        }

        public async Task<DTOLoginCostumer> post(Costumer costumer)
        {
            Costumer c= await costumerdl.post(costumer);
            DTOLoginCostumer c1 = _mapper.Map<Costumer, DTOLoginCostumer>(c);
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
        public async Task<DTOLoginCostumer> get(string email)
        {
            Costumer c=await costumerdl.get(email);
            DTOLoginCostumer c1 = _mapper.Map<Costumer, DTOLoginCostumer>(c);
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

    }
}
