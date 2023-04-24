namespace FeedbackApp.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RatingDTO
    {
        public int? RatingId { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
    }
}
