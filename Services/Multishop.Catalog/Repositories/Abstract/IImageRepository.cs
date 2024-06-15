using Multishop.Catalog.Data.Entities;

namespace Multishop.Catalog.Repositories.Abstract
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        Task<IEnumerable<Image>> GetAllWhereAsync(string productId);
    }
}