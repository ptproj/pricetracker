using AutoMapper;
using DL;
using DTO;
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
    public class CompanyProductBl : ICompanyProductBl
    {
        ICompanyProductDl companyproductdl;
        IMapper _mapper;
        public CompanyProductBl(ICompanyProductDl companyproductdl, IMapper mapper)
        {
            this.companyproductdl = companyproductdl;
            this._mapper = mapper;
        }
        public List<DTOCompanyproduct> get(int companyid)
        {
            var cpLst = companyproductdl.get(companyid);
            var cpDto = _mapper.Map<List<Companyproduct>, List<DTOCompanyproduct>>(cpLst);
            foreach (var cp in cpDto)
            {
                string path = Path.GetFullPath("Images/" + cp.Image);
                var array = File.ReadAllBytes(path);
                cp.ImageContent = Convert.ToBase64String(array, 0, array.Length);
            }
            return cpDto;
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
            Costumerproduct_desc.Add(companyproduct.Description);
            Costumerproduct.ForEach(Costumerproduct =>
            Costumerproduct_desc.Add(Costumerproduct.Description));


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
            int start = responseFromServer.IndexOf("[");
            int end = responseFromServer.IndexOf("]");
            string similarity = responseFromServer.Substring(start + 1, end - start - 1);
            Console.WriteLine(similarity);
            string[] similarityarr = similarity.Split(",");
            bool[] isSimilar = new bool[similarityarr.Length];
            for (int i = 1; i < similarityarr.Length; i++)
            {
                if (similarityarr[i].Contains('7') || similarityarr[i].Contains('8') || similarityarr[i].Contains('9'))
                    isSimilar[i] = true;
            }
            for (int i = 1; i < isSimilar.Length; i++)
            {
                if (isSimilar[i])
                    companyproductdl.addProductToAdvertise(companyproduct.Id,Costumerproduct[i - 1].Costumerid );
            }


        }
    }
}
