using System;
using System.Collections.Generic;

namespace eMedPlus.Data.Models
{
    public partial class RatingInfo
    {
        public int RatingId { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
