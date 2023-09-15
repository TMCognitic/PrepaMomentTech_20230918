using PrepaMomentTech_20230918.Dal.Entities;
using PrepaMomentTech_20230918.Dal.Mappers;
using PrepaMomentTech_20230918.Dal.Repositories;
using System.Data;
using Tools.Connections;

namespace PrepaMomentTech_20230918.Dal.Services
{
    public class ContactService : IContactRepository
    {
        private readonly IDbConnection _dbConnection;

        public ContactService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Contact> Get()
        {
            _dbConnection.Open();
            return _dbConnection.ExecuteReader("[AppUserSchema].[CSP_AllContacts]", r => r.ToContact(), true, null);
        }

        public Contact? Get(int id)
        {
            _dbConnection.Open();
            return _dbConnection.ExecuteReader("[AppUserSchema].[CSP_ContactById]", r => r.ToContact(), true, new { id }).SingleOrDefault();
        }

        public void Insert(Contact contact)
        {
            _dbConnection.Open();
            _dbConnection.ExecuteNonQuery("[AppUserSchema].[CSP_AddContact]", true, new { contact.Nom, contact.Prenom });
        }

        public void Update(Contact contact)
        {
            _dbConnection.Open();
            _dbConnection.ExecuteNonQuery("[AppUserSchema].[CSP_UpdateContact]", true, new { contact.Id, contact.Nom, contact.Prenom, contact.Actif });
        }

        public void Delete(int id)
        {
            _dbConnection.Open();
            _dbConnection.ExecuteNonQuery("[AppUserSchema].[CSP_DeleteContact]", true, new { id });
        }
    }
}
