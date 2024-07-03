using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ContactDtos;
using System.Linq.Expressions;

namespace Multishop.Catalog.Services.Abstract
{
    public interface IContactService : IGenericService<Contact, ContactDto, ContactAddDto, ContactUpdateDto>
    {
        Task UpdateAsync(string contactId, bool isRead);
        Task<IEnumerable<ContactDto>> GetAllWhereAsync(Expression<Func<Contact, bool>> expression);
    }
}