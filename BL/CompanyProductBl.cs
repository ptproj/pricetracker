using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BL
{
   public class CompanyProductBl: ICompanyProductBl
    {
        ICompanyProductDl companyproductdl;
        public CompanyProductBl(ICompanyProductDl companyproductdl)
        {
            this.companyproductdl = companyproductdl;
        }
        public List<Companyproduct> get(int companyid)
        {
            return companyproductdl.get(companyid);
        }
        public int getcount(int companyid)
        {
            return companyproductdl.getcount(companyid);
        }

        public async Task<Companyproduct> post(Companyproduct companyproduct)
        {
            return await companyproductdl.post(companyproduct);
        }
        public async Task<bool> delete(int id)
        {
           return await companyproductdl.delete(id);
        }
        public async Task<Companyproduct> put(Companyproduct companyproduct)
        {
           return await companyproductdl.put(companyproduct);
        }

        public async void findSimilarProduct(Companyproduct companyproduct)
        {
            List<Costumerproduct> Costumerproduct = companyproductdl.findSimilarProduct();
            List<string> Costumerproduct_desc = new List<string>();
            Costumerproduct.ForEach(Costumerproduct =>
            Costumerproduct_desc.Add(Costumerproduct.Description));
            Costumerproduct_desc.Add(companyproduct.Description);


            //using WebRequest
            WebRequest request;
            request = WebRequest.Create("http://127.0.0.1:9007/startModel");

            //
            request.ContentType = "application/json";
            request.Method = "POST";

            string responseFromServer = string.Empty;
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonSerializer.Serialize(Costumerproduct_desc);

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
