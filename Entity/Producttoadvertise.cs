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
        public int Costumertid { get; set; }
        public bool Sentbyemail { get; set; }
        //[JsonIgnore]
        public virtual Companyproduct Companyproduct { get; set; }
        //[JsonIgnore]
        public virtual Costumer Costumert { get; set; }
        public Producttoadvertise(int Companyproductid,int Costumertid,bool Sentbyemail)
        {
            this.Companyproductid = Companyproductid;
            this.Costumertid = Costumertid;
            this.Sentbyemail = Sentbyemail;
        }
    }
}
