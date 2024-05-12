using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ProductDtos;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Services.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(ProductAddDto entityAddDto)
        {
            var product = mapper.Map<Product>(entityAddDto);
            await productRepository.AddAsync(product);
        }

        public async Task DeleteAsync(string entityId)
        {
            await productRepository.DeleteAsync(entityId);
        }

        public async Task UpdateAsync(ProductUpdateDto entityUpdateDto)
        {
            var product = mapper.Map<Product>(entityUpdateDto);
            await productRepository.UpdateAsync(product);
        }

        public async Task<ProductDetailDto> GetFirstOrDefaultAsync(Expression<Func<Product, bool>> expression)
        {
            var product = await productRepository.GetFirstOrDefaultAsync(expression);
            return mapper.Map<ProductDetailDto>(product);
        }

        public async Task<IEnumerable<ProductListDto>> GetAllAsync()
        {
            var products = await productRepository.GetAllAsync();
            return mapper.Map<IEnumerable<ProductListDto>>(products);
        }
    }
}