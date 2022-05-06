using web_api_project.Models.context;

namespace web_api_project.Models.Services
{
    public class PhoneRepo : IPhoneRepo
    {
        ShopContext ShopContext { get; set; }
        public PhoneRepo(ShopContext shopContext)
        {
            ShopContext = shopContext;
        }
        public void Add(Mobile phone)
        {
            ShopContext.Add(phone);
            ShopContext.SaveChanges();
        }

        public void Delete(int id)
        {
            ShopContext.Phones.Remove(GetById(id));
            ShopContext.SaveChanges();
        }

        public IEnumerable<Mobile> GetAll()
        {
            return ShopContext.Phones;
        }

        public Mobile GetById(int id)
        {
            return ShopContext.Phones.Find(id);
        }

        public void Update(int id, Mobile phone)
        {
            var Phone= ShopContext.Phones.Find(id);
            Phone.Name = phone.Name;
            Phone.Manufacturer = phone.Manufacturer;
            Phone.Width=phone.Width;
            Phone.Height=phone.Height;
            Phone.Warranty=phone.Warranty;
            Phone.Ram=phone.Ram;
            Phone.Thickness=phone.Thickness;
            Phone.UnitInStock=phone.UnitInStock;
            Phone.Weight=phone.Weight;
            Phone.Price=phone.Price;
            Phone.OS=phone.OS;
            Phone.Name=phone.Name;
            Phone.GPU=phone.GPU;
            Phone.Description=phone.Description;
            Phone.CPU=phone.CPU;
            Phone.Color=phone.Color;
            ShopContext.SaveChanges();
        }
    }
}
