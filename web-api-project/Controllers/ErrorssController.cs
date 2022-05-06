using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_project.Errors;
using web_api_project.Models.context;
using web_api_project.Models.Services;

namespace web_api_project.Controllers
{
    [Route("/errors/{code}")]
    [ApiController]
    public class ErrorssController : BaseApiController
        
    {
        public ErrorssController(ShopContext shopContext, IProductRepo pr) : base(pr, shopContext)
        {

            }
        [HttpGet]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}