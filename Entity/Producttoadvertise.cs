using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Producttoadvertise
    {
        public int Id { get; set; }
        public int Companyproductid { get; set; }
        public int Costumertid { get; set; }
        public bool Sentbyemail { get; set; }

        public virtual Companyproduct Companyproduct { get; set; }
        public virtual Costumer Costumert { get; set; }
    }
}
