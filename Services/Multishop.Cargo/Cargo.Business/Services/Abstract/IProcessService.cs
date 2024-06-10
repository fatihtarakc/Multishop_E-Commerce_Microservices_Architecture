using Cargo.Dto.ProcessDtos;
using Cargo.Entity.Entities.Concrete;

namespace Cargo.Business.Services.Abstract
{
    public interface IProcessService : IGenericService<Process, ProcessAddDto, ProcessUpdateDto, ProcessDetailDto, ProcessListDto>
    {
    }
}