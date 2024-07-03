using Multishop.Catalog.Data.Entities;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Abstract
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetAllWhereAsync(Expression<Func<Contact, bool>> expression);
    }
}