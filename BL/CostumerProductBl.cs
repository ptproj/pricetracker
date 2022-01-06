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
           
       
            WebRequest request;
            request = WebRequest.Create("http://127.0.0.1:9007/getprice/?url=" + "https://www.terminalx.com/babyboys/bodysuits-overalls/overalls/z268730004?color=6");
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
       

            return await costumerProductdl.post(costumerproduct);
        }
        public void delete(int id)
        {
            costumerProductdl.delete(id);
        }
    }
}
