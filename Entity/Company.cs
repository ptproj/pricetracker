﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Company
    {
        public Company()
        {
            Companyproducts = new HashSet<Companyproduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Passward { get; set; }
        public string Companylink { get; set; }
        public int? Packageid { get; set; }
        public DateTime? Startofsubsciption { get; set; }
        public string Salt { get; set; }

        public virtual Package Package { get; set; }
        public virtual ICollection<Companyproduct> Companyproducts { get; set; }
    }
}
