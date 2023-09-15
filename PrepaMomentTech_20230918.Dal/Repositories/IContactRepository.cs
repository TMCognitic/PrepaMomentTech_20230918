using PrepaMomentTech_20230918.Dal.Entities;

namespace PrepaMomentTech_20230918.Dal.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Get();
        Contact? Get(int id);
        void Insert(Contact contact);
        void Update(Contact contact);
        void Delete(int id);
    }
}
