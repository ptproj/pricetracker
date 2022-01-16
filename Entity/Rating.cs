using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public string Host { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string Referer { get; set; }
        public string UserAgent { get; set; }
        public DateTime? RecordDate { get; set; }
    }
}
