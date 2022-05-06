using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web_api_project.Models;
using web_api_project.Models.context;
using web_api_project.Models.Services;

namespace web_api_project.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        private ShopContext context;
        private IProductRepo _ProductService { get; set; }
        public BaseApiController(IProductRepo ProductService, ShopContext shop)
        {
            context = shop;
            _ProductService = ProductService;
        }



        // GET: api/Phones
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_ProductService.GetAll().ToList());
        }

        [HttpPut]
        public IActionResult PutProduct(int id,
           string? Description,
           int? warranty, int? manufacturer, string? name, int? price, int? units)
        {
            var EditedPhone = _ProductService.GetById(id);
            var phone = new Mobile()
            {
             
                Description = Description ?? EditedPhone.Description
                ,
                Warranty = warranty ?? EditedPhone.Warranty,
                ManufacturerID = manufacturer ?? EditedPhone.ManufacturerID,
                Name = name ?? EditedPhone.Name,
                Price = price ?? EditedPhone.Price,
                UnitInStock = units ?? EditedPhone.UnitInStock
            };
            _ProductService.Update(id, phone);
            return Ok();
        }

        // GET: api/Phones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = _ProductService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
        [HttpPost]
        public  IActionResult PostPhone()
        {
            return Ok();
        }



        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _ProductService.Delete(id);
            return Ok();
        }

    }
}