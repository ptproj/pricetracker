using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Package
    {
        public Package()
        {
            Companies = new HashSet<Company>();
        }

        public int Id { get; set; }
        public int Productsamount { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        [JsonIgnore]
        public virtual ICollection<Company> Companies { get; set; }
    }
}
