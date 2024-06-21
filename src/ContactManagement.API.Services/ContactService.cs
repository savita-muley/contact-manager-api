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
        public IBaseRepository<Contact> _contactRepository { get; }
        private readonly IMapper _mapper;
        public ContactService(IBaseRepository<Contact> contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public IEnumerable<ContactResponseModel> GetAll()
        {
            var contacts = _contactRepository.AllAsQueryable().ToList();

            return _mapper.Map<List<ContactResponseModel>>(contacts);
        }

        public async Task<ContactResponseModel> GetById(int id)
        {
            var contact = await _contactRepository.GetById(id);

            return _mapper.Map<ContactResponseModel>(contact); ;
        }

        public ContactResponseModel Create(CreateContactRequest model)
        {
            EnsureUniqueContact(model);

            var contact = _mapper.Map<Contact>(model);

            _contactRepository.Add(contact);

            _contactRepository.SaveChanges();

            return _mapper.Map<ContactResponseModel>(contact); ;
        }

        private void EnsureUniqueContact(CreateContactRequest model, int contactId = 0)
        {
            var existingContacts = _contactRepository.AllAsQueryable()
                .Where(e => e.Email.ToLower() == model.Email.ToLower() && e.Id != contactId)
                .Count();

            if (existingContacts > 0)
            {
                throw new AppException(ErrorMessage.ContactAlreadyExists);
            }
        }

        public async Task<ContactResponseModel> Update(int id, CreateContactRequest model)
        {
            var contact = await _contactRepository.GetById(id);

            if (contact == null)
            {
                throw new KeyNotFoundException("Contact not found");
            }

            EnsureUniqueContact(model, id);

            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Email = model.Email;

            _contactRepository.Update(contact);

            _contactRepository.SaveChanges();

            return _mapper.Map<ContactResponseModel>(contact); ;
        }

        public void Delete(int id)
        {
            _contactRepository.Delete(id);
            _contactRepository.SaveChanges();
        }
    }
}
