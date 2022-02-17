using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Producttoadvertise
    {
        public int Id { get; set; }
        public int Companyproductid { get; set; }
        public int Costumerproductid { get; set; }
        [JsonIgnore]
        public virtual Companyproduct Companyproduct { get; set; }
        [JsonIgnore]
        public virtual Costumerproduct Costumerproduct { get; set; }
    }
}
