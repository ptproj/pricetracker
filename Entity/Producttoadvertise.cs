using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Producttoadvertise
    {
        public int Id { get; set; }
        public int Companyproductid { get; set; }
        public int Costumerproductid { get; set; }

        public virtual Companyproduct Companyproduct { get; set; }
        public virtual Costumerproduct Costumerproduct { get; set; }
    }
}
