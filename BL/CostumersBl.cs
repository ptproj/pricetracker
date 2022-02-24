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
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CostumerBl : ICostumerBl
    {
        IPasswordHashHelper _passwordHashHelper;
        ICostumerDl costumerdl;
        IConfiguration _configuration;
        IMapper _mapper;
        public CostumerBl(ICostumerDl costumerdl, IConfiguration configuration, IMapper mapper, IPasswordHashHelper passwordHashHelper)
        {
            _passwordHashHelper = passwordHashHelper;
            this.costumerdl = costumerdl;
            this._mapper = mapper;
            this._configuration = configuration;
        }

        public async Task<DTOLoginCostumer> post(Costumer costumer)
        {
            costumer.Salt = _passwordHashHelper.GenerateSalt(8);
            costumer.Password = _passwordHashHelper.HashPassword(costumer.Password, costumer.Salt, 1000, 8);

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
        public async Task<DTOLoginCostumer> get(string email,string password)
        {
          

            Costumer c=await costumerdl.get(email);

            string Hashedpassword = _passwordHashHelper.HashPassword(password, c.Salt, 1000, 8);

            if (Hashedpassword.Equals(c.Password.TrimEnd())!=true)
                    return null;
                
               

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
        public async Task<bool> getnewpassword(string email)
        {
            Random rnd = new Random();
            int newpassword = rnd.Next(100000, 999999);
            string salt = _passwordHashHelper.GenerateSalt(8);
            string hashedpassword = _passwordHashHelper.HashPassword(newpassword.ToString(), salt, 1000, 8);


            //MailMessage message = new MailMessage();
            //message.From = new MailAddress("212628143@mby.co.il");
            //message.To.Add(new MailAddress("323777862@mby.co.il"));
            ////message.Attachments.Add(new Attachment("M:\\q.jpg"));
            //string mailbody = "youre new password is \n" + newpassword;
            //message.Subject = "massage from pricetracker ";
            //// message.Attachments.Add(new Attachment("M:\\q.jpg"));

            //message.Body = mailbody;
            //message.BodyEncoding = Encoding.UTF8;
            //message.IsBodyHtml = true;
            //SmtpClient client = new SmtpClient("smtp.live.com", 587); //Gmail smtp    
            //System.Net.NetworkCredential basicCredential1 = new
            //System.Net.NetworkCredential("212628143@mby.co.il", "Student@264");
            //client.EnableSsl = true;
            //client.UseDefaultCredentials = false;
            //client.Credentials = basicCredential1;
            //try
            //{
            //    client.Send(message);
            //}

            //catch (Exception ex)
            //{
            //    throw ex;
            //}



            MailMessage message = new MailMessage("212628143@mby.co.il", email);
            string mailbody = "youre new password is \n" + newpassword;
            message.Subject = "massage from pricetracker ";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("212628143@mby.co.il", "Student@264");
            client.Host = "smtp.office365.com";
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await costumerdl.getnewpassword(email, hashedpassword,salt);


        }

    }
}
