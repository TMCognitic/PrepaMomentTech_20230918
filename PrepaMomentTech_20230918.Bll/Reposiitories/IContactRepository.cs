using PrepaMomentTech_20230918.Bll.Entities;

namespace PrepaMomentTech_20230918.Bll.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Get();
        Contact? Get(int id);
        void Insert(Contact contact);
        void Update(int id, Contact contact);
        void Delete(int id);
    }
}
