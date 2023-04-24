namespace FeedbackApp.Repository
{
    //using FeedbackApp.Models;
    using DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using eMedPlus.Data.Models;

    public class RatingRepo : IRatingRepo
    {
        #region Properties
        private readonly RatingContext _db;

        #endregion

        #region Constructor
        public RatingRepo(RatingContext db)
        {
            _db = db;
        }
        #endregion
        public List<RatingDTO> GetAll() 
        {
            using (_db)
            {
                List<RatingDTO> x = _db.RatingInfo.Where(x=>x.IsDeleted==false).Select(x => new RatingDTO
                {
                    Comment = x.Comment,
                    Rating = x.Rating,
                    RatingId = x.RatingId
                }).ToList();
                return x;
            }
        }
        public RatingDTO Get(int id) 
        {
            using (_db)
            {
                RatingDTO x = _db.RatingInfo.Where(x => x.RatingId == id && x.IsDeleted==false)
                    .Select
                    (x => new RatingDTO
                    {
                        Comment = x.Comment,
                        Rating = x.Rating,
                        RatingId = x.RatingId
                    }
                    ).FirstOrDefault();

                return x;

            }
        }

        public int Add(int rating,string comment) 
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                RatingInfo x = new RatingInfo();
                x.Rating = rating;
                x.Comment = comment;
                x.IsDeleted = false;
                try
                {
                    _db.Add(x);
                    _db.SaveChanges();
                    transaction.Commit();
                   
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
            return rating; 
        }
        public int Update(int id,int? rating, string comment) { 
            using(var transaction = _db.Database.BeginTransaction())
            {
                RatingInfo x = _db.RatingInfo.Where(x => x.RatingId == id).FirstOrDefault();
                if (rating != null)
                {
                    x.Rating = rating;
                }
                if (comment != null)
                {
                    x.Comment = comment;
                }
                _db.SaveChanges();
                transaction.Commit();
            }
            return id;
        }
        public int Delete(int id) {
            using (var transaction = _db.Database.BeginTransaction())
            {
                RatingInfo x = _db.RatingInfo.Where(x => x.RatingId == id).FirstOrDefault();
                x.IsDeleted = true;
                _db.SaveChanges();
                transaction.Commit();
            }
            return id; 
        }
    }
}
