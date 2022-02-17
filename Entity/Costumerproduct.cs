using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Costumerproduct
    {
        public Costumerproduct()
        {
            Producttoadvertises = new HashSet<Producttoadvertise>();
        }

        public int Id { get; set; }
        public int Costumerid { get; set; }
        public string Productlink { get; set; }
        public int Baseprice { get; set; }
        public int Finalprice { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual Costumer Costumer { get; set; }
        [JsonIgnore]
        public virtual ICollection<Producttoadvertise> Producttoadvertises { get; set; }
    }
}
