using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductToAdvertiseBL: IProductToAdvertiseBL
    {

        IProductToAdvertiseDL productToAdvertisedl;
        public ProductToAdvertiseBL(IProductToAdvertiseDL productToAdvertisedl)
        {
            this.productToAdvertisedl = productToAdvertisedl;
        }

        public async Task<List<Producttoadvertise>> get(int costumerid)
        {
            return await productToAdvertisedl.get(costumerid);
        }
        public async Task Advertise()
        {
            List<Producttoadvertise> toAdvertise = await productToAdvertisedl.Advertise();
            List<int> costumers=new List<int>();
            for(int i=0;i<toAdvertise.Count; i++)
            {
                if (costumers.Contains(toAdvertise[i].Costumertid)==false)
                    SentEmail(toAdvertise[i].Companyproduct,toAdvertise[i].Costumert.Email);
                costumers.Add(toAdvertise[i].Costumertid);
                productToAdvertisedl.put(toAdvertise[i].Id);
            }

        }
        public void SentEmail(Companyproduct toAdvertise,string email)
        {
            MailMessage message = new MailMessage("212628143@mby.co.il", email);
            string mailbody ="we have a similar product for you!!!!:)"+toAdvertise.Productlink+'\n'+"that costs "+toAdvertise.Price;
            message.Subject = "massage from pricetracker ";
            string imagePath =Path.GetFullPath("Images/" +toAdvertise.Image);
            message.Attachments.Add(new Attachment(imagePath));
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
        }

        
    }
}
