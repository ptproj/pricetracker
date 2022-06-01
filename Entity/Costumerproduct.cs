using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Costumerproduct
    {
        public int Id { get; set; }
        public int Costumerid { get; set; }
        public string Productlink { get; set; }
        public int Baseprice { get; set; }
        public int Finalprice { get; set; }
        public string Description { get; set; }

        public virtual Costumer Costumer { get; set; }
    }
}
