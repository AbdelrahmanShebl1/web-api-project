namespace web_api_project.Models.Services
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAll();

        Product GetById(int id);
        void Update(int id, Product product);

        void Delete(int id);

    }
}
