namespace FeedbackApp.Repository
{
    using FeedbackApp.DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRatingRepo
    {
        public List<RatingDTO> GetAll();
        public RatingDTO Get(int id);

        public int Update(int id, int? rating,string comment);

        public int Delete(int id);

        public int Add(int rating,string comment);
    }
}
