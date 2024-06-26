using AutoMapper;
using ContactManagement.API.DataAccess.Entities;
using ContactManagement.API.DataAccess.Repositories;
using ContactManagement.API.Models.Core;
using ContactManagement.API.Models.Request;
using ContactManagement.API.Models.Response;

namespace ContactManagement.API.Services
{
    public class ContactService : IContactService
    {
        public IJsonDataRespository<Contact> _contactRepository { get; }
        private readonly IMapper _mapper;
        public ContactService(IJsonDataRespository<Contact> contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public IEnumerable<ContactResponseModel> GetAll()
        {
            var contacts = _contactRepository.AsEnumerable();

            return _mapper.Map<List<ContactResponseModel>>(contacts);
        }

        public ContactResponseModel Create(CreateContactRequest model)
        {
            EnsureUniqueContact(model);

            var contact = _mapper.Map<Contact>(model);

            contact.Id = GetId();

            _contactRepository.Add(contact);

            _contactRepository.SaveChanges();

            return _mapper.Map<ContactResponseModel>(contact);
        }

        private int GetId()
        {
            var lastContact = _contactRepository.AsEnumerable().OrderByDescending(c => c.Id).FirstOrDefault();
            return lastContact == null ? 1 : lastContact.Id + 1;
        }

        private void EnsureUniqueContact(CreateContactRequest model, int contactId = 0)
        {
            var existingContacts = _contactRepository.AsEnumerable()
                .Where(e => e.Email.ToLower() == model.Email.ToLower() && e.Id != contactId)
                .Count();

            if (existingContacts > 0)
            {
                throw new AppException(ErrorMessage.ContactAlreadyExists);
            }
        }

        public async Task<ContactResponseModel> Update(int id, CreateContactRequest model)
        {
            var contact = _contactRepository.AsEnumerable().FirstOrDefault(c => c.Id == id);

            if (contact == null)
            {
                throw new KeyNotFoundException("Contact not found");
            }

            EnsureUniqueContact(model, id);

            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Email = model.Email;

            _contactRepository.SaveChanges();

            return _mapper.Map<ContactResponseModel>(contact); ;
        }

        public void Delete(int id)
        {
            _contactRepository.Delete(c => c.Id == id);

            _contactRepository.SaveChanges();
        }
    }
}
