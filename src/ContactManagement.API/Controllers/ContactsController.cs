using ContactManagement.API.Helpers;
using ContactManagement.API.Models.Request;
using ContactManagement.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private IContactService _contactService;

        public ContactsController(IContactService userService)
        {
            _contactService = userService;
        }


        /// <summary>
        /// Returns all the contacts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var contacts = _contactService.GetAll();

            return ResponseHelper.SuccessResult(contacts);
        }

        /// <summary>
        /// Create new contact
        /// </summary>
        /// <param name="model">Contact Model</param>
        /// <returns>Created Contact</returns>
        [HttpPost]
        public IActionResult Create(CreateContactRequest model)
        {
            var contact = _contactService.Create(model);

            return ResponseHelper.SuccessResult(contact);
        }


        /// <summary>
        /// Updates an existing contact
        /// </summary>
        /// <param name="id">Id of the contact to update</param>
        /// <param name="model">Contact Model</param>
        /// <returns>Updated Contact</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateContactRequest model)
        {
            var contact = await _contactService.Update(id, model);

            return ResponseHelper.SuccessResult(contact);
        }

        /// <summary>
        /// Deletes the contact
        /// </summary>
        /// <param name="id">Id of the contact to delete</param>
        /// <returns>Empty Result</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);

            return ResponseHelper.SuccessResult();
        }
    }
}