#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api_project.Models;
using web_api_project.Models.context;
using web_api_project.Models.Services;

namespace web_api_project.Controllers
{
    [Route("/Phones")]
    [ApiController]
    public class PhonesController : BaseApiController
    {
        private IPhoneRepo _PhoneService { get; set; }


        public PhonesController(IPhoneRepo PhoneService, ShopContext shopContext, IProductRepo pr) : base(pr,shopContext)
        {
            _PhoneService = PhoneService;
        }

        // GET: api/Phones
        [Route("/Phones/GetAll")]
        [HttpGet]
        public IActionResult GetPhones()
        {
            
            return  Ok(_PhoneService.GetAll().ToList());
        }

        //GET: api/Phones/5
        [Route("/Phones/GetPhone/{id}")]
        [HttpGet]
        public async Task<ActionResult<Mobile>> GetPhone(int id)
        {
            var phone = _PhoneService.GetById(id);
            if (phone == null)
            {
                return NotFound();
            }
            return phone;
        }
        [Route("/Phones/Update/{id}")]
        // PUT: api/Phones/5
        [HttpPut]
        public IActionResult PutPhone(int id, string? ram, string? GPU, string? OS, string? CPU,
            string? Color, float? Width, float? Height, float? Thickness, float? Weight, 
            string? Description,
            int? warranty, int? manufacturer, string? name, int? price, int? units)
        {
            var EditedPhone = _PhoneService.GetById(id);
            var phone=new Mobile()
            {
                Color = Color??EditedPhone.Color ,Width = Width ?? EditedPhone.Width,
                Height = Height ?? EditedPhone.Height,
                Thickness = Thickness ?? EditedPhone.Thickness,
                Weight = Weight ?? EditedPhone.Weight,
                Ram = ram ?? EditedPhone.Ram,
                CPU = CPU ?? EditedPhone.CPU, GPU = GPU ?? EditedPhone.GPU,
                Description = Description ?? EditedPhone.Description
                , Warranty = warranty ?? EditedPhone.Warranty,
                ManufacturerID = manufacturer ?? EditedPhone.ManufacturerID,
                OS = OS ?? EditedPhone.OS,
                Name = name ?? EditedPhone.Name,
                Price = price ?? EditedPhone.Price,
                UnitInStock = units ?? EditedPhone.UnitInStock
            };
            _PhoneService.Update(id, phone);
            return Ok();
        }

        // POST: api/Phones
        [Route("/Phones/AddPhone")]
        [HttpPost]
        public IActionResult PostPhone(string ram, string GPU, string OS, string CPU,
            string Color, float Width, float Height, float Thickness, float Weight, string Description,
            int warranty, int manufacturer, string name, int price, int units)
        {
            var phone = new Mobile() { Color = Color, Width = Width, Height = Height, Thickness = Thickness, 
                Weight = Weight, Ram=ram, CPU=CPU, GPU=GPU, Description=Description, 
                Warranty=warranty, ManufacturerID=manufacturer, OS =OS, Name=name
                , Price=price, UnitInStock=units
            };
            _PhoneService.Add(phone);

            return Ok(phone);
            //return CreatedAtAction("GetPhone", new { id = phone.Id }, phone);
        }

        // DELETE: api/Phones/5
        [Route("/Phones/DeletePhone/{id}")]
        [HttpDelete]
        public IActionResult DeletePhone(int id)
        {
            _PhoneService.Delete(id);
            return Ok();
        }
    }
}
