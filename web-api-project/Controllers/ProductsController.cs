using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_project.Models;
using web_api_project.Models.context;
using web_api_project.Models.Services;

namespace web_api_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
    {
        private IProductRepo _ProductService { get; set; }


        public ProductsController(IProductRepo ProductService , ShopContext shopContext, IProductRepo pr) : base(pr, shopContext)
        {
            _ProductService = ProductService;
        }

        // GET: api/Phones
        [HttpGet]
        public IActionResult GetPhones()
        {
            return Ok(_ProductService.GetAll().ToList());
        }

        // GET: api/Phones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetPhone(int id)
        {
            var product = _ProductService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }


    }
}
