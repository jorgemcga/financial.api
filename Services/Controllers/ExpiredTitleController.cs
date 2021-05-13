using Financial.API.Common.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Financial.API.Services.Model;
using Financial.API.Common.ViewModel;

namespace Financial.API.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpiredTitleController : ControllerBase
    {
        private readonly IExpiredTitleService _service;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        public ExpiredTitleController(IExpiredTitleService service)
        {
            _service = service;
        }

        /// <summary>
        /// Return Expired Titles
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                var response = _service.Get();
                return HttpResponseSuccess(response);
            }
            catch (Exception ex)
            {
                return HttpResponseError(ex);
            }
        }
        
        /// <summary>
        /// New Expired Title
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult Post([FromBody] ExpiredTitleViewModel request)
        {
            try
            {
                var response = _service.Insert(request);
                return HttpResponseSuccess(response);
            }
            catch (Exception ex)
            {
                return HttpResponseError(ex);
            }
        }

        private  ActionResult HttpResponseSuccess(object response)
        {
            return Ok(new HttpResponseSuccess
            {
                Success = true,
                Response = response
            });
        }

        private ActionResult HttpResponseError(Exception exception)
        {
            return new BadRequestObjectResult(new HttpResponseError
            {
                Success = false,
                Message = exception.InnerException != null ? exception.InnerException.Message : exception.Message
            });
        }
    }
}
