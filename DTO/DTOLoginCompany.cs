using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOLoginCompany
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Passward { get; set; }
        public string Companylink { get; set; }
        public int? Packageid { get; set; }
        public DateTime? Startofsubsciption { get; set; }
        [JsonIgnore]
        public virtual Package Package { get; set; }
        [JsonIgnore]
        public virtual ICollection<Companyproduct> Companyproducts { get; set; }
        public string Token { get; set; }

        
    }
}
