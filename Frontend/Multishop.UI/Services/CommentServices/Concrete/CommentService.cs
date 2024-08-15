using Multishop.UI.Models.ViewModels.CommentVMs;
using Multishop.UI.Services.CommentServices.Abstract;
using System.Net;

namespace Multishop.UI.Services.CommentServices.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient httpClient;
        public CommentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<bool> AddAsync(CommentAddVM commentAddVM) =>
            (await httpClient.PostAsJsonAsync("comment/add", commentAddVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<IEnumerable<CommentVM>> GetAllByAsync(string productId)
        {
            var httpResponseMessage = await httpClient.GetAsync($"comment/commentsgetby/{productId}");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<CommentVM>>() : null;
        }
    }
}