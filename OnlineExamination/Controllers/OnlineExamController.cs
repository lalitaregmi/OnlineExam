using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Service;

namespace OnlineExamination.Controllers
{
    [Route("api/[Controller] "), EnableCors("CorsPolicy")]
    [ApiController]

    public class OnlineExamController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OnlineExamController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]  
        [Route("~/api/online-exam")] 
        public async Task<dynamic> OnlineExamQuestion(OnlineExamQuestion pass)
        {
            var data = await _unitOfWork.onlineexamquestionservice.OnlineExam(pass);
            
            return Ok(data);
        }




    }
}

