using web_api_project.Models.context;

namespace web_api_project.Models.Services
{
    public class ProductRepo : IProductRepo
    {
        ShopContext ShopContext { get; set; }
        public ProductRepo(ShopContext shopContext)
        {
            ShopContext = shopContext;
        }
  
        public IEnumerable<Product> GetAll()
        {
            return ShopContext.Products;
        }

        public Product GetById(int id)
        {
            return ShopContext.Products.Find(id);
        }

        public void Add(Product product)
        {
            ShopContext.Add(product);
            ShopContext.SaveChanges();
        }

        public void Delete(int id)
        {
            ShopContext.Products.Remove(GetById(id));
            ShopContext.SaveChanges();
        }

        public void Update(int id, Product product)
        {
            var Product = ShopContext.Products.Find(id);
            Product.Name= product.Name;
            Product.Description= product.Description;
            Product.Price= product.Price;
            Product.ManufacturerID= product.ManufacturerID;
            Product.UnitInStock= product.UnitInStock;
            Product.Media= product.Media;
            Product.Warranty= product.Warranty;

            ShopContext.SaveChanges();
        }

    }
}
