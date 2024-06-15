using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.CategoryDtos;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Services.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(CategoryAddDto entityAddDto)
        {
            var category = mapper.Map<Category>(entityAddDto);
            await categoryRepository.AddAsync(category);
        }

        public async Task DeleteAsync(string entityId)
        {
            await categoryRepository.DeleteAsync(entityId);
        }

        public async Task UpdateAsync(CategoryUpdateDto entityUpdateDto)
        {
            var category = mapper.Map<Category>(entityUpdateDto);
            await categoryRepository.UpdateAsync(category);
        }

        public async Task<CategoryDto> GetFirstOrDefaultAsync(Expression<Func<Category, bool>> expression)
        {
            var category = await categoryRepository.GetFirstOrDefaultAsync(expression);
            return mapper.Map<CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await categoryRepository.GetAllAsync();
            return mapper.Map<IEnumerable<CategoryDto>>(categories);
        }
    }
}