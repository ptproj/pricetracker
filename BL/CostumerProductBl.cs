using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            WebRequest request;
            request = WebRequest.Create("http://127.0.0.1:9007/getprice/?url=" + link);
            WebResponse response = request.GetResponse();
            string responseFromServer = string.Empty;
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);

              
            }
            //טיפול בתשובה שחזרה מהשרת
            response.Close();
            int start=responseFromServer.IndexOf("[");
            int end = responseFromServer.IndexOf("]");
            string priceres=responseFromServer.Substring(start + 1,end-start-1);
            Console.WriteLine(priceres);
            string []pricearr = priceres.Split(",");
            string baseprice;
            costumerproduct.Baseprice = 8;

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
             float pricef=float.Parse(baseprice);
            int price = (int)(pricef);
          costumerproduct.Baseprice = price;
            Console.WriteLine(price);


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

            return await costumerProductdl.post(costumerproduct);

        }
        public void delete(int id)
        {
            costumerProductdl.delete(id);
        }
    }
}
