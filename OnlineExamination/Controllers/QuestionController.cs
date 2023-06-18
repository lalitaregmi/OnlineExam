using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Service;

namespace OnlineExamination.Controllers
{
    [Route("api/[Controller] "), EnableCors("CorsPolicy")]
    [ApiController]

    public class QuestionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost] //Post annotation  is for create 
        [Route("~/api/admin/question")] // harek controller ko end point farak huna parxa.
        public async Task<dynamic> Question(Question pass) //
        {
            var data = await _unitOfWork.questionservice.Question(pass);
            // iunit of work ma declare gareko property le service ko method(BlogCat) call.
            return Ok(data);
        }




    }
}
