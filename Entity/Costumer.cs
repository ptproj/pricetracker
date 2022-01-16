using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Costumer
    {
        public Costumer()
        {
            Costumerproducts = new HashSet<Costumerproduct>();
        }

        public int Id { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [JsonIgnore]
        public virtual ICollection<Costumerproduct> Costumerproducts { get; set; }
    }
}
