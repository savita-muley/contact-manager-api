using AutoMapper;
using ContactManagement.API.DataAccess.Entities;
using ContactManagement.API.Models.Request;
using ContactManagement.API.Models.Response;

namespace ContactManagement.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateContactRequest, Contact>();
            CreateMap<Contact, ContactResponseModel>();
        }
    }
}
