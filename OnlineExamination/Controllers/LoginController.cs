using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Service;

namespace OnlineExamination.Controllers
{
    [Route("api/[Controller] "), EnableCors("CorsPolicy")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost] //Post annotation  is for create 
        [Route("~/api/login")] // harek controller ko end point farak huna parxa.
        public async Task<dynamic> Login(Login pass) //
        {
            var data = await _unitOfWork.loginservice.Login(pass);
            // iunit of work ma declare gareko property le service ko method(BlogCat) call.
            return Ok(data);
        }


    }


}

