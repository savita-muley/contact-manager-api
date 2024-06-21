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

        [HttpGet]
        public IActionResult GetAll()
        {
            var contacts = _contactService.GetAll();

            return ResponseHelper.SuccessResult(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _contactService.GetById(id);

            return ResponseHelper.SuccessResult(contact);
        }

        [HttpPost]
        public IActionResult Create(CreateContactRequest model)
        {
            var contact = _contactService.Create(model);

            return ResponseHelper.SuccessResult(contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateContactRequest model)
        {
            var contact = await _contactService.Update(id, model);

            return ResponseHelper.SuccessResult(contact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);

            return ResponseHelper.SuccessResult();
        }
    }
}