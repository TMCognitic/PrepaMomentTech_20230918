using PrepaMomentTech_20230918.Bll.Entities;
using PrepaMomentTech_20230918.Bll.Mappers;
using PrepaMomentTech_20230918.Bll.Repositories;
using DalContact = PrepaMomentTech_20230918.Dal.Entities.Contact;
using IDalContactRepository = PrepaMomentTech_20230918.Dal.Repositories.IContactRepository;

namespace PrepaMomentTech_20230918.Bll.Services
{
    public class ContactService : IContactRepository
    {
        private readonly IDalContactRepository _dalRepository;

        public ContactService(IDalContactRepository dalRepository)
        {
            _dalRepository = dalRepository;
        }

        public IEnumerable<Contact> Get()
        {
            return _dalRepository.Get().Select(c => c.ToBll());
        }

        public Contact? Get(int id)
        {
            return _dalRepository.Get(id)?.ToBll();
        }

        public void Insert(Contact contact)
        {
            _dalRepository.Insert(contact.ToDal());
        }

        public void Update(int id, Contact contact)
        {
            DalContact contactToUpdate = contact.ToDal();
            contactToUpdate.Id = id;
            _dalRepository.Update(contactToUpdate);
        }

        public void Delete(int id)
        {
            _dalRepository.Delete(id);
        }
    }
}
