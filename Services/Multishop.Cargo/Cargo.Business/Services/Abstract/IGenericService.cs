using Cargo.Entity.Entities.Abstract;
using System.Linq.Expressions;

namespace Cargo.Business.Services.Abstract
{
    public interface IGenericService<Entity, EntityAddDto, EntityUpdateDto, EntityDetailDto, EntityListDto> where Entity : BaseEntity
    {
        Task<bool> AddAsync(EntityAddDto entityAddDto);
        Task<bool> DeleteAsync(Guid entityId);
        Task<bool> UpdateAsync(EntityUpdateDto entityUpdateDto);
        Task<EntityDetailDto> GetFirstOrDefaultAsync(Expression<Func<Entity,  bool>> expression);
        Task<IEnumerable<EntityListDto>> GetAllAsync();
    }
}