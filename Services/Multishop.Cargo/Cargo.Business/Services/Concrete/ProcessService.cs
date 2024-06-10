using Cargo.Business.Services.Abstract;
using Cargo.DataAccess.Repositories.Abstract;
using Cargo.Dto.ProcessDtos;
using Cargo.Entity.Entities.Concrete;
using Mapster;
using System.Linq.Expressions;

namespace Cargo.Business.Services.Concrete
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessRepository processRepository;
        public ProcessService(IProcessRepository processRepository)
        {
            this.processRepository = processRepository;
        }

        public async Task<bool> AddAsync(ProcessAddDto entityAddDto)
        {
            var process = entityAddDto.Adapt<Process>();
            return await processRepository.AddAsync(process);
        }

        public async Task<bool> DeleteAsync(Guid entityId)
        {
            var process = await processRepository.GetFirstOrDefaultAsync(process => process.Id == entityId);
            if (process is null) return false;

            return await processRepository.DeleteAsync(process);
        }

        public async Task<bool> UpdateAsync(ProcessUpdateDto entityUpdateDto)
        {
            var process = await processRepository.GetFirstOrDefaultAsync(process => process.Id == entityUpdateDto.Id);
            if (process is null) return false;

            return await processRepository.UpdateAsync(entityUpdateDto.Adapt(process));
        }

        public async Task<ProcessDetailDto> GetFirstOrDefaultAsync(Expression<Func<Process, bool>> expression)
        {
            return (await processRepository.GetFirstOrDefaultAsync(expression)).Adapt<ProcessDetailDto>();
        }

        public async Task<IEnumerable<ProcessListDto>> GetAllAsync()
        {
            return (await processRepository.GetAllAsync()).Adapt<IEnumerable<ProcessListDto>>();
        }
    }
}