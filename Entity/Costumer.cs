using System;
using System.Collections.Generic;

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

        public virtual ICollection<Costumerproduct> Costumerproducts { get; set; }
        public virtual ICollection<Producttoadvertise> Producttoadvertises { get; set; }
    }
}
