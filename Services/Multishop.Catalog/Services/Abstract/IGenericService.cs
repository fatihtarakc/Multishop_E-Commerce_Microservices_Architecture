using System.Linq.Expressions;

namespace Multishop.Catalog.Services.Abstract
{
    public interface IGenericService<Entity, EntityAddDto, EntityUpdateDto, EntityDetailDto, EntityListDto> where Entity : class where EntityAddDto : class where EntityUpdateDto : class where EntityDetailDto : class where EntityListDto : class
    {
        Task AddAsync(EntityAddDto entityAddDto);
        Task DeleteAsync(string entityId);
        Task UpdateAsync(EntityUpdateDto entityUpdateDto);
        Task<EntityDetailDto> GetFirstOrDefaultAsync(Expression<Func<Entity, bool>> expression);
        Task<IEnumerable<EntityListDto>> GetAllAsync();
    }
}