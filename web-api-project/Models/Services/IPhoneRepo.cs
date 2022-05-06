namespace web_api_project.Models.Services
{
    public interface IPhoneRepo
    {
        IEnumerable<Mobile> GetAll();

        Mobile GetById(int id);

        void Add(Mobile phone);

        void Update(int id, Mobile phone);

        void Delete(int id);
    }
}
