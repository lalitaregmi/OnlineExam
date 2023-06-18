using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Service;

namespace OnlineExamination.Controllers
{
    [Route("api/[Controller] "), EnableCors("CorsPolicy")]
    [ApiController]

    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost] //Post annotation  is for create 
        [Route("~/api/admin/course")] // harek controller ko end point farak huna parxa.
        public async Task<dynamic> Course(Course pass) //
        {
            var data = await _unitOfWork.courseservice.Course(pass);
            // iunit of work ma declare gareko property le service ko method(BlogCat) call.
            return Ok(data);
        }


    }
}
