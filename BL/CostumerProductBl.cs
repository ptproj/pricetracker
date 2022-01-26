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
    public class CostumerProductBl: ICostumerProductBl
    {
        ICostumerProductDl costumerProductdl;
        public CostumerProductBl(ICostumerProductDl costumerProductdl)
        {
            this.costumerProductdl = costumerProductdl;
        }
        public async Task<List<Costumerproduct>>get(int id)
        {
            return await costumerProductdl.get(id);
        }

        public async Task<Costumerproduct> post(Costumerproduct costumerproduct)
        {

            string link = costumerproduct.Productlink;
            int price = getprice(link);
            costumerproduct.Baseprice = price;
            costumerproduct.Finalprice = price;
            WebRequest request2;
            request2 = WebRequest.Create("http://127.0.0.1:9007/getDesc/?url=" + link);
            WebResponse response2 = request2.GetResponse();
            string responseFromServer2 = string.Empty;
            using (Stream dataStream2 = response2.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader2 = new StreamReader(dataStream2);
                // Read the content.
                responseFromServer2 = reader2.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer2);


            }
            //טיפול בתשובה שחזרה מהשרת
            response2.Close();
            int start2 = responseFromServer2.IndexOf("[");
            int end2 = responseFromServer2.IndexOf("]");
            string desc=responseFromServer2.Substring(start2+2, end2 - start2 - 1);
            costumerproduct.Description = desc;
            return await costumerProductdl.post(costumerproduct);

        }
        public void delete(int id)
        {
            costumerProductdl.delete(id);
        }
        public int getprice(string link)
        {
            
            WebRequest request;
            request = WebRequest.Create("http://127.0.0.1:9007/getprice/?url=" + link);

            WebResponse response = request.GetResponse();
            string responseFromServer = string.Empty;
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                reader.ToString();
                responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);


            }
            //טיפול בתשובה שחזרה מהשרת
            response.Close();
            int start = responseFromServer.IndexOf("[");
            int end = responseFromServer.IndexOf("]");
            string priceres = responseFromServer.Substring(start + 1, end - start - 1);
            Console.WriteLine(priceres);
            string[] pricearr = priceres.Split(",");
            string baseprice;

            if (pricearr.Length == 3)
                baseprice = pricearr[1];
            else if (pricearr.Length == 2)
                baseprice = pricearr[0];
            else if (pricearr.Length == 4)
                baseprice = pricearr[3];
            else
                baseprice = pricearr[0];
            baseprice = baseprice.Trim();
            // int pointon=ba
            float pricef = float.Parse(baseprice);
            int price = (int)(pricef);
            return price;
           

        }
        public async void trackprice()
        {
            List<Costumerproduct> products = costumerProductdl.getall();
            for(int i=0;i<products.Count;i++)
            {
                int price = getprice(products[i].Productlink);
                if (products[i].Finalprice>price)
                {
                    products[i].Finalprice = price;
                    await costumerProductdl.put(products[i]);
                    string costumeremail =await costumerProductdl.getemail(products[i].Costumerid);
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("ourpricetracker@gmail.com");
                    message.To.Add(new MailAddress(costumeremail));
                    //message.Attachments.Add(new Attachment("M:\\q.jpg"));
                    string mailbody = "the product you've been looking at has gone done in price:) \n"+products[i].Productlink;
                    //string link = "<a href= https://localhost:44369/swagger/index.html > enter to match  </a>";
                    message.Subject = "massage from pricetracker ";
                    // message.Attachments.Add(new Attachment("M:\\q.jpg"));

                    message.Body = mailbody;
                    message.BodyEncoding = Encoding.UTF8;
                    message.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient("smtp.live.com", 587); //Gmail smtp    
                    System.Net.NetworkCredential basicCredential1 = new
                    System.Net.NetworkCredential("ourpricetracker@gmail.com", "srv35-3-2");
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = basicCredential1;


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

        }
    }

