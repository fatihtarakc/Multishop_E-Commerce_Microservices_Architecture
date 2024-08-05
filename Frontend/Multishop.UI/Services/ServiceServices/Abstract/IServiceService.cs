using Multishop.UI.Areas.Admin.Models.ViewModels.ServiceVMs;
using Multishop.UI.Models.ViewModels.ServiceVMs;

namespace Multishop.UI.Services.ServiceServices.Abstract
{
    public interface IServiceService
    {
        Task<bool> AddAsync(ServiceAddVM serviceAddVM);
        Task<bool> DeleteAsync(string serviceId);
        Task<bool> UpdateAsync(ServiceUpdateVM serviceUpdateVM);
        Task<ServiceVM> GetFirstOrDefaultAsync(string serviceId);
        Task<IEnumerable<ServiceVM>> GetAllAsync();
    }
}