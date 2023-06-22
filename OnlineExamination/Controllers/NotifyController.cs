using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Service;

namespace OnlineExamination.Controllers
{
    [Route("api/[Controller] "), EnableCors("CorsPolicy")]
    [ApiController]

    public class NotifyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public NotifyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost] //Post annotation  is for create 
        [Route("~/api/notify")] // harek controller ko end point farak huna parxa.
        public async Task<dynamic> Notify(Notify pass) //
        {
            var data = await _unitOfWork.notifyservice.Notify(pass);
            // iunit of work ma declare gareko property le service ko method(BlogCat) call.
            return Ok(data);
        }

    }
}
