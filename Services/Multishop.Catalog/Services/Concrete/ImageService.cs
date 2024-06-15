using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ImageDtos;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Services.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Services.Concrete
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;
        private readonly IMapper mapper;
        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(ImageAddDto entityAddDto)
        {
            var image = mapper.Map<Image>(entityAddDto);
            await imageRepository.AddAsync(image);
        }

        public async Task DeleteAsync(string entityId)
        {
            await imageRepository.DeleteAsync(entityId);
        }

        public async Task UpdateAsync(ImageUpdateDto entityUpdateDto)
        {
            var image = mapper.Map<Image>(entityUpdateDto);
            await imageRepository.UpdateAsync(image);
        }

        public async Task<ImageDto> GetFirstOrDefaultAsync(Expression<Func<Image, bool>> expression)
        {
            var image = await imageRepository.GetFirstOrDefaultAsync(expression);
            return mapper.Map<ImageDto>(image);
        }

        public async Task<IEnumerable<ImageDto>> GetAllAsync()
        {
            var images = await imageRepository.GetAllAsync();
            return mapper.Map<IEnumerable<ImageDto>>(images);
        }
    }
}