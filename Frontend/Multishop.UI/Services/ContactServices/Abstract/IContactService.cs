using Multishop.UI.Areas.Admin.Models.ViewModels.ContactVMs;
using Multishop.UI.Models.ViewModels.ContactVMs;

namespace Multishop.UI.Services.ContactServices.Abstract
{
    public interface IContactService
    {
        Task<bool> AddAsync(ContactAddVM contactAddVM);
        Task<bool> DeleteAsync(string contactId);
        Task<bool> UpdateAsync(string contactId, bool isRead);
        Task<IEnumerable<ContactVM>> GetAllAsync();
    }
}