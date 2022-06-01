using DL;
using Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
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
        public  List<Costumerproduct>get(int id)
        {
            return costumerProductdl.get(id);
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
            string desc=responseFromServer2.Substring(start2+2, end2 - start2 - 2);
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
                if (products[i].Finalprice>=price)
                {
                    products[i].Finalprice = price;
                    await costumerProductdl.put(products[i]);
                    string costumeremail =await costumerProductdl.getemail(products[i].Costumerid);
                    MailMessage message = new MailMessage("323777862@mby.co.il", costumeremail);
                    string link = "<a href= products[i].Productlink > products[i].Productlink </a>";
                    string mailbody = "the product you've been looking at has gone done in price:) \n" +" "+ products[i].Productlink;
                    message.Subject = "massage from pricetracker ";
                    message.Body = mailbody;
                    message.BodyEncoding = Encoding.UTF8;
                    message.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient();
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("323777862@mby.co.il", "Student@264");
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
        public async void findSimilarProduct(Costumerproduct costumerproduct)
        {
            List<Companyproduct> Companyproducts = costumerProductdl.findSimilarProduct();
            List<string> Companyproducts_desc = new List<string>();
            Companyproducts.ForEach(companyProduct =>
            Companyproducts_desc.Add(companyProduct.Description));
            Companyproducts_desc.Add(costumerproduct.Description);


            //using WebRequest
            WebRequest request;
            request = WebRequest.Create("http://127.0.0.1:9007/startModel");

            //
            request.ContentType = "application/json";
            request.Method = "POST";
            
            string responseFromServer = string.Empty;
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonSerializer.Serialize(Companyproducts_desc);

                streamWriter.Write(json);
            }
            WebResponse response = request.GetResponse();
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




        }
        }
    }

