using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Companyproduct
    {
        public Companyproduct()
        {
            Producttoadvertises = new HashSet<Producttoadvertise>();
        }

        public int Id { get; set; }
        public int Companyid { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string Productlink { get; set; }
        [JsonIgnore]
        public virtual Company Company { get; set; }
        [JsonIgnore]
        public virtual ICollection<Producttoadvertise> Producttoadvertises { get; set; }
    }
}
