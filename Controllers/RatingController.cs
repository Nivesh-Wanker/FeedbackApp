namespace FeedbackApp.Controllers
{
    using FeedbackApp.DTO;
    using FeedbackApp.InputModel;
    using FeedbackApp.Repository;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    [Route("[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepo _ratingRepo;

        #region Constructor
        public RatingController(IRatingRepo ratingRepo)
        {
            _ratingRepo = ratingRepo;
        }
        #endregion

        [HttpGet("GetAll")]
        public List<RatingDTO> GetAll()
        {
            List<RatingDTO> response = _ratingRepo.GetAll();
            return response;
        }

        [HttpGet("Get/{id}")]
        public RatingDTO Get(int id)
        {
            RatingDTO response = _ratingRepo.Get(id);
            return response;
        }

        [HttpPost("Add")]
        public int Add(RatingModel model)
        {
            int response = _ratingRepo.Add(model.Rating,model.Comment);
            return response;
        }

        [HttpPut("Update")]
        public int Update(UpdateModel model)
        {
            int response = _ratingRepo.Update(model.id,model.Rating,model.Comment);
            return response;
        }

        [HttpDelete("Delete")]
        public int Delete([FromQuery]int id)
        {
            int response = _ratingRepo.Delete(id);
            return response;
        }
    }
}
