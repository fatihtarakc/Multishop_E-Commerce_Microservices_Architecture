using Multishop.UI.Areas.Admin.Models.ViewModels.ContactVMs;
using Multishop.UI.Models.ViewModels.ContactVMs;
using Multishop.UI.Services.ContactServices.Abstract;
using System.Net;

namespace Multishop.UI.Services.ContactServices.Concrete
{
    public class ContactService : IContactService
    {
        private readonly HttpClient httpClient;
        public ContactService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> AddAsync(ContactAddVM contactAddVM) =>
            (await httpClient.PostAsJsonAsync("contact/add", contactAddVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> DeleteAsync(string contactId) =>
            (await httpClient.DeleteAsync($"contact/delete/{contactId}")).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> UpdateAsync(string contactId, bool isRead)
        {
            var httpResponseMessage = await httpClient.PutAsync($"contact/update/{contactId},{isRead}", null);
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? true : false;
        }

        public async Task<IEnumerable<ContactVM>> GetAllAsync()
        {
            var httpResponseMessage = await httpClient.GetAsync("contact/contacts");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<ContactVM>>() : null;
        }
    }
}