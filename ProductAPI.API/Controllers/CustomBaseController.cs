using Microsoft.AspNetCore.Mvc;
using ProductAPI.Application.Results;
using System.Net;

namespace ProductAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ServiceResult<T> result)
        {
            return result.Status switch
            {
                HttpStatusCode.NoContent => NoContent(),
                HttpStatusCode.Created => Created(result.UrlAsCreated, result.Data),
                _ => new ObjectResult(result) { StatusCode = (int)result.Status }
            };
        }

        [NonAction]
        public IActionResult CreateActionResult(ServiceResult result)
        {
            return result.Status switch
            {
                HttpStatusCode.NoContent => NoContent(),
                _ => new ObjectResult(result) { StatusCode = (int)result.Status }
            };
        }
    }
}
