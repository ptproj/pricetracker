using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Costumer
    {
        public Costumer()
        {
            Costumerproducts = new HashSet<Costumerproduct>();
            Producttoadvertises = new HashSet<Producttoadvertise>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        [JsonIgnore]
        public virtual ICollection<Costumerproduct> Costumerproducts { get; set; }
        [JsonIgnore]
        public virtual ICollection<Producttoadvertise> Producttoadvertises { get; set; }
    }
}
