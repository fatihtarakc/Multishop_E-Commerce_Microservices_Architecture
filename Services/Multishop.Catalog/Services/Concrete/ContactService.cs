using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ContactDtos;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Services.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Services.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;
        private readonly IMapper mapper;
        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            this.contactRepository = contactRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(ContactAddDto entityAddDto)
        {
            var contact = mapper.Map<Contact>(entityAddDto);
            await contactRepository.AddAsync(contact);
        }

        public async Task DeleteAsync(string entityId)
        {
            await contactRepository.DeleteAsync(entityId);
        }

        public async Task UpdateAsync(ContactUpdateDto entityUpdateDto)
        {
            var contact = mapper.Map<Contact>(entityUpdateDto);
            await contactRepository.UpdateAsync(contact);
        }

        public async Task UpdateAsync(string contactId, bool isRead)
        {
            var contact = await contactRepository.GetFirstOrDefaultAsync(contact => contact.Id == contactId);
            contact.IsRead = isRead;

            if (isRead) contact.ReadDate = DateTime.Now;
            else contact.ReadDate = null;

            await contactRepository.UpdateAsync(contact);
        }

        public async Task<ContactDto> GetFirstOrDefaultAsync(Expression<Func<Contact, bool>> expression)
        {
            var contact = await contactRepository.GetFirstOrDefaultAsync(expression);
            return mapper.Map<ContactDto>(contact);
        }

        public async Task<IEnumerable<ContactDto>> GetAllWhereAsync(Expression<Func<Contact, bool>> expression)
        {
            var contacts = await contactRepository.GetAllWhereAsync(expression);
            return mapper.Map<IEnumerable<ContactDto>>(contacts);
        }

        public async Task<IEnumerable<ContactDto>> GetAllAsync()
        {
            var contacts = await contactRepository.GetAllAsync();
            return mapper.Map<IEnumerable<ContactDto>>(contacts);
        }
    }
}