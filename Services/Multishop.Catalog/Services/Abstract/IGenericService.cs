using System.Linq.Expressions;

namespace Multishop.Catalog.Services.Abstract
{
    public interface IGenericService<Entity, EntityDto, EntityAddDto, EntityUpdateDto> where Entity : class where EntityDto : class where EntityAddDto : class where EntityUpdateDto : class
    {
        Task AddAsync(EntityAddDto entityAddDto);
        Task DeleteAsync(string entityId);
        Task UpdateAsync(EntityUpdateDto entityUpdateDto);
        Task<EntityDto> GetFirstOrDefaultAsync(Expression<Func<Entity, bool>> expression);
        Task<IEnumerable<EntityDto>> GetAllAsync();
    }
}